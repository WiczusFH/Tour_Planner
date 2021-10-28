using System;

namespace Model
{
    public class Log : ILog
    {
        public Log(string logTitle, float duration, IDate date, ITour tour, string report, uint rating, float averageSpeed, float topSpeed, float calories)
        { 
            this.logTitle = logTitle;
            this.duration = duration;
            this.date = date;
            this.tour = tour;
            this.report = report;
            this.rating = rating;
            this.averageSpeed = averageSpeed;
            this.topSpeed = topSpeed;
            this.calories = calories;
        }

        public string logTitle { get; set; }
        public string routeName { get { return tour.name; } }
        public string dateString { get { return date.ToString(); } }
        public float distance { get { return tour.distance;  } }
        public float duration { get; set; }
        public IDate date { get; set; }
        public ITour tour { get; set; }
        public string report { get; set; }
        public uint rating { get; set; }
        public float averageSpeed { get; set; }
        public float topSpeed { get; set; }
        public float calories { get; set; }
    }
}
