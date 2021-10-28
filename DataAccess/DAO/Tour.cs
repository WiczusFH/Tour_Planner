using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Tour : ITour
    {
        public Tour(string name, float distance, string sl_name, float sl_x, float sl_y, string el_name, float el_x, float el_y, int id = -1, string routeDescription=null, string routeInformation=null)
        {
            this.id = id;
            this.name = name;
            this.routeDescription = routeDescription;
            this.routeInformation = routeInformation;
            this.distance = distance;
            this.sl_name = sl_name;
            this.sl_x = sl_x;
            this.sl_y = sl_y;
            this.el_name = el_name;
            this.el_x = el_x;
            this.el_y = el_y;
        }

        public int id { get; set;}
        public string name { get; set;}
        public string routeDescription { get; set;}
        public string routeInformation { get; set;}
        public float distance { get; set;}
        public string sl_name { get; set;}
        public float sl_x { get; set;}
        public float sl_y { get; set;}
        public string el_name { get; set;}
        public float el_x { get; set;}
        public float el_y { get; set;}
    }
}
