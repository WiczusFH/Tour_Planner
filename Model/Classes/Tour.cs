using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Model
{
    public class Tour : ITour
    {
        public Tour(string name, string routeDescription, string routeInformation, float distance, BitmapImage image, string startLocation, string endLocation)
        {
            this.name = name;
            this.routeDescription = routeDescription;
            this.routeInformation = routeInformation;
            this.distance = distance;
            this.image = image;
            this.startLocation = startLocation;
            this.endLocation = endLocation;
        }

        public string name { get; set; }
        public string routeDescription { get; set; }
        public string routeInformation { get; set; }
        public float distance { get; set; }
        public BitmapImage image { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get; set; }

    }
}
