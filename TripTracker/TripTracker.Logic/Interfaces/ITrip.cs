using System;
using System.Collections.Generic;
using System.Text;

namespace TripTracker.Logic.Interfaces
{
    public interface ITrip
    {
        string Name { get; set; }
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        decimal Distance { get; set; }
    }
}
