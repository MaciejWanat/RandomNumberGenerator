using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine($"Testing distribution with the Chi Square test:\n");

            var rnd = new Random();
            double sampleSize = 100000;
            var numsAmount = 100;

            var observedDict = new Dictionary<int, int>();
            for (var i = 0; i < sampleSize * numsAmount; i++)
            {
                var num = rnd.Next(numsAmount);

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

            Console.WriteLine($"Expected distribution: {sampleSize} for each number");
            Console.WriteLine($"Observed distribution: \n{string.Join("\n", observedDict.OrderBy(k => k.Key))}");
            Console.WriteLine($"\nPValue = {pValue}");
            Console.WriteLine($"Significant = {significant}");
        }
    }
}
