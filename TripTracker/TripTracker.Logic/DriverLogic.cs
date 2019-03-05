using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripTracker.Logic.BusinessObjects;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic
{
    public class DriverLogic : ILogic<Driver>
    {
        private List<Driver> Drivers { get; set; }

        public DriverLogic()
        {
            Drivers = new List<Driver>();
        }

        public void Add(Driver obj)
        {
            Drivers.Add(obj);
        }

        public Driver Get(string name)
        {
            return Drivers.FirstOrDefault(d => d.Name == name);
        }

        public IEnumerable<Driver> GetAll(string name)
        {
            throw new NotImplementedException();
        }
    }
}
