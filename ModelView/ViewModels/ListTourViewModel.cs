using System;
using log4net;
using Model;
using System.ComponentModel;
using System.Collections.Generic;

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

        private ListTourViewModel()
        {
            repository.observable.PropertyChanged += (s,e) => { routeList = repository.tourList; OnPropertyChanged("routeList"); };
            repository.setTours();
            showMapCommand = new RelayCommandObj(updateMap, showMapPredicate);
        }

        bool showMapPredicate(object obj)
        {
            return true;
        }
        void updateMap(object obj) {
            int tourIndex = Int32.Parse(obj.ToString());
            repository.setImageFromId(tourIndex);
        }

    }
}
