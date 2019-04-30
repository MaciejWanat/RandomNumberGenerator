namespace RandomNumberGenerator.RNG
{
    public interface IRngInterface
    {
        string Name { get; }

        int Next(int max);
    }
}
