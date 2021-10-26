﻿using System;
using System.Windows.Media.Imaging;

namespace Model
{
    public interface ITour
    {
        public string name { get; set; }
        public string routeDescription { get; set; }
        public string routeInformation { get; set; }
        public float distance { get; set; }
        
        public BitmapImage image { get; set; }
        public ILocation startLocation { get; set; }
        public ILocation endLocation { get; set; }



    }
}
