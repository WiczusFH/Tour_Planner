using System;
using log4net;
using Model;
using System.ComponentModel;
using System.Collections.Generic;

namespace ViewModel
{
    public class ListTourViewModel
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();

        private static ListTourViewModel _address = new ListTourViewModel();
        public static ListTourViewModel address { get { return _address; } }
        #endregion
        Repository repository = Repository.address;
        public List<Model.ITour> routeList { get; private set; }

        private ListTourViewModel()
        {
            repository.observable.PropertyChanged += (s,e) => { routeList = repository.tourList; this.observable.OnPropertyChanged("routeList"); };
            repository.setTours();
            //Console.WriteLine(routeList[0].distance);
        }
    }
}
