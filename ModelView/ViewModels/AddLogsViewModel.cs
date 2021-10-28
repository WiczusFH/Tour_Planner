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
    public class AddLogsViewModel {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();
        private static AddLogsViewModel _address = new AddLogsViewModel();
        public static AddLogsViewModel address { get { return _address; } }
        private log4net.ILog log;
        #endregion

        #region Inputs
        string _inputLogTitle;
        public string inputLogTitle { get { return _inputLogTitle; } set { _inputLogTitle = value; addLogCommand.RaiseCanExecuteChanged(); } }
        string _inputRouteName;
        public string inputRouteName { get { return _inputRouteName; } set { _inputRouteName = value; addLogCommand.RaiseCanExecuteChanged(); } }

        public string inputDate { get; set; }
        public string inputDuration { get; set; }
        public RelayCommand addLogCommand { get; }

        Repository repository = Repository.address;
        ObservableCollection<ITour> _tourList;
        public ObservableCollection<ITour> tourList { get { return _tourList;  } set { _tourList=value; observable.OnPropertyChanged("tourList"); } }
        #endregion

        #region Constructor
        private AddLogsViewModel()
        {
            tourList = new ObservableCollection<ITour>(repository.tourList);
            log = LogManager.GetLogger(GetType());
            log.Info("Tours View Model instantiated. ");
            addLogCommand = new RelayCommand(addLog, addLogPredicate);

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
            throw new NotImplementedException();
        }
        #endregion

    }
}
