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
        Repository repository = Repository.address;
        public List<Model.ILog> logList { get; } = new List<Model.ILog>();

        private ListLogsViewModel() {
            logList = repository.logList;
        }



    }
}
