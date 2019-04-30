using System.Collections.Generic;

namespace RandomNumberGenerator.Models
{
    public class ChiTestResult
    {
        public double TimeElapsedMs { get; set; }

        public bool IsSignificant { get; set; }

        public double PValue { get; set; }

        public string RngName { get; set; }

        public Dictionary<int, int> ObservedDict { get; set; }

        public double SampleSize { get; set; }

        public double TotalDraws { get; set; }
    }
}
