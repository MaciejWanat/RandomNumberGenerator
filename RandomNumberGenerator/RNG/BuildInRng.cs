using System;

namespace RandomNumberGenerator.RNG
{
    public class BuildInRng : Random, IRngInterface
    {
        public string Name => "Build in RNG";
    }
}
