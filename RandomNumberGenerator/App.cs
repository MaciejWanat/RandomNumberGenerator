﻿using System;
using System.Collections.Generic;
using RandomNumberGenerator.Helpers;
using RandomNumberGenerator.Models;
using RandomNumberGenerator.RNG;
using RandomNumberGenerator.Services;

namespace RandomNumberGenerator
{
    public class App
    {
        private readonly IOutputBuilder _outputBuilder;
        private readonly ITestRngService _testRng;

        public App(IOutputBuilder outputBuilder, ITestRngService testRng)
        {
            _outputBuilder = outputBuilder;
            _testRng = testRng;
        }

        public void Run()
        {
            var rnd = new Random();
            var seed = rnd.Next();
            var wichSeed = rnd.Next(30000);

            var lehmerRng = new LehmerRng(seed);
            var wichmannRng = new WichmannRng(wichSeed);
            var linearConRng = new LinearConRng(seed);
            var buildInRng = new BuildInRng();

            var result = new TotalResults
            {
                ChiTestResults = new List<ChiTestResult>
                {
                    _testRng.ChiTest(buildInRng),
                    _testRng.ChiTest(lehmerRng),
                    _testRng.ChiTest(wichmannRng),
                    _testRng.ChiTest(linearConRng)
                },
                MeanTestResults = new List<MeanTestResult>
                {
                    _testRng.MeanTest(buildInRng),
                    _testRng.MeanTest(lehmerRng),
                    _testRng.MeanTest(wichmannRng),
                    _testRng.MeanTest(linearConRng)
                }
            };

            _outputBuilder.WriteOutput(result);
            Console.ReadLine();
        }
    }
}
