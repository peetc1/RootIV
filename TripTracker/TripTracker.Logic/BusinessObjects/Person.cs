﻿using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic.BusinessObjects
{
    public class Person : IPerson
    {
        public string Name { get; set; }
    }
}
