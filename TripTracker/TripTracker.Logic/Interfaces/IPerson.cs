using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.BusinessObjects;

namespace TripTracker.Logic
{
    public interface IPerson
    {
        string Name { get; set; }
        List<Trip> Trips { get; set; }
    }
}
