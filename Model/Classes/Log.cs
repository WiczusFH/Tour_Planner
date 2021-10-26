using System;

namespace Model
{
    public class Log : ILog
    {
        public Log(string logTitle, string routeName, string dateString, float duration, IDate date, ITour tour, string report, float distance, uint rating, float averageSpeed, float topSpeed, float calories)
        {//-T tour?
            this.logTitle = logTitle;
            this.routeName = routeName;
            this.dateString = dateString;
            this.duration = duration;
            this.date = date;
            this.tour = tour;
            this.report = report;
            this.distance = distance;
            this.rating = rating;
            this.averageSpeed = averageSpeed;
            this.topSpeed = topSpeed;
            this.calories = calories;
        }

        public string logTitle { get; set; }
        public string routeName { get; set; }
        public string dateString { get; set; }
        public float duration { get; set; }
        public IDate date { get; set; }
        public ITour tour { get; set; }
        public string report { get; set; }
        public float distance { get; set; }
        public uint rating { get; set; }
        public float averageSpeed { get; set; }
        public float topSpeed { get; set; }
        public float calories { get; set; }
    }
}
