using System;

namespace Model
{
    public interface ILog
    {
        public string logTitle { get; set; }
        public float duration { get; set; }
        public IDate date { get; set; }
        public ITour tour { get; set; }
        public string report { get; set; }
        public int rating { get; set; }
        public float averageSpeed { get; set; }
        public float topSpeed { get; set; }
        public float calories { get; set; }


        public string routeName { get; }
        public string dateString { get; }
        public string distance { get; }
        public string durationString { get; }
        public string averageSpeedString { get; }
        public string topSpeedString { get; }
        public string caloriesString { get; }
        public string ratingString { get; }
    }
}
