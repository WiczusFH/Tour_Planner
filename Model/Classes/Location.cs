using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Model
{
    public class Location : ILocation
    {
        public string name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
