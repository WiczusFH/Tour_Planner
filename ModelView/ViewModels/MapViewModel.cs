using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Model;
namespace ViewModel
{
    public class MapViewModel
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();
        private static MapViewModel _address = new MapViewModel();
        public static MapViewModel address { get { return _address;} }
        Repository repository = Repository.address;
        private MapViewModel() {
            updateMap(-1);
        }
        #endregion
        public BitmapImage map { get; private set; }

        public void updateMap(int id)
        {
            map = repository.getImage(id);
            observable.OnPropertyChanged("map");
        }
    }
}
