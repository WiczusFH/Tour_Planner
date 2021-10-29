using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    interface IDataManager
    {
        public List<ITour> GetTours();
        public void insertTour(Tour NewTour);
        public ITour GetTour(int id);

        public void deleteTour(int id);
        public void modifyTour(ITour NewTour);
        public int getTourId(string name);

        public List<ILog> GetLogs();
        public void insertLog(Log NewLog);
        public ILog getLog(int id);

        public void deleteLog(int id);
        public void modifyLog(Log NewLog, int id);
        public int getLogId(string name);

    }
}
