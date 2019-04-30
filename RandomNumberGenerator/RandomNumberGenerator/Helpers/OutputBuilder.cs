using System;
using System.Linq;
using RandomNumberGenerator.Models;

namespace RandomNumberGenerator.Helpers
{
    public static class OutputBuilder
    {
        public static void WriteOutput(ChiTestResult result)
        {
            Console.WriteLine($"Testing distribution with the Chi Square test for the {result.RngName}:\n");
            Console.WriteLine($"Expected distribution: {result.SampleSize} for each number");
            Console.WriteLine($"Observed distribution: \n{string.Join("\n", result.ObservedDict.OrderBy(k => k.Key))}");
            Console.WriteLine($"\nPValue = {result.PValue}");
            Console.WriteLine($"Significant = {result.IsSignificant}");
            Console.WriteLine($"Time elapsed: {result.TimeElapsedMs} miliseconds");
            Console.WriteLine("---------------------------------");
        }
    }
}
