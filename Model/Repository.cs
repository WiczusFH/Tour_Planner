using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Model.Common;
using DataAccess;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace Model
{
    public class Repository
    {
        #region Singleton
        public Observable observable = new Observable();
        private static Repository _address = new Repository();
        public static Repository address { get { return _address; } }
        private log4net.ILog log;
        #endregion
        #region Dependencies
        public DataManager dataManager = new DataManager();
        public ImageLoader imageLoader = new ImageLoader();
        #endregion
        #region Variables
        public List<Model.ILog> logList { get; private set; } = new List<Model.ILog>();
        public List<Model.ITour> tourList { get; private set; } = new List<Model.ITour>();
        public List<DataAccess.ITour> tourListDB { get; private set; } = new List<DataAccess.ITour>();
        public List<DataAccess.ILog> logListDB { get; private set; } = new List<DataAccess.ILog>();

        BitmapImage _displayedImage;
        public BitmapImage displayedImage { get { return _displayedImage; } private set { _displayedImage = value; observable.OnPropertyChanged("map");} }
        public float[] currentCoords { get; private set; }
        #endregion
        private Repository() {
            Configuration configuration = Configuration.address;
            DataManager dataManager = new DataManager();
            setTours();
            setLogs();
        }

        public void setLogs()
        {
            tourListDB = dataManager.GetTours();
            logListDB = dataManager.GetLogs();
            convertLog_DB2Model();
        }

        public void setTours()
        {
            tourListDB=dataManager.GetTours();
            convertTour_DB2Model();
        }
        
        void convertTour_DB2Model()
        {
            tourList = new List<ITour>();
            foreach (DataAccess.ITour tour in tourListDB)
            {
                tourList.Add(new Model.Tour(tour.name,tour.routeDescription,tour.routeInformation,tour.distance, tour.sl_name, tour.el_name)); 
            }

            observable.OnPropertyChanged("tourList");
        }
        
        void convertLog_DB2Model()
        {
            logList = new List<ILog>();
            foreach (DataAccess.ILog log in logListDB)
            {
                Model.Tour tour = findTour(log.route_id);
                if (tour != null)
                {
                    logList.Add(new Model.Log(log.logTitle, log.duration, Date.fromString(log.date), tour,
                        log.report, log.rating, log.averageSpeed, log.topSpeed, log.calories));
                }
            }

            observable.OnPropertyChanged("logList");
        }
        
        Model.Tour findTour(int id)
        {
            foreach (DataAccess.ITour tour in tourListDB)
            {
                if (tour.id == id)
                {
                    return new Model.Tour(tour.name, tour.routeDescription, tour.routeInformation, tour.distance, tour.sl_name, tour.el_name); 
                }
            }
            return null;
        }

        public void setImageFromId(int id) //-R String generation in DA
        {
            StringBuilder sb = new StringBuilder();
            if (id == -1)
            {
                sb.Append("Images/NOIMAGE.png");
                displayedImage = imageLoader.getImage(sb.ToString());
                return;
            }
            try
            {
                sb.Append("Images/");
                sb.Append(tourList[id].name);
                sb.Append(".png");
                displayedImage = imageLoader.getImage(sb.ToString());
                return;
            }
            catch (Exception e)
            {
                sb.Append("Images/NOIMAGE.png");
                displayedImage = imageLoader.getImage(sb.ToString());
                return;
            }
        }
        public async void setMapImageFromCoords()
        {
            try
            {
                Mapquest mapquest = new Mapquest();
                displayedImage = await mapquest.GetMapRouteCoord(currentCoords[0], currentCoords[1], currentCoords[2], currentCoords[3]);
            }
            catch (Exception e)
            {

            }
        }

        public async void updateCoords(string start,string end)
        {
            Mapquest mapquest = new Mapquest();
            float[] coords;
            try
            {
                string[] locations = { start, end };
                currentCoords = await mapquest.namesToCoord(locations);
                setMapImageFromCoords();
            }
            catch (Exception)
            {
            }
        }

        public async void addTour(string inputName, string inputDescription, string inputInformation, string inputStartLocation, string inputEndLocation) //moveToDataAccess
        {
            Mapquest mapquest = new Mapquest();
            string[] locations = { inputStartLocation, inputEndLocation };
            float[] coords = await mapquest.namesToCoord(locations);
            float distance = (float)Math.Pow(Math.Pow(coords[0] - coords[1], 2) + Math.Pow(coords[1] - coords[2], 2), 0.5);
            //updateCoords(inputStartLocation, inputEndLocation);
            //Add to active list
            Tour tour=new Tour(inputName, inputDescription, inputInformation, distance, inputStartLocation, inputEndLocation);
            tourList.Add(tour);
            //Add to Database
            dataManager.insertTour(new DataAccess.Tour(inputName,
                distance,
                inputStartLocation,
                coords[0],
                coords[1], inputEndLocation, coords[2], coords[3], -1, inputDescription, inputInformation));
            //Add image
            imageLoader.saveImage(await mapquest.GetMapRouteCoord(currentCoords[0], currentCoords[1], currentCoords[2], currentCoords[3]),inputName);
        }
    }
}
