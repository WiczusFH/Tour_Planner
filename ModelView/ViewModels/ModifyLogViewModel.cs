using System;
using log4net;
using Model;
using System.ComponentModel;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ViewModel
{
    public class ModifyLogViewModel : Observable
    {
        #region Singleton
        public NotifyUser notifyUser = new NotifyUser();

        private static ModifyLogViewModel _address = new ModifyLogViewModel();
        public static ModifyLogViewModel address { get { return _address; } }

        private log4net.ILog log;

        Repository repository = Repository.address;
        #endregion

        #region variables

        public string newDuration { get; set; }
        public string newTopSpeed { get; set; }
        public string newRating { get; set; }
        public string newReport { get; set; }
        public string newDate { get; set; }

        string _inputRouteName;
        public string inputRouteName
        {
            get { return _inputRouteName; }
            set
            {
                foreach (Model.ILog log in logList)
                {
                    _inputRouteName = value;
                    if (log.logTitle== value)
                    {
                        newReport = log.report; OnPropertyChanged("newReport");
                        newDuration = log.durationString; OnPropertyChanged("newDuration");
                        newRating = log.ratingString; OnPropertyChanged("newRating");
                        newDate = log.dateString; OnPropertyChanged("newDate");
                        newTopSpeed = log.topSpeedString; OnPropertyChanged("newTopSpeed");
                        modifyCommand.RaiseCanExecuteChanged();
                        break;
                    }
                }
            }
        }

        #endregion
        public List<Model.ILog> logList { get; private set; }
        public RelayCommand modifyCommand { get; private set; }
        private ModifyLogViewModel() {
            log = LogManager.GetLogger(GetType());
            modifyCommand = new RelayCommand(modifyLog, modifyCommandPredicate);
            logList = repository.logList;
            repository.observable.PropertyChanged += (s, e) => { logList = new List<Model.ILog>(repository.logList); OnPropertyChanged("logList"); };
            OnPropertyChanged("tourList");

            modifyCommand.RaiseCanExecuteChanged();
        }
        bool modifyCommandPredicate(object obj)
        {
            log.Info("Using AddTourPredicate. ");
            if (string.IsNullOrEmpty(inputRouteName)) { return false; }
            return true;
        }

        public void modifyLog()
        {
            repository.modifyLog(inputRouteName, newDuration.Replace("h",""), newTopSpeed.Replace("km/h",""), newRating.Replace("/5",""), newReport, newDate);
        }

    }
}
