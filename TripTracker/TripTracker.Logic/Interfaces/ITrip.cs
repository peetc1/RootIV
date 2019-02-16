using System;
using System.Collections.Generic;
using System.Text;

namespace TripTracker.Logic.Interfaces
{
    public interface ITrip
    {
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        decimal Distance { get; set; }
    }
}
