using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Model;
using System.ComponentModel;

namespace ViewModel
{
    public class MapViewModel : Observable
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();
        private static MapViewModel _address = new MapViewModel();
        public static MapViewModel address { get { return _address;} }
        Repository repository = Repository.address;
        private MapViewModel() {

            repository.observable.PropertyChanged += (s, e) =>
            {
                map = repository.displayedImage;
            };
        }
        #endregion
        BitmapImage _map;
        public BitmapImage map { get { return _map; } private set { _map = value; OnPropertyChanged("map");} }

    }
}
