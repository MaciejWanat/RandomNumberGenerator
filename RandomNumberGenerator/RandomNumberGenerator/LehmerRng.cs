using System;

namespace RandomNumberGenerator
{
    public class LehmerRng
    {
        private const int A = 16807;
        private const int M = 2147483647;
        private const int Q = 127773;
        private const int R = 2836;
        private int _seed;

        public LehmerRng(int seed)
        {
            if (seed <= 0 || seed == int.MaxValue)
                throw new Exception("Bad seed");
            this._seed = seed;
        }

        private double Next()
        {
            var hi = _seed / Q;
            var lo = _seed % Q;
            _seed = (A * lo) - (R * hi);
            if (_seed <= 0)
                _seed = _seed + M;
            return (_seed * 1.0) / M;
        }

        public int Next(int max)
        {
            return (int) ((max - 0) * Next() + 0);
        }
    }
}
