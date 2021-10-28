using System;

namespace DataAccess
{
    public interface ITour
    {
        public int id { get; set; }
        public string name { get; set; }
        public string routeDescription { get; set; }
        public string routeInformation { get; set; }
        public float distance { get; set; }
        
        public string sl_name{ get; set; }
        public float sl_x { get; set; }
        public float sl_y { get; set; }
        public string el_name { get; set; }
        public float el_x { get; set; }
        public float el_y { get; set; }



    }
}
