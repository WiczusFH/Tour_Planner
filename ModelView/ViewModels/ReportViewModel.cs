using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Model;
using System.ComponentModel;
namespace ViewModel
{
    public class ReportViewModel
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();

        private static ReportViewModel _address = new ReportViewModel();
        public static ReportViewModel address { get { return _address; } }
        private ReportViewModel() { }
        #endregion
    }
}
