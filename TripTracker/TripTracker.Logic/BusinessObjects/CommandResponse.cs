using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic.BusinessObjects
{
    public class CommandResponse : ICommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
