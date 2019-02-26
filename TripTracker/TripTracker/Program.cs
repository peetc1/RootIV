using System;
using System.Linq;
using TripTracker.Logic;

namespace TripTracker.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args == null || !args.Any() || args.Length != 1)
            {
                System.Console.WriteLine("No valid parameters supplied. Press Enter to exit");
                System.Console.ReadLine();
                return;
            }

            var result = FileParser.Parse(args[0]);
            System.Console.WriteLine($"File read {(result.Success ? "successfully" : "failed")}");
            System.Console.WriteLine(result.Message);
            System.Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            if (result.Success)
            {
                foreach (var line in result.Lines)
                {
                    System.Console.WriteLine(line);
                }
            }
            System.Console.ReadLine();
        }
    }
}
