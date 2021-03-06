using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataManager
    {
        public List<ITour> GetTours();
        public void insertTour(ITour NewTour);
        public ITour GetTour(int id);

        public void deleteTour(int id);
        public void modifyTour(ITour NewTour);
        public int getTourId(string name);

        public List<ILog> GetLogs();
        public void insertLog(Log NewLog);
        public ILog getLog(int id);

        public void deleteLog(int id);
        public void modifyLog(ILog NewLog);
        public int getLogId(string name);
        public void exportTour(DataAccess.ITour tour, string path);
        public DataAccess.ITour importTour(string path);
    }
}
