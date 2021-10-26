using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Model;
using log4net;
using System.ComponentModel;

namespace ViewModel
{
    public class ListLogsViewModel
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();

        private static ListLogsViewModel _address = new ListLogsViewModel();
        public static ListLogsViewModel address { get { return _address; } }
        #endregion
        public List<Model.ILog> logList { get; } = new List<Model.ILog>();

        private ListLogsViewModel() {
            //Dummy Data Start 
            logList.Add(new Log("Log Title", "Route Name", "01.01.2021", 3.14f, new Date(), new Tour("My Route", "Route Description", "Route Information", 25, null, null, null), 
                "My report. ", 125000, 3, 30f,60f,2000f));
           //Dummy Data End 
        }



    }
}
