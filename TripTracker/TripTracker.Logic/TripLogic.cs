using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripTracker.Logic.BusinessObjects;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic
{
    public class TripLogic : ITripLogic
    {
        // theorertical database using repository pattern
        private List<Trip> Trips { get; set; }

        public TripLogic()
        {
            Trips = new List<Trip>();
        }

        public void Save(Trip obj)
        {
            // no checking on trips as there could be multiple
            Trips.Add(obj);
        }

        public Trip Get(string name)
        {
            return Trips.FirstOrDefault(t => t.Name == name && t.MilesPerHour >= 5 && t.MilesPerHour <= 100);
        }

        public IEnumerable<Trip> GetByName(string name)
        {
            return Trips.Where(t => t.Name == name && t.MilesPerHour >= 5 && t.MilesPerHour <= 100);
        }
    }
}
