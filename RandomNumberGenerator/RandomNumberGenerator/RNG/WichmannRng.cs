using System;

namespace RandomNumberGenerator.RNG
{
    public class WichmannRng : IRngInterface
    {
        private double _s1;
        private double _s2;
        private double _s3;

        public string Name => "Wichmann-Hill Algorithm";

        public WichmannRng(int seed)
        {
            if (seed <= 0 || seed > 30000)
                throw new Exception("Bad seed");
            _s1 = seed;
            _s2 = seed + 1;
            _s3 = seed + 2;
        }

        public double Next()
        {
            _s1 = 171 * (_s1 % 177) - 2 * (_s1 / 177);
            if (_s1 < 0) { _s1 += 30269; }
            _s2 = 172 * (_s2 % 176) - 35 * (_s2 / 176);
            if (_s2 < 0) { _s2 += 30307; }
            _s3 = 170 * (_s3 % 178) - 63 * (_s3 / 178);
            if (_s3 < 0) { _s3 += 30323; }
            var r = (_s1 * 1.0) / 30269 + (_s2 * 1.0) / 30307 + (_s3 * 1.0) / 30323;
            return r - Math.Truncate(r);
        }

        public int Next(int max)
        {
            return (int) (max * Next());
        }
    }
}
