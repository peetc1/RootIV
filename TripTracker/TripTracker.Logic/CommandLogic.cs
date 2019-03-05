using System;
using System.Collections.Generic;
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

        private readonly IDriverLogic _personLogic;
        private readonly ITripLogic _tripLogic;

        public CommandLogic(IDriverLogic personLogic, ITripLogic tripLogic)
        {
            _personLogic = personLogic;
            _tripLogic = tripLogic;
        }

        public List<Driver> Parse(string[] commands)
        {
            foreach (var command in commands)
            {
                Parse(command);
            }
            return new List<Driver>();
        }

        public Driver Parse(string command)
        {
            var driver = new Driver();


            return driver;
        }
    }
}
