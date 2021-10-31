using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Model;
using log4net;
using System.ComponentModel;

namespace ViewModel
{
    public class ListLogsViewModel : Observable
    {
        #region Singleton
        public NotifyUser notifyUser = new NotifyUser();

        private static ListLogsViewModel _address = new ListLogsViewModel();
        public static ListLogsViewModel address { get { return _address; } }
        log4net.ILog logging = LogManager.GetLogger(typeof(ListLogsViewModel));
        #endregion
        public RelayCommandObj updateMapCommand { get; }
        public RelayCommandObj deleteLogCommand { get; }

        Repository repository = Repository.address;
        public List<Model.ILog> logList { get; private set; } = new List<Model.ILog>();
        string _filter;
        public string filter
        {
            get { return _filter; }
            set { _filter = value; repository.filterLogs(_filter); }
        }
        private ListLogsViewModel() {
            logList = repository.logList;
            repository.observable.PropertyChanged += (s, e) => { logList = new List<Model.ILog>(repository.logList); this.OnPropertyChanged("logList"); };
            updateMapCommand = new RelayCommandObj(updateMap, (obj) => { return true; });
            deleteLogCommand = new RelayCommandObj(deleteRoute, (obj) => { return true; });
        }
        void updateMap(object obj)
        {
            int logIndex;
            logging.Info("Updating map. ");
            try
            {
                logIndex = Int32.Parse(obj.ToString());
            }
            catch (Exception e)
            {
                logging.Error("Parsing index failed. ");
                return;
            }
            repository.setImageFromLogId(logIndex);
        }
        void deleteRoute(object obj)
        {
            int logIndex;
            logging.Info("Deleting route at index. " + obj.ToString());
            try {
                logIndex = Int32.Parse(obj.ToString());
            } catch (Exception e)
            {
                logging.Error("Parsing index failed. ");
                return;
            }
            repository.removeLog(logIndex);
        }


    }
}
