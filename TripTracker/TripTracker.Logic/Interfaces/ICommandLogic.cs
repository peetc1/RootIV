using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.BusinessObjects;

namespace TripTracker.Logic.Interfaces
{
    public interface ICommandLogic
    {
        List<Driver> Parse(string[] commands);
        void ClearData();
    }
}
