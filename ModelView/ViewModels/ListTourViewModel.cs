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
        public List<Model.ITour> routeList { get; } = new List<Model.ITour>();

        private ListTourViewModel()
        {
            //Dummy Data Start 
            routeList.Add(new Tour("My Route", "Route Description", "Route Information", 25, null, null, null));
            //Dummy Data End 
        }
    }
}
