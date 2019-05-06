using RandomNumberGenerator.Models;
using RandomNumberGenerator.RNG;

namespace RandomNumberGenerator.Services
{
    public interface ITestRngService
    {
        ChiTestResult ChiTest<T>(T rng) where T: IRngInterface;

        MeanTestResult MeanTest<T>(T rng) where T : IRngInterface;

        TimeTestResult TimeTest<T>(T rng) where T : IRngInterface;

        StandardDeviationTestResult StandardDeviationTest<T>(T rng) where T : IRngInterface;
    }
}