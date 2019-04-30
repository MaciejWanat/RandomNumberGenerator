using System;
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

            TestRng.TestChi(lehmerRng);
            TestRng.TestChi(buildInRng);

            Console.ReadLine();
        }
    }
}
