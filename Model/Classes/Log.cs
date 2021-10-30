using System;
using System.Collections.Generic;

namespace Model
{
    public class Log : ILog
    {
        public Log(string logTitle, float duration, IDate date, ITour tour, string report, int rating, float averageSpeed, float topSpeed, float calories)
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

        public static Log fromStringInput(string inputLogTitle, string inputRouteName, string inputDuration, 
            string inputDate, string report, string inputrating, string inputtopspeed, List<Model.ITour> tourListModel)
        {
            float topSpeed = -1;
            float duration = -1;
            int rating = -1;
            Date date = new Date();
            try { duration = float.Parse(inputDuration); } catch (Exception e) { };
            try { topSpeed = float.Parse(inputtopspeed); } catch (Exception e) { };
            try { rating = int.Parse(inputrating); } catch (Exception e) { };
            try { date = Date.fromString(inputDate); } catch (Exception e) { };

            float averageSpeed = -1;
            float calories = -1;

            ITour tourToAdd = null;
            foreach (ITour tour in tourListModel)
            {
                if (tour.name == inputRouteName)
                {
                    tourToAdd = tour;
                    break;
                }
            }
            if (duration > 0)
            {
                averageSpeed = tourToAdd.distance / duration;
                calories = duration * 600 * averageSpeed / 13;
            }

            return new Model.Log(inputLogTitle, duration, date, tourToAdd, report, rating, averageSpeed, topSpeed, calories);
        }

        public string logTitle { get; set; }
        public float duration { get; set; }
        public IDate date { get; set; }
        public ITour tour { get; set; }
        public string report { get; set; }
        public int rating { get; set; }
        public float averageSpeed { get; set; }
        public float topSpeed { get; set; }
        public float calories { get; set; }

        #region String Outputs
        public string routeName { get { return tour.name; } }
        public string dateString { get { return date == null ? null : date.ToString(); } }
        public string distance { get { return tour==null? null : Math.Round(tour.distance,2).ToString()+"km"; } }
        public string durationString { get { return duration == -1 ? null : duration.ToString()+"h";  } }
        public string averageSpeedString { get { return averageSpeed == -1 ? null : Math.Round(averageSpeed,2).ToString()+"km/h";  } }
        public string topSpeedString { get { return topSpeed == -1 ? null : topSpeed.ToString() + "km/h";  } }
        public string caloriesString { get { return calories == -1 ? null : Math.Round(calories,2).ToString()+"kcal";  } }
        public string ratingString { get { return rating >=0 && rating<=5 ? rating.ToString()+"/5" : null;  } }
        #endregion


    }
}
