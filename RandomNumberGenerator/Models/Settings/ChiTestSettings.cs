namespace RandomNumberGenerator.Models.Settings
{
    public class ChiTestSettings
    {
        public int SampleSize { get; set; }

        public int NumsAmount { get; set; }

        public int DegreesOfFreedom { get; set; }

        public int TotalDraws => SampleSize * NumsAmount;
    }
}
