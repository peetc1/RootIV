using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using NUnit.Framework;
using TripTracker.Logic.BusinessObjects;
using TripTracker.Logic.Interfaces;
using TripTracker.Ninject;

namespace TripTracker.Logic.Tests
{
    [TestFixture]
    public class LogicTests
    {
        private ICommandLogic _commandLogic;
        private IKernel _kernel;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _kernel = new StandardKernel(new TripTrackerModule());
            _commandLogic = _kernel.Get<ICommandLogic>();
        }

        [SetUp]
        public void Setup()
        {
            _commandLogic.ClearData();
        }

        [Test]
        public void BobNoTrips()
        {
            var driver = new Driver
            {
                Name = "Bob"
            };

            Assert.AreEqual("Bob: 0 miles", driver.ToString());
        }

        [Test]
        public void Dan2Trips()
        {
            var driver = new Driver
            {
                Name = "Dan",
                Trips = new List<Trip>
                {
                    new Trip {Distance = 17.3m, StartTime = TimeSpan.Parse("07:15"), EndTime = TimeSpan.Parse("07:45")},
                    new Trip {Distance = 21.8m, StartTime = TimeSpan.Parse("06:12"), EndTime = TimeSpan.Parse("06:32")}
                }
            };

            Assert.AreEqual("Dan: 39 miles @ 47 mph", driver.ToString());
        }

        [Test]
        public void AlexOneTrip()
        {
            var driver = new Driver
            {
                Name = "Alex",
                Trips = new List<Trip>
                {
                    new Trip {Distance = 42.0m, StartTime = TimeSpan.Parse("12:01"), EndTime = TimeSpan.Parse("13:16")}
                }
            };

            Assert.AreEqual("Alex: 42 miles @ 34 mph", driver.ToString());
        }

        [Test]
        public void MaxweirdTrips()
        {
            var driver = new Driver
            {
                Name = "Max",
                Trips = new List<Trip>
                {
                    new Trip {Distance = 99.9m, StartTime = TimeSpan.Parse("12:01"), EndTime = TimeSpan.Parse("13:16")},
                    new Trip {Distance = 6.0m, StartTime = TimeSpan.Parse("12:01"), EndTime = TimeSpan.Parse("13:01")}
                }  
            };

            Assert.AreEqual("Max: 106 miles @ 47 mph", driver.ToString());
        }

        [Test]
        public void MadMaxInvalidTrips()
        {
            string[] trips =
            {
                "Driver MadMax",
                "Trip MadMax 12:01 13:16 99.9",
                "Trip MadMax 12:01 13:16 210.0", // this should be ignored
                "Trip MadMax 12:01 13:16 5.0", // this should be ignored
                "Trip MadMax 12:01 13:01 6.0",
            };

            var drivers = _commandLogic.Parse(trips);

            Assert.AreEqual("MadMax: 106 miles @ 47 mph", drivers.First().ToString());
        }

        [Test]
        public void AlexInvalidDriver()
        {
            string[] trips =
            {
                "Driver Alex",
                "Trip Alex 12:01 13:16 42.0",
                "Trip Jon 12:01 13:16 99.9", // this should be ignored
                "Trip Jon 12:01 13:16 210.0", // this should be ignored
                "Trip Jon 12:01 13:16 5.0", // this should be ignored
                "Trip Jon 12:01 13:01 6.0" // this should be ignored
            };

            var drivers = _commandLogic.Parse(trips);

            Assert.False(drivers.Any(x => x.Name == "Jon"));
            Assert.AreEqual("Alex: 42 miles @ 34 mph", drivers.First().ToString());
        }
    }

}
