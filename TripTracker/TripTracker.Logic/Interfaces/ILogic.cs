using System;
using System.Collections.Generic;
using System.Text;

namespace TripTracker.Logic.Interfaces
{
    public interface ILogic<T>
    {
        void Save(T obj);
        T Get(string name);
    }
}
