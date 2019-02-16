using System;
using TripTracker.Logic;

namespace TripTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var parms = Console.ReadLine();

                var result = Command.Parse(parms);


                //if (parms != null && (parms.Length != 2 || parms.Length != 5))
                //{
                //    Console.WriteLine("Please enter one of the following commands.");
                //    Console.WriteLine("Driver");
                //    Console.WriteLine("Usage: Driver <name>");
                //    Console.WriteLine("Example: Driver Dan");
                //    Console.WriteLine("Trip");
                //    Console.WriteLine("Usage: Trip <name> <start> <end> <distance>");
                //    Console.WriteLine("Example: Trip Dan 07:15 07:45 17.3");
                //    Console.WriteLine();
                //    Console.WriteLine();
                //    continue;
                //}


                break;
            }
        }
    }
}
