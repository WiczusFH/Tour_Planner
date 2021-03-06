using System;
using log4net;
using Model;
using System.ComponentModel;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ViewModel
{
    public class ModifyTourViewModel : Observable
    {
        #region Singleton
        public NotifyUser notifyUser = new NotifyUser();

        private static ModifyTourViewModel _address = new ModifyTourViewModel();
        public static ModifyTourViewModel address { get { return _address; } }

        private log4net.ILog log;

        Repository repository = Repository.address;
        #endregion

        #region variables
        public List<ITour> tourList { get; private set; }
        public string newDescription { get; set; }
        public string newInformation { get; set; }
        string _inputRouteName;
        public string inputRouteName { get { return _inputRouteName; } set {
                foreach (ITour tour in tourList)
                {
                    _inputRouteName = value;
                    if (tour.name == value)
                    {
                        newDescription = tour.routeDescription; OnPropertyChanged("newDescription");
                        newInformation = tour.routeInformation; OnPropertyChanged("newInformation");
                        modifyCommand.RaiseCanExecuteChanged();
                        break;
                    }
                }
            } }
        #endregion

        #region Commands
        public RelayCommand modifyCommand { get; private set; }
        #endregion
        private ModifyTourViewModel() {
            log = LogManager.GetLogger(GetType());
            modifyCommand = new RelayCommand(modifyTour, modifyCommandPredicate);
            tourList = repository.tourList;
            repository.observable.PropertyChanged += (s, e) => { tourList = new List<Model.ITour>(repository.tourList); OnPropertyChanged("tourList"); };
            OnPropertyChanged("tourList");

            modifyCommand.RaiseCanExecuteChanged();
        }
        bool modifyCommandPredicate(object obj)
        {
            if (string.IsNullOrEmpty(inputRouteName)) { return false; }
            return true;
        }

        public void modifyTour()
        {
            repository.modifyTour(inputRouteName, newDescription, newInformation);
        }

    }
}
