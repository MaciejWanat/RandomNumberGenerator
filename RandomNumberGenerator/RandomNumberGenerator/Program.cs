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

            var lehmerRng = new LehmerRng(seed);
            var buildInRng = new BuildInRng();

            var lehmerChiResult = TestRng.TestChi(lehmerRng);
            OutputBuilder.WriteOutput(lehmerChiResult);

            var buildInChiResult = TestRng.TestChi(buildInRng);
            OutputBuilder.WriteOutput(buildInChiResult);

            Console.ReadLine();
        }
    }
}
