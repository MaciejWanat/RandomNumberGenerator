using System;
using RandomNumberGenerator.Helpers;
using RandomNumberGenerator.RNG;

namespace RandomNumberGenerator
{
    public class Program
    {
        static void Main()
        {
            var rnd = new Random();
            var seed = rnd.Next();
            var wichSeed = rnd.Next(30000);

            var lehmerRng = new LehmerRng(seed);
            var wichmannRng = new WichmannRng(wichSeed);
            var linearConRng = new LinearConRng(seed);
            var buildInRng = new BuildInRng();

            var buildInChiResult = TestRng.ChiTest(buildInRng);
            var buildInMeanResult = TestRng.MeanTest(buildInRng);
            OutputBuilder.WriteOutput(buildInChiResult);
            OutputBuilder.WriteOutput(buildInMeanResult);

            var lehmerChiResult = TestRng.ChiTest(lehmerRng);
            var lehmerMeanResult = TestRng.MeanTest(lehmerRng);
            OutputBuilder.WriteOutput(lehmerChiResult);
            OutputBuilder.WriteOutput(lehmerMeanResult);

            var wichmannChiResult = TestRng.ChiTest(wichmannRng);
            var wichmannMeanResult = TestRng.MeanTest(wichmannRng);
            OutputBuilder.WriteOutput(wichmannChiResult);
            OutputBuilder.WriteOutput(wichmannMeanResult);

            var linearConResult = TestRng.ChiTest(linearConRng);
            var linearMeanResult = TestRng.MeanTest(linearConRng);
            OutputBuilder.WriteOutput(linearConResult);
            OutputBuilder.WriteOutput(linearMeanResult);

            Console.ReadLine();
        }
    }
}
