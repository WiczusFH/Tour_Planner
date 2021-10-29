﻿using System;
using log4net;
using System.Reflection;
namespace ViewModel
{
    public class MainViewModel
    {
        public PopupNotificationViewModel popupNotificationViewModel { get; } = PopupNotificationViewModel.address;
        public AddLogsViewModel addLogsViewModel { get; } = AddLogsViewModel.address;
        public AddToursViewModel addToursViewModel { get; } = AddToursViewModel.address;
        public ListLogsViewModel listLogsViewModel { get; } = ListLogsViewModel.address;
        public ListTourViewModel listTourViewModel { get; } = ListTourViewModel.address;
        public ReportViewModel reportViewModel { get; } = ReportViewModel.address;
        public MapViewModel mapViewModel { get; } = MapViewModel.address;
        public ModifyTourViewModel modifyTourViewModel{ get; } = ModifyTourViewModel.address;
        
        ILog Log = LogManager.GetLogger(typeof(MainViewModel));

        public MainViewModel()
        {
            Log.Info("Instantiated. ");

        }

    }
}
