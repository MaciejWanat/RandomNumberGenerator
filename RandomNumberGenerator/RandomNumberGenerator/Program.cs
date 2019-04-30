using System;

namespace RandomNumberGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var seed = rnd.Next();

            var lehmerRng = new LehmerRng(seed);
            var test = new TestRng(lehmerRng);

            test.TestChi();

            Console.ReadLine();
        }
    }
}
