using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic.BusinessObjects
{
    public class FileCommandResponse : IFileCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string[] Lines { get; set; }
    }
}
