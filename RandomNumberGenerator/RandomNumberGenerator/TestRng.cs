using System;
using System.Collections.Generic;
using Accord.Statistics.Testing;

namespace RandomNumberGenerator
{
    public class TestRng
    {
        private Rng _rng;

        public TestRng(Rng rng)
        {
            _rng = rng;
        }

        public void TestChi()
        {
            var rnd = new Random();

            var observedDict = new Dictionary<int, int>();
            for (var i = 0; i < 1000 * 10; i++)
            {
                var num = rnd.Next(10);

                if (observedDict.ContainsKey(num))
                {
                    observedDict[num]++;
                }
                else
                {
                    observedDict[num] = 1;
                }

            }

            double[] observed =
            {
                observedDict[0], observedDict[1], observedDict[2], observedDict[3], observedDict[4],
                observedDict[5], observedDict[6], observedDict[7], observedDict[8], observedDict[9]
            };

            double[] expected = { 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000 };

            int degreesOfFreedom = 1;
            var chi = new ChiSquareTest(expected, observed, degreesOfFreedom);

            double pvalue = chi.PValue;
            bool significant = chi.Significant;

            Console.WriteLine($"PValue = {pvalue}");
            Console.WriteLine($"Significant = {significant}");
        }
    }
}
