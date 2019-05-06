using RandomNumberGenerator.Models;

namespace RandomNumberGenerator.Helpers
{
    public interface IOutputBuilder
    {
        void WriteOutput(TotalResults totalResults);
    }
}