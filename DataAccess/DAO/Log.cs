using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Log : ILog
    {
        public Log(int id, string logTitle, int route_id, string report, float duration, int rating, float averageSpeed, float topSpeed, float calories, string date)
        {
            this.id = id;
            this.logTitle = logTitle;
            this.route_id = route_id;
            this.report = report;
            this.duration = duration;
            this.rating = rating;
            this.averageSpeed = averageSpeed;
            this.topSpeed = topSpeed;
            this.calories = calories;
            this.date = date;
        }

        public int id {get; set; }
        public string logTitle {get; set; }
        public int route_id {get; set; }
        public string report {get; set; }
        public float duration {get; set; }
        public int rating {get; set; }
        public float averageSpeed {get; set; }
        public float topSpeed {get; set; }
        public float calories {get; set; }
        public string date {get; set; }
    }
}
