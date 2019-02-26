using System;
using System.Collections.Generic;
using System.Text;

namespace TripTracker.Logic.Interfaces
{
    public interface ICommandResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
