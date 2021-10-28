using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Model;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class ReportViewModel
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();

        private static ReportViewModel _address = new ReportViewModel();
        public static ReportViewModel address { get { return _address; } }
        #endregion

        string _inputRouteName;
        public string inputRouteName { get { return _inputRouteName; } set { _inputRouteName = value; generateReportCommand.RaiseCanExecuteChanged(); } }
        Repository repository = Repository.address;
        ObservableCollection<ITour> _tourList;
        public ObservableCollection<ITour> tourList { get { return _tourList; } set { _tourList = value; observable.OnPropertyChanged("tourList"); } }
        public RelayCommand generateReportCommand { get; }

        ReportViewModel() { 
            tourList = new ObservableCollection<ITour>(repository.tourList);
            generateReportCommand = new RelayCommand(generateReport, generateReportPredicate);

        }
        bool generateReportPredicate(object obj)
        {

            if (string.IsNullOrEmpty(inputRouteName)) { return false; }
            return true;
        }

        public void generateReport()
        {
            throw new NotImplementedException();
        }


    }
}
