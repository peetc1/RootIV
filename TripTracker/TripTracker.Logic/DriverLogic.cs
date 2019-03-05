using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripTracker.Logic.BusinessObjects;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic
{
    public class DriverLogic : IDriverLogic
    {
        // theorertical database using repository pattern
        private List<Driver> Drivers { get; set; }

        public DriverLogic()
        {
            Drivers = new List<Driver>();
        }

        public void Save(Driver obj)
        {
            if (Drivers.All(d => d.Name != obj.Name))
            {
                Drivers.Add(obj);
            }
            else
            {
               // theorectical update
               Drivers.Replace(x => x.Name == obj.Name, obj);
            }
        }

        public Driver Get(string name)
        {
            return Drivers.FirstOrDefault(d => d.Name == name);
        }

        public IEnumerable<Driver> GetAll()
        {
            return Drivers;
        }
    }
}
