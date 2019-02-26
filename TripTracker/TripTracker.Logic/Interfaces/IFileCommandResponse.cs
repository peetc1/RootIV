using System;
using System.Collections.Generic;
using System.Text;

namespace TripTracker.Logic.Interfaces
{
    public interface IFileCommandResponse : ICommandResponse
    {
        string[] Lines { get; set; }
    }
}
