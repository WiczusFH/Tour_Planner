using System;

namespace DataAccess
{
    public interface ILog
    {
        public int id { get; set; }
        public string logTitle { get; set; }
        public int route_id { get; set; }
        public string report { get; set; }
        public float duration { get; set; }
        public uint rating { get; set; }
        public float averageSpeed { get; set; }
        public float topSpeed { get; set; }
        public float calories { get; set; }
        public string date { get; set; }

    }
}
