using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripTracker.Logic.BusinessObjects;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic
{
    public class TripLogic : ILogic<Trip>
    {
        private List<Trip> Trips { get; set; }

        public TripLogic()
        {
            Trips = new List<Trip>();
        }

        public void Add(Trip obj)
        {
            Trips.Add(obj);
        }

        public Trip Get(string name)
        {
            return Trips.FirstOrDefault(d => d.Name == name);
        }

        public IEnumerable<Trip> GetAll(string name)
        {
            return Trips.Where(d => d.Name == name);
        }
    }
}
