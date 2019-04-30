using System;

namespace RandomNumberGenerator.RNG
{
    public class LinearConRng : IRngInterface
    {
        private const long A = 25214903917;
        private const long C = 11;
        private long _seed;

        public string Name => "Linear Congruential Algorithm";

        public LinearConRng(long seed)
        {
            if (seed < 0)
                throw new Exception("Bad seed");
            _seed = seed;
        }

        public double Next()
        {
            return (((long)NextBits(26) << 27) + NextBits(27)) / (double)(1L << 53);
        }

        public int Next(int max)
        {
            return (int) (max * Next());
        }

        private int NextBits(int bits)
        {
            _seed = (_seed * A + C) & ((1L << 48) - 1);
            return (int)(_seed >> (48 - bits));
        }
    }
}
