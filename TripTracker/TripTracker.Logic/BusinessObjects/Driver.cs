using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic.BusinessObjects
{
    public class Driver : IPerson
    {
        public Driver()
        {
            Trips = new List<Trip>();
        }

        public string Name { get; set; }
        public List<Trip> Trips { get; set; }

        public decimal TotalDistance => Trips.Sum(d => d.Distance);
        public decimal TotalHours => Trips.Sum(x => x.Hours);


        public override string ToString()
        {
            return TotalDistance > 0 ? $"{Name}: {Math.Round(TotalDistance, 0)} miles @ {Math.Round(TotalDistance / TotalHours, 0)} mph" : $"{Name}: {Math.Round(TotalDistance, 0)} miles";
        }
    }
}
