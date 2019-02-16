using System;
using System.Collections.Generic;
using System.Text;

namespace TripTracker.Logic.Interfaces
{
    public interface ILogic<T>
    {
        void Add(T obj);

    }
}
