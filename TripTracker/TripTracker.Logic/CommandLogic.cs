using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic
{
    public class CommandLogic : ICommandLogic
    {
        private readonly IPersonLogic _personLogic;
        private readonly ITripLogic _tripLogic;

        public CommandLogic(IPersonLogic personLogic, ITripLogic tripLogic)
        {
            _personLogic = personLogic;
            _tripLogic = tripLogic;
        }
    }
}
