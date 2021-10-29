using System;
using log4net;
using Model;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class ListTourViewModel : Observable
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();

        private static ListTourViewModel _address = new ListTourViewModel();
        public static ListTourViewModel address { get { return _address; } }
        #endregion
        Repository repository = Repository.address;
        public List<Model.ITour> routeList { get; private set; }
        public RelayCommandObj showMapCommand { get; }
        public RelayCommandObj deleteRouteCommand { get; }
        private ListTourViewModel()
        {
            routeList = repository.tourList;
            repository.observable.PropertyChanged += (s, e) => { routeList = new List<Model.ITour>(repository.tourList); OnPropertyChanged("routeList"); };
            showMapCommand = new RelayCommandObj(updateMap, (obj)=> { return true; });
            deleteRouteCommand = new RelayCommandObj(deleteRoute, (obj) => { return true; });
        }
        void updateMap(object obj) {
            int tourIndex = Int32.Parse(obj.ToString());
            repository.setImageFromTourId(tourIndex);
        }
        void deleteRoute(object obj)
        {
            int tourIndex = Int32.Parse(obj.ToString());
            repository.removeTour(tourIndex);
        }

    }
}
