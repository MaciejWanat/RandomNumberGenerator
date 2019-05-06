using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNumberGenerator.Extensions
{
    public static class MathExtensions
    {
        public static double StdDev(this IEnumerable<int> values, bool asSample = false)
        {
            double standardDeviation = 0;
            var enumerable = values as int[] ?? values.ToArray();
            var count = enumerable.Count();

            if (count > 1)
            {
                var avg = enumerable.Average();
                var sum = enumerable.Sum(d => (d - avg) * (d - avg));
                standardDeviation = Math.Sqrt(sum / count);
            }

            return standardDeviation;
        }

        public static double CoeffVar(this IEnumerable<int> values, bool asSample = false)
        {
            var enumerable = values.ToList();

            var stdDev = StdDev(enumerable, asSample);
            var avg = enumerable.Average();

            return stdDev / avg;
        }
    }
}
