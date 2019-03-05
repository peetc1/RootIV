using System;
using System.Collections.Generic;
using System.Text;

namespace TripTracker.Logic.Interfaces
{
    public interface ITrip : IPerson
    {
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        decimal Distance { get; set; }
        decimal MilesPerHour { get; }
    }
}
