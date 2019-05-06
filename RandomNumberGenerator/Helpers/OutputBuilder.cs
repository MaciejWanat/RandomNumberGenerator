using System;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Options;
using RandomNumberGenerator.Models;
using RandomNumberGenerator.Models.Settings;

namespace RandomNumberGenerator.Helpers
{
    public class OutputBuilder
    {
        private const string NumFormat = "N0";
        private readonly TestsSettings _testsSettings;

        public OutputBuilder(IOptions<TestsSettings> testsSettings)
        {
            _testsSettings = testsSettings.Value;
        }

        public void WriteOutput(TotalResults totalResults)
        {
            Console.WriteLine($"Testing distribution with the Chi Square tests:\n");
            Console.WriteLine($"Total draws: {_testsSettings.ChiTest.TotalDraws.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Expected distribution: {_testsSettings.ChiTest.SampleSize.ToString(NumFormat, CultureInfo.InvariantCulture)} for each number\n");

            foreach (var chiTestResult in totalResults.ChiTestResults)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"{chiTestResult.RngName}: \n{string.Join("\n", chiTestResult.ObservedDict.OrderBy(k => k.Key))}");
                Console.WriteLine($"\nPValue = {chiTestResult.PValue}");
                Console.WriteLine($"Significant = {chiTestResult.IsSignificant}");
                Console.WriteLine($"Time elapsed: {chiTestResult.TimeElapsedMs} milliseconds");
            }

            Console.WriteLine("---------------------------------");

            Console.WriteLine($"Testing mean:\n");
            Console.WriteLine($"Total samples: {_testsSettings.MeanTest.Samples.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Max value: {_testsSettings.MeanTest.Max}");
            Console.WriteLine($"Expected average: {_testsSettings.MeanTest.AvgExpected.ToString(NumFormat, CultureInfo.InvariantCulture)}\n");

            foreach (var meanResult in totalResults.MeanTestResults)
            {
                Console.WriteLine($"{meanResult.RngName}: {meanResult.AvgCalculated}");
                // Console.WriteLine($"Time elapsed: {meanResult.TimeElapsedMs} milliseconds");
            }

            Console.WriteLine("---------------------------------");
        }
    }
}
