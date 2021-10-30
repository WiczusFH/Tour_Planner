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
        public string inputRouteName { get { return _inputRouteName; } set { _inputRouteName = value; generateTourReportCommand.RaiseCanExecuteChanged(); } }
        Repository repository = Repository.address;
        ObservableCollection<ITour> _tourList;
        public ObservableCollection<ITour> tourList { get { return _tourList; } set { _tourList = value; observable.OnPropertyChanged("tourList"); } }
        public RelayCommand generateTourReportCommand { get; }
        public RelayCommand generateLogReportCommand { get; }

        ReportViewModel() { 
            tourList = new ObservableCollection<ITour>(repository.tourList);
            generateTourReportCommand = new RelayCommand(generateTourReport, generateReportPredicate);
            generateLogReportCommand = new RelayCommand(generateLogReport, (obj)=> { return true; });

        }
        bool generateReportPredicate(object obj)
        {

            if (string.IsNullOrEmpty(inputRouteName)) { return false; }
            return true;
        }

        public void generateTourReport()
        {
            repository.generateTourReport();
        }
        public void generateLogReport()
        {
            repository.generateLogReport();
        }

    }
}
