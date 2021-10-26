using System;
using System.ComponentModel;
using System.Threading;

namespace ViewModel
{
    public class PopupNotificationViewModel
    {

        #region Singleton
        public Observable observable = new Observable();

        private static PopupNotificationViewModel _address = new PopupNotificationViewModel();
        public static PopupNotificationViewModel address { get { return _address; } }
        private PopupNotificationViewModel(){}
        #endregion

        private string _error;
        private string _visible = "Hidden";
        public string error { get { return _error; } set { _error = value; observable.OnPropertyChanged("error"); } }
        public string visible { get { return _visible; } set { _visible = value; observable.OnPropertyChanged("visible"); } }
        Thread _changeToHidden;
        int errorDuration = 1750; //-R

        public void displayError(string err)
        {
            error = err;
            visible = "Visible";

            if (_changeToHidden != null)
            {
                _changeToHidden.Interrupt();
                _changeToHidden = null;

            }
            _changeToHidden = new Thread(new ThreadStart(changeToHidden));
            _changeToHidden.Start();
        }

        public void changeToHidden()
        {
            try
            {
                Thread.Sleep(errorDuration);
                _error = null;
                visible = "Hidden";
            }
            catch (Exception)
            {
                return;
            }

        }
    }
}
