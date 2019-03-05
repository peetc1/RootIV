using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TripTracker.Logic.BusinessObjects;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic
{
    public class CommandLogic : ICommandLogic
    {
        private Regex driverRegex = new Regex(@"(Driver)\s{1}(?<name>\w+)", RegexOptions.Compiled);
        private Regex tripRegex = new Regex(@"(Trip)\s{1}(?<name>\w+)\s{1}(?<startTime>\d{2}\:\d{2})\s{1}(?<endTime>\d{2}\:\d{2})\s{1}(?<distance>\d+\.{1}\d+)", RegexOptions.Compiled);

        private readonly IDriverLogic _driverLogic;
        private readonly ITripLogic _tripLogic;

        public CommandLogic(IDriverLogic personLogic, ITripLogic tripLogic)
        {
            _driverLogic = personLogic;
            _tripLogic = tripLogic;
        }

        public List<Driver> Parse(string[] commands)
        {
            foreach (var command in commands)
            {
                var person = Parse(command);
                if (person != null)
                {
                    switch (person)
                    {
                        case Driver driver:
                            _driverLogic.Save(driver);
                            break;
                        case Trip trip:
                            _tripLogic.Save(trip);
                            break;
                    }
                }
                else
                {
                    // theoretical log of error
                    Console.WriteLine($"Error loading command: <{command}>");
                }
            }

            // we've added all trips and drivers time to combine them
            return CombineTripAndDriver();
        }

        private IPerson Parse(string command)
        {
            var person = default(IPerson);

            if (driverRegex.IsMatch(command))
            {
                var driver = driverRegex.Match(command);
                person = new Driver
                {
                    Name = driver.Groups["name"].Value
                };
            }

            if (tripRegex.IsMatch(command))
            {
                var trip = tripRegex.Match(command);
                person = new Trip
                {
                    Name = trip.Groups["name"].Value,
                    Distance = decimal.Parse(trip.Groups["distance"].Value),
                    StartTime = TimeSpan.Parse(trip.Groups["startTime"].Value),
                    EndTime = TimeSpan.Parse(trip.Groups["endTime"].Value)
                };
            }

            return person;
        }

        private List<Driver> CombineTripAndDriver()
        {
            var drivers = new List<Driver>();
            
            foreach (var driver in _driverLogic.GetAll())
            {
                driver.Trips = _tripLogic.GetByName(driver.Name).ToList();
                drivers.Add(driver);
            }

            return drivers;
        }

        public void ClearData()
        {
            _driverLogic.DeleteAll();
            _tripLogic.DeleteAll();
        }

        
    }
}
