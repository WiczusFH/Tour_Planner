using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Statistics
    {

        public static float getTotalTime(List<DataAccess.ILog> logListDA)
        {
            float totalTime = 0;
            foreach(DataAccess.ILog log in logListDA)
            {
                totalTime += log.duration;
            }
            return totalTime;
        }
        public static float getTotalDistance(List<DataAccess.ILog> logListDA, List<DataAccess.ITour> tourListDA)
        {
            float totalDistance = 0;
            foreach (DataAccess.ILog log in logListDA)
            {
                foreach(DataAccess.ITour tour in tourListDA)
                {
                    if(tour.id == log.route_id)
                    {
                        totalDistance += tour.distance;
                        break;
                    }
                }
            }
            return totalDistance;
        }
    }
}
