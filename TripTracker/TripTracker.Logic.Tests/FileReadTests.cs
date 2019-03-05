using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TripTracker.Logic.BusinessObjects;

namespace TripTracker.Logic.Tests
{
    [TestFixture]
    public class FileReadTests
    {
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