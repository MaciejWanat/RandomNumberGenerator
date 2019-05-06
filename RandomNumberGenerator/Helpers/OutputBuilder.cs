using System;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Options;
using RandomNumberGenerator.Models;
using RandomNumberGenerator.Models.Settings;

namespace RandomNumberGenerator.Helpers
{
    public class OutputBuilder : IOutputBuilder
    {
        private const string NumFormat = "N0";
        private readonly TestsSettings _testsSettings;

        public OutputBuilder(IOptions<TestsSettings> testsSettings)
        {
            _testsSettings = testsSettings.Value;
        }

        public void WriteOutput(TotalResults results)
        {
            WriteChi(results);
            Console.WriteLine("---------------------------------");
            WriteMean(results);
            Console.WriteLine("---------------------------------");
            WriteTime(results);
            Console.WriteLine("---------------------------------");
            WriteStandardDeviation(results);
        }

        private void WriteChi(TotalResults results)
        {
            Console.WriteLine($"Testing distribution with the Chi Square tests:\n");
            Console.WriteLine($"Total draws: {_testsSettings.ChiTest.TotalDraws.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Expected distribution: {_testsSettings.ChiTest.SampleSize.ToString(NumFormat, CultureInfo.InvariantCulture)} for each number\n");

            foreach (var chiTestResult in results.ChiTestResults)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"{chiTestResult.RngName}: \n{string.Join("\n", chiTestResult.ObservedDict.OrderBy(k => k.Key))}");
                Console.WriteLine($"\nPValue = {chiTestResult.PValue}");
                Console.WriteLine($"Significant = {chiTestResult.IsSignificant}");
            }
        }

        private void WriteMean(TotalResults results)
        {
            Console.WriteLine($"Testing mean:\n");
            Console.WriteLine($"Total samples: {_testsSettings.MeanTest.Samples.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Max value: {_testsSettings.MeanTest.Max.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Expected average: {_testsSettings.MeanTest.AvgExpected.ToString(NumFormat, CultureInfo.InvariantCulture)}\n");

            foreach (var meanResult in results.MeanTestResults)
            {
                Console.WriteLine($"{meanResult.RngName}: {meanResult.AvgCalculated}, Error = {meanResult.Error}");
            }
        }

        private void WriteTime(TotalResults results)
        {
            Console.WriteLine($"Testing time:\n");
            Console.WriteLine($"Total samples: {_testsSettings.TimeTest.Samples.ToString(NumFormat, CultureInfo.InvariantCulture)}\n");

            foreach (var timeResult in results.TimeTestResults)
            {
                Console.WriteLine($"{timeResult.RngName}: {timeResult.TimeElapsedMs} ms");
            }
        }

        private void WriteStandardDeviation(TotalResults results)
        {
            Console.WriteLine($"Testing standard deviation:\n");
            Console.WriteLine($"Total samples: {_testsSettings.StandardDeviationTest.Samples.ToString(NumFormat, CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Max value: {_testsSettings.StandardDeviationTest.Max.ToString(NumFormat, CultureInfo.InvariantCulture)}\n");

            foreach (var standardDeviationResult in results.StandardDeviationTestResults)
            {
                Console.WriteLine($"{standardDeviationResult.RngName}: {standardDeviationResult.StandardDeviation.ToString("0.00", CultureInfo.InvariantCulture)}");
            }
        }
    }
}
