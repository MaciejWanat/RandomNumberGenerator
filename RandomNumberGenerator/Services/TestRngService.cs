﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Accord.Statistics.Testing;
using Microsoft.Extensions.Options;
using RandomNumberGenerator.Models;
using RandomNumberGenerator.Models.Settings;
using RandomNumberGenerator.RNG;

namespace RandomNumberGenerator.Services
{
    public class TestRngService : ITestRngService
    {
        private readonly TestsSettings _testsSettings;

        public TestRngService(IOptions<TestsSettings> testsSettings)
        {
            _testsSettings = testsSettings.Value;
        }

        public ChiTestResult ChiTest<T>(T rng) where T: IRngInterface
        {
            var stopwatch = Stopwatch.StartNew();

            double sampleSize = _testsSettings.ChiTest.SampleSize;
            var numsAmount = _testsSettings.ChiTest.NumsAmount;
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

            var degreesOfFreedom = _testsSettings.ChiTest.DegreesOfFreedom;
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
                TimeElapsedMs = stopwatch.ElapsedMilliseconds,
            };
        }

        public MeanTestResult MeanTest<T>(T rng) where T : IRngInterface
        {
            var stopwatch = Stopwatch.StartNew();

            var sum = new long();
            var samples = _testsSettings.MeanTest.Samples;
            var max = _testsSettings.MeanTest.Max;

            for (var i = 0; i < samples; i++)
            {
                sum += rng.Next(max);
            }

            var avg = (double) sum / samples;

            stopwatch.Stop();

            return new MeanTestResult
            {
                AvgCalculated = avg,
                TimeElapsedMs = stopwatch.ElapsedMilliseconds,
                RngName = rng.Name
            };
        }
    }
}