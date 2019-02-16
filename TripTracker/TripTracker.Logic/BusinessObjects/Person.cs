using System;
using System.Collections.Generic;
using System.Text;

namespace TripTracker.Logic.BusinessObjects
{
    public class Person : IPerson
    {
        public Person()
        {
            Trips = new List<Trip>();
        }

        public string Name { get; set; }

        public List<Trip> Trips { get; set; }
    }
}
