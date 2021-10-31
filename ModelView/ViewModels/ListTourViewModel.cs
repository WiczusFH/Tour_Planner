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

        string _filter;
        public string filter
        {
            get { return _filter; }
            set { _filter = value; repository.filterTours(_filter); }
        }
        Repository repository = Repository.address;
        public List<Model.ITour> routeList { get; private set; }
        public RelayCommandObj showMapCommand { get; }
        public RelayCommandObj deleteRouteCommand { get; }
        log4net.ILog logging = LogManager.GetLogger(typeof(ListTourViewModel));

        private ListTourViewModel()
        {
            routeList = repository.tourList;
            repository.observable.PropertyChanged += (s, e) => { routeList = new List<Model.ITour>(repository.tourList); OnPropertyChanged("routeList"); };
            showMapCommand = new RelayCommandObj(updateMap, (obj)=> { return true; });
            deleteRouteCommand = new RelayCommandObj(deleteRoute, (obj) => { return true; });
        }
        void updateMap(object obj) {
            int tourIndex;
            logging.Info("Updating map. ");

            try
            {
                tourIndex = Int32.Parse(obj.ToString());
            } catch(Exception e)
            {
                logging.Error("Parsing index failed. ");
                return;
            }
            repository.setImageFromTourId(tourIndex);
        }
        void deleteRoute(object obj)
        {
            int tourIndex;
            logging.Info("Deleting Route. ");
            try
            {
                tourIndex = Int32.Parse(obj.ToString());
            }
            catch (Exception e)
            {
                logging.Error("Parsing index failed. ");
                return;
            }
            repository.removeTour(tourIndex);
        }

    }
}
