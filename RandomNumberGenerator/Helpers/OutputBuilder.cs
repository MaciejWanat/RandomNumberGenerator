using System;
using System.Globalization;
using System.Linq;
using RandomNumberGenerator.Models;

namespace RandomNumberGenerator.Helpers
{
    public static class OutputBuilder
    {
        private const string NumFormat = "N0";

        public static void WriteOutput(ChiTestResult result)
        {
            Console.WriteLine($"Testing distribution with the Chi Square test for the {result.RngName}:\n");
            Console.WriteLine($"Total draws: {result.TotalDraws.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Expected distribution: {result.SampleSize.ToString(NumFormat, CultureInfo.InvariantCulture)} for each number");
            Console.WriteLine($"Observed distribution: \n{string.Join("\n", result.ObservedDict.OrderBy(k => k.Key))}");
            Console.WriteLine($"\nPValue = {result.PValue}");
            Console.WriteLine($"Significant = {result.IsSignificant}");
            Console.WriteLine($"Time elapsed: {result.TimeElapsedMs} milliseconds");
            Console.WriteLine("---------------------------------");
        }

        public static void WriteOutput(MeanTestResult result)
        {
            Console.WriteLine($"Testing mean for the {result.RngName}:\n");
            Console.WriteLine($"Total samples: {result.Samples.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Max value: {result.Max}");
            Console.WriteLine($"Expected average: {result.AvgExpected.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Observed average: {result.AvgCalculated}");
            Console.WriteLine($"Time elapsed: {result.TimeElapsedMs} milliseconds");
            Console.WriteLine("---------------------------------");
        }
    }
}
