namespace RandomNumberGenerator.Models
{
    public class MeanTestResult : TestResult
    {
        public int AvgExpected { get; set; }

        public double AvgCalculated { get; set; }

        public int Max { get; set; }

        public int Samples { get; set; }
    }
}
