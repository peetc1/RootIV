using System;
using NUnit.Framework;

namespace TripTracker.Logic.Tests
{
    [TestFixture]
    public class FileReadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //var test = "Trip Dan 07:15 07:45 17.3";
            var start = TimeSpan.Parse("07:15");
            var test = new TimeSpan(7,15,0);

            Assert.AreEqual(test, start);
        }

        [Test]
        public void Test2()
        {
            //var test = "Trip Dan 07:15 07:45 17.3";
            var start = TimeSpan.Parse("07:15");
            var test = new TimeSpan(7, 15, 0);

            Assert.AreEqual(test, start);
        }
    }
}