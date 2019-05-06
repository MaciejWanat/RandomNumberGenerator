using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Accord.Statistics.Testing;
using RandomNumberGenerator.Models;
using RandomNumberGenerator.RNG;

namespace RandomNumberGenerator
{
    public static class TestRng
    {
        public static ChiTestResult ChiTest<T>(T rng) where T: IRngInterface
        {
            var stopwatch = Stopwatch.StartNew();

            double sampleSize = 100000;
            var numsAmount = 10;
            var totalDraws = sampleSize * numsAmount;

            var observedDict = new Dictionary<int, int>();
            for (var i = 0; i < totalDraws; i++)
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

            return new ChiTestResult
            {
                IsSignificant = significant,
                ObservedDict = observedDict,
                PValue = pValue,
                RngName = rng.Name,
                SampleSize = sampleSize,
                TimeElapsedMs = stopwatch.ElapsedMilliseconds,
                TotalDraws = totalDraws
            };
        }

        public static MeanTestResult MeanTest<T>(T rng) where T : IRngInterface
        {
            var stopwatch = Stopwatch.StartNew();

            var sum = new long();
            var samples = 1000000;
            var max = 1000;

            for (var i = 0; i < samples; i++)
            {
                sum += rng.Next(max);
            }

            var avg = (double) sum / samples;
            var avgExpected = max / 2;

            stopwatch.Stop();

            return new MeanTestResult
            {
                AvgExpected = avgExpected,
                AvgCalculated = avg,
                TimeElapsedMs = stopwatch.ElapsedMilliseconds,
                Max = max,
                Samples = samples,
                RngName = rng.Name
            };
        }
    }
}
