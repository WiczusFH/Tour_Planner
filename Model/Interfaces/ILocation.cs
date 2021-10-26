using System;
using System.Windows.Media.Imaging;

namespace Model
{
    public interface ILocation
    {
        public string name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

    }
}
