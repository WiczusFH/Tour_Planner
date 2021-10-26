using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MapViewModel
    {
        #region Singleton
        public Observable observable = new Observable();
        public NotifyUser notifyUser = new NotifyUser();
        private static MapViewModel _address = new MapViewModel();
        public static MapViewModel address { get { return _address; } }
        private MapViewModel() { 
        }
        #endregion

       
    }
}
