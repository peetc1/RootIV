using System;
using System.IO;
using System.Linq;
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
        public void DirectoryThatDoesntExist()
        {
            var response = FileParser.Parse(@"C:\FakePath\NoFileHere.txt");

            Assert.NotNull(response);
            Assert.False(response.Success);
            Assert.Null(response.Lines);
            Assert.True(response.Message.StartsWith("Could not find a part of the path"));
        }

        [Test]
        public void FileThatDoesntExist()
        {
            var response = FileParser.Parse($@"{Environment.CurrentDirectory}NoFileHere.txt");

            Assert.NotNull(response);
            Assert.False(response.Success);
            Assert.Null(response.Lines);
            Assert.True(response.Message.StartsWith("Could not find file"));
        }

        [Test]
        public void FIleExists()
        {
            var response = FileParser.Parse($@"{Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"))}Test.txt");

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Lines);
            Assert.IsNotEmpty(response.Lines);
            Assert.AreEqual(6, response.Lines.Length);
        }
    }
}