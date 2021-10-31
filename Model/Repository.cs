using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Model.Common;
using Business;
using DataAccess;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Model
{
    public class Repository
    {
        #region Singleton
        public Observable observable = new Observable();
        private static Repository _address = new Repository();
        public static Repository address { get { return _address; } }
        private Repository() { }

        #endregion
        #region Dependencies
        public IDataManager dataManager = new DataManager();
        public IImageLoader imageLoader = new ImageLoader();
        public IMapquest mapquest = new Mapquest();
        public DataAccessModelConverter dataAccessModelConverter = new DataAccessModelConverter();



        #endregion
        #region Variables
        public List<Model.ILog> logList { get; private set; } = new List<Model.ILog>();
        public List<Model.ITour> tourList { get; private set; } = new List<Model.ITour>();
        public List<DataAccess.ITour> tourListDB { get; private set; } = new List<DataAccess.ITour>();
        public List<DataAccess.ILog> logListDB { get; private set; } = new List<DataAccess.ILog>();
        log4net.ILog Logging = LogManager.GetLogger(typeof(Repository));


        BitmapImage _displayedImage;
        public BitmapImage displayedImage { get { return _displayedImage; } private set { _displayedImage = value; observable.OnPropertyChanged("map"); } }



        #endregion


        //Filtering
        public void filterTours(string filter)
        {
            tourList = dataAccessModelConverter.tourListModel(tourListDB);
            List<Model.ITour> newList = new List<ITour>();
            foreach (Model.ITour tour in tourList)
            {
                string serialized = JsonConvert.SerializeObject(tour);
                Console.WriteLine(serialized);
                if (serialized.Contains(filter))
                {
                    newList.Add(tour);
                }
            }
            tourList = newList;
            observable.OnPropertyChanged("tourFilter");
        }

        public void filterLogs(string filter)
        {
            tourList = dataAccessModelConverter.tourListModel(tourListDB);
            logList = dataAccessModelConverter.logListModel(logListDB,tourListDB,tourList);
            List<Model.ILog> newList = new List<ILog>();
            foreach (Model.ILog log in logList)
            {
                string serialized = JsonConvert.SerializeObject(log);
                Console.WriteLine(serialized);
                if (serialized.Contains(filter))
                {
                    newList.Add(log);
                }
            }
            logList = newList;
            observable.OnPropertyChanged("logFilter");
        }
        //ExportImport
        public void exportTour(string inputRoute, string exportPath)
        {
            foreach (DataAccess.ITour tour in tourListDB)
            {
                if (tour.name == inputRoute)
                {
                    try
                    {
                        dataManager.exportTour(tour, exportPath);
                    } catch (Exception e)
                    {
                        Logging.Error("Couldn't export tour. ");
                    }

                    break;
                }
            }
        }

        public async void importTour(string importPath)
        {
            DataAccess.ITour tourDB;
            try
            {
                tourDB = dataManager.importTour(importPath);
                dataManager.insertTour(tourDB);

            }
            catch {
                Logging.Error("Couldn't import tour. ");
                return; 
            }
            tourListDB.Add(tourDB);
            tourList.Add(dataAccessModelConverter.tourModel(tourDB));
                 
            //getImage

            try
            {
                imageLoader.saveImage(await mapquest.GetMapRouteCoord(tourDB.sl_x, tourDB.sl_y, tourDB.el_x, tourDB.sl_y), tourDB.name);
            }
            catch (Exception e)
            {
                Logging.Error("Couldn't save image during Tour Import. ");
            }
            observable.OnPropertyChanged("tourList");
        }

        //Reports
        public void generateLogReport()
        {
            ReportGenerator reportGenerator = new ReportGenerator();
            float totalTime = Statistics.getTotalTime(logListDB);
            float totalDistance = Statistics.getTotalDistance(logListDB, tourListDB);
            reportGenerator.generateLogReport(totalTime, totalDistance);
        }

        public void generateTourReport()
        {
            ReportGenerator reportGenerator = new ReportGenerator();
            reportGenerator.generateTourReport(logListDB, tourListDB[0]);
        }

        //Initialise From Database
        public void loadTourLogData()
        {
            try
            {
                tourListDB = dataManager.GetTours();
            }
            catch (Exception e)
            {
                Logging.Error("Couldn't fetch tours. ");
            }
            try
            {
                logListDB = dataManager.GetLogs();

            }
            catch (Exception e)
            {
                Logging.Error("Couldn't fetch logs. ");
            }

            tourList = dataAccessModelConverter.tourListModel(tourListDB);
            logList = dataAccessModelConverter.logListModel(logListDB, tourListDB, tourList);
            observable.OnPropertyChanged("LogTourData");
        }
        //CRUD Log
        public void addLog(string inputLogTitle, string inputRouteName, string inputDuration, string inputDate, string report, string inputrating, string inputtopspeed)
        {
            Model.Log log = Log.fromStringInput(inputLogTitle, inputRouteName, inputDuration, inputDate, report, inputrating, inputtopspeed, tourList);
            DataAccess.Log logToInsertDB = dataAccessModelConverter.logDA(log);
            logToInsertDB.route_id = tourIDFromName(tourListDB, inputRouteName);
            int id=-1;
            if (logToInsertDB.route_id == -1)
            {
                try
                {
                    id = dataManager.getTourId(inputRouteName);
                }
                catch (Exception e)
                {
                    Logging.Error("Couldn't find the tour for the log. ");
                    return;
                }
                logToInsertDB.route_id = id;
            }
            logList.Add(log);
            logListDB.Add(logToInsertDB);
            try
            {
                dataManager.insertLog(logToInsertDB);
            } catch (Exception e) 
            {
                Logging.Error("Couldn't insert Log");
                return;
            }
            observable.OnPropertyChanged("LogTourData");
        }

        public void modifyLog(string inputRouteName, string newDuration, string newTopSpeed, string newRating, string newReport, string newDate) //-R
        {
            Model.ILog targetLog = null;
            foreach(Model.ILog log in logList)
            {
                if (log.logTitle == inputRouteName)
                {
                    targetLog = log;
                    break;
                }
            }
            DataAccess.ILog targetLogDB = null;
            foreach (DataAccess.ILog log in logListDB)
            {
                if (log.logTitle == inputRouteName)
                {
                    targetLogDB = log;
                    break;
                }
            }
            Model.ILog newLog=Log.fromStringInput(targetLog.logTitle, targetLog.routeName, newDuration, newDate, newReport, newRating, newTopSpeed, tourList);
            int routeID = targetLogDB.route_id;

            DataAccess.ILog newLogDB = dataAccessModelConverter.logDA(newLog);
            newLogDB.route_id = routeID;
            try
            {
                dataManager.modifyLog(newLogDB);
            } catch (Exception e)
            {
                Logging.Error("Couldn't Modify Log. ");
                return;
            }
            logList.Remove(targetLog);
            logListDB.Remove(targetLogDB);
            logList.Add(newLog);
            logListDB.Add(newLogDB);

            observable.OnPropertyChanged("LogTourData");
        }

        public void removeLog(int logIndex)
        {
            string name = logList[logIndex].logTitle;
            DataAccess.ILog logToDelete = logFromName(logListDB, name);
            try
            {
                dataManager.deleteLog(logToDelete.id);
            } catch (Exception e)
            {
                Logging.Error("Couldn't delete Log. ");
                return;
            }
            logList.RemoveAt(logIndex);
            logListDB.Remove(logToDelete);
            observable.OnPropertyChanged("LogTourData");
        }

        //CRUD Tour
        public async void addTour(string inputName, string inputDescription, string inputInformation, string inputStartLocation, string inputEndLocation) // -R 
        {

            //Mapquest mapquest = new Mapquest();
            string[] locations = { inputStartLocation, inputEndLocation };
            float[] coords = null;
            try {
                coords = await mapquest.namesToCoord(locations);
            }catch(Exception e)
            {
                Logging.Error("Couldn't get coordinates. ");
                return;
            }

            if (coords==null? true:coords.Length != 4)
            {
                Logging.Error("Couldn't get coordinates. ");
                return;
            }
            float distance = (float)Math.Pow(Math.Pow(coords[0] - coords[1], 2) + Math.Pow(coords[1] - coords[2], 2), 0.5);
            //Add to active list
            Tour tour = new Tour(inputName, inputDescription, inputInformation, distance, inputStartLocation, inputEndLocation);
            //Add to Database
            DataAccess.Tour tourDB = new DataAccess.Tour(inputName,
                distance,
                inputStartLocation,
                coords[0],
                coords[1], inputEndLocation, coords[2], coords[3], -1, inputDescription, inputInformation);
            try
            {
                dataManager.insertTour(tourDB);
            }
            catch (Exception e){ 
                Logging.Error("Couldn't insert Tour. ");
                return;
            }
            tourList.Add(tour);
            tourListDB.Add(tourDB);
            try
            {
                imageLoader.saveImage(await mapquest.GetMapRouteCoord(coords[0], coords[1], coords[2], coords[3]), inputName);
            }
            catch (Exception e)
            {
                Logging.Error("Couldn't save image. ");
            }
            observable.OnPropertyChanged("LogTourData");

        }


        public void modifyTour(string inputRouteName, string newDescription, string newInformation)
        {
            loadTourLogData();
            DataAccess.ITour newDBTour = null;
            Model.ITour newModelTour = null;
            foreach (DataAccess.ITour tour in tourListDB)
            {
                if (tour.name == inputRouteName)
                {
                    newDBTour = tour;
                    break;
                }
            }
            foreach (Model.ITour tour in tourList)
            {
                if (tour.name == inputRouteName)
                {
                    newModelTour = tour;
                    break;
                }
            }
            //Update map
            newDBTour.routeDescription = newDescription;
            newDBTour.routeInformation = newInformation;
            newModelTour.routeDescription = newDescription;
            newModelTour.routeInformation = newInformation;
            try { 
            dataManager.modifyTour(newDBTour);
            } catch (Exception e)
            {
                Logging.Error("Couldn't modify Tour. ");
            }

            observable.OnPropertyChanged("LogTourData");

        }

        public void removeTour(int list_index) // -R also remove image
        {
            int id = -1;
            if (list_index >= tourList.Count || list_index < 0)
            {
                Console.WriteLine(list_index);
                return;
            }
            string name = tourList[list_index].name;
            DataAccess.ITour tourToDelete = null;
            foreach (DataAccess.ITour tour in tourListDB)
            {
                if (tour.name == name)
                {
                    id = tour.id;
                    tourToDelete = tour;
                    break;
                }
            }
            try
            {
                dataManager.deleteTour(id);

            } catch (Exception e)
            {
                Logging.Error("Couldn't delete Tour. ");
            }
            tourList.RemoveAt(list_index);
            tourListDB.Remove(tourToDelete);
            observable.OnPropertyChanged("LogTourData");
        }


        //Map
        public void setImageFromTourId(int id) 
        {
            try
            {
                if (id == -1)
                {
                    displayedImage = imageLoader.getImage("NOIMAGE");
                    observable.OnPropertyChanged("map");
                    return;
                }
                try
                {
                    displayedImage = imageLoader.getImage(tourList[id].name);
                    return;
                }
                catch (Exception e)
                {
                    Logging.Error("Missing image. ");
                    displayedImage = imageLoader.getImage("NOIMAGE");
                    observable.OnPropertyChanged("map");
                    return;
                }
            }
            catch (Exception e)
            {
                Logging.Error("Missing image. ");
            }
        }
        public async void setMapImageFromCoords(float[] coords)
        {
            try
            {
                Mapquest mapquest = new Mapquest();
                displayedImage = await mapquest.GetMapRouteCoord(coords[0], coords[1], coords[2], coords[3]);
                observable.OnPropertyChanged("map");
            }
            catch (Exception e)
            {

            }
        }
        public async Task updateMap(string start, string end)
        {
            try
            {
                string[] locations = { start, end };
                float[] coords = await mapquest.namesToCoord(locations);
                setMapImageFromCoords(coords); //-R 

            }
            catch (Exception)
            {
                Logging.Error("Didn't get the coordiantes from Mapquest. ");
            }
        }
        public void setImageFromLogId(int logIndex)
        {
            try
            {
                if (logIndex == -1)
                {
                    displayedImage = imageLoader.getImage("NOIMAGE");
                    return;
                }
                try
                {
                    string name = logList[logIndex].tour.name;
                    displayedImage = imageLoader.getImage(name);
                    return;
                }
                catch (Exception e)
                {
                    Logging.Error("Missing image. ");
                    displayedImage = imageLoader.getImage("NOIMAGE");
                    return;
                }
            }
            catch (Exception e)
            {
                Logging.Error("Missing image. ");
            }
        }

        //Utility
        public string tourNameFromID(List<DataAccess.ITour> tourListDA, int inputRouteID)
        {
            foreach (DataAccess.ITour tour in tourListDA)
            {
                if (tour==null?false:tour.id == inputRouteID)
                {
                    return tour.name;
                }
            }
            return null;
        }
        public int tourIDFromName(List<DataAccess.ITour> tourListDA, string inputRouteName)
        {
            int tour_id = -1;
            foreach (DataAccess.ITour tour in tourListDA)
            {
                if (tour == null ? false : tour.name == inputRouteName)
                {
                    tour_id = tour.id;
                    break;
                }
            }
            return tour_id;
        }
        public int logIdFromName(List<DataAccess.ILog> logListDA, string inputLogName)
        {
            int log_id = -1;
            foreach (DataAccess.ILog log in logListDA)
            {
                if (log == null ? false : log.logTitle == inputLogName)
                {
                    log_id = log.id;
                    break;
                }
            }
            return log_id;
        }
        public DataAccess.ILog logFromName(List<DataAccess.ILog> logListDA, string inputLogName)
        {
            DataAccess.ILog targetLog = null;
            foreach (DataAccess.ILog log in logListDA)
            {
                if (log == null ? false : log.logTitle == inputLogName)
                {
                    targetLog = log;
                    break;
                }
            }
            return targetLog;
        }
    }
}
