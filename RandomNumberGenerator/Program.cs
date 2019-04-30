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

            var buildInChiResult = TestRng.TestChi(buildInRng);
            OutputBuilder.WriteOutput(buildInChiResult);

            var lehmerChiResult = TestRng.TestChi(lehmerRng);
            OutputBuilder.WriteOutput(lehmerChiResult);

            var wichmannChiResult = TestRng.TestChi(wichmannRng);
            OutputBuilder.WriteOutput(wichmannChiResult);

            var linearConResult = TestRng.TestChi(linearConRng);
            OutputBuilder.WriteOutput(linearConResult);

            Console.ReadLine();
        }
    }
}
