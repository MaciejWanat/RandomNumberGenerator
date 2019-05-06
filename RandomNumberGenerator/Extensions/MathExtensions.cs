using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNumberGenerator.Extensions
{
    public static class MathExtensions
    {
        public static double StdDev(this IEnumerable<int> valuesRaw, bool asSample = false)
        {
            var values = valuesRaw.ToList();
            var mean = (double) values.Sum() / values.Count();

            var squaresQuery =
                from int value in values
                select (value - mean) * (value - mean);

            var sumOfSquares = squaresQuery.Sum();

            return asSample ? Math.Sqrt(sumOfSquares / (values.Count() - 1)) : Math.Sqrt(sumOfSquares / values.Count());
        }
    }
}
