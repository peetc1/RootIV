using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TripTracker.Logic.BusinessObjects;

namespace TripTracker.Logic.Tests
{
    [TestFixture]
    public class LogicTests
    {
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
    }

}
