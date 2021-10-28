using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    enum TOUR_TABLE_COLUMNS
    {
        tour_id,
        name,
        sl_location_name,
        sl_location_x,
        sl_location_y,
        el_location_name,
        el_location_x,
        el_location_y,
        distance,
        description,
        information
    }
    enum LOGS_TABLE_COLUMNS
    {
        log_id,
        name,
        route_id,
        date,
        report,
        duration,
        averageSpeed,
        topSpeed,
        calories,
        rating
    }
}
