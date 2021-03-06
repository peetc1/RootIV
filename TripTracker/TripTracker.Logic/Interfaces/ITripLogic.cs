﻿using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.BusinessObjects;

namespace TripTracker.Logic.Interfaces
{
    public interface ITripLogic : ILogic<Trip>
    {
        IEnumerable<Trip> GetByName(string name);
    }
}
