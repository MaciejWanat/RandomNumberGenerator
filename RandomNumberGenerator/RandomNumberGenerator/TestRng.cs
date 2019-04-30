using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Accord.Statistics.Testing;
using RandomNumberGenerator.RNG;

namespace RandomNumberGenerator
{
    public static class TestRng
    {
        public static void TestChi<T>(T rng) where T: IRngInterface
        {
            Console.WriteLine($"Testing distribution with the Chi Square test for the {rng.Name}:\n");

            var stopwatch = Stopwatch.StartNew();

            double sampleSize = 100000;
            var numsAmount = 10;

            var observedDict = new Dictionary<int, int>();
            for (var i = 0; i < sampleSize * numsAmount; i++)
            {
                var num = rng.Next(numsAmount);

                if (observedDict.ContainsKey(num))
                {
                    observedDict[num]++;
                }
                else
                {
                    observedDict[num] = 1;
                }
            }

            var observed = Enumerable.Repeat((double) 0, numsAmount).ToArray();
            for (var i = 0; i < numsAmount; i++)
            {
                if (observedDict.ContainsKey(i))
                {
                    observed[i] = observedDict[i];
                }
            }

            var expectedEnumerable = Enumerable.Repeat(sampleSize, numsAmount);
            var expected = expectedEnumerable.ToArray();

            var degreesOfFreedom = 1;
            var chi = new ChiSquareTest(expected, observed, degreesOfFreedom);

            var pValue = chi.PValue;
            var significant = chi.Significant;
            stopwatch.Stop();

            Console.WriteLine($"Expected distribution: {sampleSize} for each number");
            Console.WriteLine($"Observed distribution: \n{string.Join("\n", observedDict.OrderBy(k => k.Key))}");
            Console.WriteLine($"\nPValue = {pValue}");
            Console.WriteLine($"Significant = {significant}");
            Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} miliseconds");
            Console.WriteLine("---------------------------------");

        }
    }
}
