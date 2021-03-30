using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuh_Simulator_2._0
{
    class GPSLocation
    {
        private double longitude;
        private double latitude;
        private double altitude;

        public GPSLocation(double longitude, double latitude, double altitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.altitude = altitude;
        }
    }
}
