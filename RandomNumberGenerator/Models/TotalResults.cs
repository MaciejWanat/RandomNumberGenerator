using System.Collections.Generic;

namespace RandomNumberGenerator.Models
{
    public class TotalResults
    {
        public List<ChiTestResult> ChiTestResults { get; set; }

        public List<MeanTestResult> MeanTestResults { get; set; }

        public List<TimeTestResult> TimeTestResults { get; set; }

        public List<StandardDeviationTestResult> StandardDeviationTestResults { get; set; }
    }
}
