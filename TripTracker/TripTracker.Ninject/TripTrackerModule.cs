using System;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace TripTracker.Ninject
{
    public class TripTrackerModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x
                .From("TripTracker.Logic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                .SelectAllClasses() 
                .BindAllInterfaces() 
                .Configure(b => b.InSingletonScope())); 
        }
    }
}
