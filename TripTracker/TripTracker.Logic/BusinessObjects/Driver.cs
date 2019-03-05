using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic.BusinessObjects
{
    public class Driver : IPerson
    {
        public Driver()
        {
            Trips = new List<ITrip>();
        }

        public string Name { get; set; }
        public List<ITrip> Trips { get; set; }
    }
}
