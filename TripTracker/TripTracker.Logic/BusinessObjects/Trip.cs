using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic.BusinessObjects
{
    public class Trip : ITrip
    {
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Distance { get; set; }

        public decimal Hours => decimal.Parse(EndTime.Subtract(StartTime).TotalSeconds.ToString()) / 3600m;
        public decimal MilesPerHour => Distance/Hours;
    }
}
