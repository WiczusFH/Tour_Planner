using System;
using System.Windows.Media.Imaging;
using log4net;
using Model;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.ObjectModel;


namespace ViewModel
{
    public class AddLogsViewModel : Observable {
        #region Singleton
        public NotifyUser notifyUser = new NotifyUser();
        private static AddLogsViewModel _address = new AddLogsViewModel();
        public static AddLogsViewModel address { get { return _address; } }
        private log4net.ILog logging;
        #endregion

        #region Inputs
        string _inputLogTitle;
        public string inputLogTitle { get { return _inputLogTitle; } set { _inputLogTitle = value; addLogCommand.RaiseCanExecuteChanged(); } }
        string _inputRouteName;
        public string inputRouteName { get { return _inputRouteName; } set { _inputRouteName = value; addLogCommand.RaiseCanExecuteChanged(); } }

        public string inputDate { get; set; }
        public string inputDuration { get; set; }
        public string report { get; set; }
        public string topSpeed { get; set; }
        public string rating { get; set; }
        public RelayCommand addLogCommand { get; }

        Repository repository = Repository.address;
        List<ITour> _tourList;
        public List<ITour> tourList { get { return _tourList;  } set { _tourList = new List<Model.ITour>(repository.tourList); OnPropertyChanged("tourList"); } }
        #endregion

        #region Constructor
        private AddLogsViewModel()
        {
            tourList = repository.tourList;
            logging = LogManager.GetLogger(GetType());
            addLogCommand = new RelayCommand(addLog, addLogPredicate);
            repository.observable.PropertyChanged += (s, e) => { tourList = repository.tourList; OnPropertyChanged("tourList"); };

        }
        #endregion

        #region Predicates
        bool addLogPredicate(object obj)
        {
            if (!string.IsNullOrEmpty(inputLogTitle) && !string.IsNullOrEmpty(inputRouteName))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Button Actions
        public async void addLog()
        {
            logging.Info("Adding log: " + inputLogTitle);
            repository.addLog(inputLogTitle, inputRouteName, inputDuration, inputDate,report,rating,topSpeed);
        }
        #endregion

    }
}
