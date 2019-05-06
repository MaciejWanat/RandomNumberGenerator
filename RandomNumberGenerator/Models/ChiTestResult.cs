using System.Collections.Generic;

namespace RandomNumberGenerator.Models
{
    public class ChiTestResult : TestResult
    {
        public bool IsSignificant { get; set; }

        public double PValue { get; set; }

        public Dictionary<int, int> ObservedDict { get; set; }

        public double SampleSize { get; set; }

        public double TotalDraws { get; set; }
    }
}
