using System;

namespace RandomNumberGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var seed = rnd.Next();

            var lehmerRng = new Rng(seed);
            var testLehmer = new TestLehmer(lehmerRng);

            testLehmer.TestChi();

            Console.ReadLine();
        }
    }
}
