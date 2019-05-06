namespace RandomNumberGenerator.Models.Settings
{
    public class MeanTestSettings
    {
        public int Samples { get; set; }

        public int Max { get; set; }

        public int AvgExpected => Max / 2;
    }
}
