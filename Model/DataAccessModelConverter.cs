using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DataAccessModelConverter
    {

        public List<Model.ILog> logListModel(List<DataAccess.ILog> logListDA, List<DataAccess.ITour> tourListDA, List<Model.ITour> tourListModel)
        {
            List<Model.ILog> logList = new List<Model.ILog>();
            foreach (DataAccess.ILog log in logListDA)
            {
                Model.ITour tour = findTourModel(log.route_id, tourListDA, tourListModel);
                if (tour != null)
                {
                    logList.Add(new Model.Log(log.logTitle, log.duration, Date.fromString(log.date), tour,
                        log.report, log.rating, log.averageSpeed, log.topSpeed, log.calories));
                }
            }
            return logList;
        }
        
        public Model.ITour findTourModel(int id, List<DataAccess.ITour> tourListDA, List<Model.ITour> tourListModel)
        {
            foreach (DataAccess.ITour tour in tourListDA)
            {
                if (tour.id == id)
                {
                    foreach (Model.ITour tourModel in tourListModel)
                    {
                        if (tour.name == tourModel.name)
                        {
                            return tourModel;
                        }
                    }
                    //return new Model.Tour(tour.name, tour.routeDescription, tour.routeInformation, tour.distance, tour.sl_name, tour.el_name);
                }
            }
            return null;
        }

        public List<Model.ITour> tourListModel(List<DataAccess.ITour> tourListDB)
        {
            List<Model.ITour> tourList = new List<Model.ITour>();
            foreach (DataAccess.ITour tour in tourListDB)
            {
                tourList.Add(new Model.Tour(tour.name, tour.routeDescription, tour.routeInformation, tour.distance, tour.sl_name, tour.el_name));
            }
            return tourList;
        }
        public DataAccess.Log logDA(Model.ILog logModel)
        {
            DataAccess.Log logDB = new DataAccess.Log(-1, logModel.logTitle, -1, logModel.report, logModel.duration, logModel.rating,
                logModel.averageSpeed, logModel.topSpeed, logModel.calories, logModel.date.ToString());
            return logDB;
        }

    }
}
