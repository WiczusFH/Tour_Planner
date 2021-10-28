using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Model.Common;
using DataAccess;
using System.Windows.Media.Imaging;

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
                tourList.Add(new Model.Tour(tour.name,tour.routeDescription,tour.routeInformation,tour.distance, null, tour.sl_name, tour.el_name)); //-R Image
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
                    return new Model.Tour(tour.name, tour.routeDescription, tour.routeInformation, tour.distance, null, tour.sl_name, tour.el_name); //-R Image
                }
            }
            return null;
        }

        public BitmapImage getImage(int id)
        {
            StringBuilder sb = new StringBuilder();
            if (id == -1)
            {
                sb.Append("Images/NOIMAGE.png");
                return imageLoader.getImage(sb.ToString());
            }
            Mapquest mapquest = new Mapquest();
            mapquest.GetMapRouteCoord(40.0f, 29.0f, 40.01f, 29.01f);
            
            return null;
        }
    }
}
