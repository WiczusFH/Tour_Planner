using System;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System.Reflection;
using Model;
using System.Text;
using System.IO;

namespace ViewModel
{
    public class MainViewModel
    {
        #region ViewModels
        public PopupNotificationViewModel popupNotificationViewModel { get; } = PopupNotificationViewModel.address;
        public AddLogsViewModel addLogsViewModel { get; } = AddLogsViewModel.address;
        public AddToursViewModel addToursViewModel { get; } = AddToursViewModel.address;
        public ListLogsViewModel listLogsViewModel { get; } = ListLogsViewModel.address;
        public ListTourViewModel listTourViewModel { get; } = ListTourViewModel.address;
        public ReportViewModel reportViewModel { get; } = ReportViewModel.address;
        public MapViewModel mapViewModel { get; } = MapViewModel.address;
        public ModifyTourViewModel modifyTourViewModel{ get; } = ModifyTourViewModel.address;
        public ModifyLogViewModel modifyLogViewModel{ get; } = ModifyLogViewModel.address;
        public ExportViewModel exportViewModel { get; } = ExportViewModel.address;
        public Repository repository { get; } = Repository.address;

        #endregion
        log4net.ILog Log = LogManager.GetLogger(typeof(MainViewModel));

        public MainViewModel()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PatternLayout patternLayout = new PatternLayout
            {
                ConversionPattern = "%date %stacktrace{3}%newline %message%newline%newline"
            };
            patternLayout.ActivateOptions();
            var coloredConsoleAppender = new ColoredConsoleAppender();
            coloredConsoleAppender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                BackColor = ColoredConsoleAppender.Colors.Red,
                ForeColor = ColoredConsoleAppender.Colors.White,
                Level = Level.Error
            });
            coloredConsoleAppender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                ForeColor = ColoredConsoleAppender.Colors.White,
                Level = Level.Debug
            });
            coloredConsoleAppender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                ForeColor = ColoredConsoleAppender.Colors.White,
                Level = Level.Info
            });
            coloredConsoleAppender.Layout = patternLayout;
            coloredConsoleAppender.ActivateOptions();
            BasicConfigurator.Configure(coloredConsoleAppender);
            Log.Info("Instantiated. ");
            repository.loadTourLogData();
        }

    }
}
