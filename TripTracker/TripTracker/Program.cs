using System;
using System.Linq;
using Ninject;
using TripTracker.Logic;
using TripTracker.Logic.Interfaces;
using TripTracker.Ninject;

namespace TripTracker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel(new TripTrackerModule());
            var commandLogic = kernal.Get<ICommandLogic>();
            if (args == null || !args.Any() || args.Length != 1)
            {
                System.Console.WriteLine("No valid parameters supplied. Press Enter to exit");
                System.Console.ReadLine();
                return;
            }

            var result = FileParser.Parse(args[0]);
            System.Console.WriteLine($"File read {(result.Success ? "successfully" : "failed")}");
            System.Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            if (result.Success)
            {
                var drivers = commandLogic.Parse(result.Lines).OrderByDescending(x => x.TotalDistance);
                foreach (var driver in drivers)
                {
                    System.Console.WriteLine(driver.ToString());
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
            System.Console.ReadLine();
        }
    }
}
