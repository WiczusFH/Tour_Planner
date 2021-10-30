using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ViewModel
{
    public class ExportViewModel : Observable
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();

        private static ExportViewModel _address = new ExportViewModel();
        public static ExportViewModel address { get { return _address; } }
        #endregion
        public List<Model.ITour> routeList { get; private set; }

        string _exportPath;
        public string exportPath { get { return _exportPath; } set { _exportPath = value; exportCommand.RaiseCanExecuteChanged(); } }


        string _inputRoute;
        public string inputRoute { get { return _inputRoute; } set { _inputRoute = value; exportCommand.RaiseCanExecuteChanged(); } }
        public RelayCommand exportCommand { get; private set; }
        Repository repository = Repository.address;
        private ExportViewModel()
        {
            exportCommand = new RelayCommand(export,exportPredicate);
            repository.observable.PropertyChanged += (s, e) => { routeList = new List<ITour>(repository.tourList); OnPropertyChanged("routeList"); };
            routeList = repository.tourList;
            OnPropertyChanged("routeList");
        }
        bool exportPredicate(object obj)
        {
            if (string.IsNullOrEmpty(inputRoute)||string.IsNullOrEmpty(exportPath))
            {
                return false;
            }
            return true;
        }

        void export()
        {
            try
            {
                repository.exportTour(inputRoute, exportPath);
            } catch { }
        }

    }
}
