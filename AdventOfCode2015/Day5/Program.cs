using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public static void ProcessInputA()
        {
            
        }

        public static void ProcessInputB()
        {
            var sol2 = from word in File.ReadAllLines("../../day5input.txt")
                       let matchingTriplets = word.Zip(word.Skip(2), (p, s) => p == s).Where(_ => _)
                       let indexedPairs = word.Zip(word.Skip(1), (p, s) => string.Format("{0}{1}", p, s))
                                            .Select((p, i) => new { i, p })
                       let matchingPairs = from ipl in indexedPairs
                                           join ipr in indexedPairs on ipl.p equals ipr.p
                                           select Math.Abs(ipl.i - ipr.i)
                       where matchingTriplets.Any() && matchingPairs.Any(d => d > 1)
                       select word;

            Console.WriteLine(sol2.Count());
        }
    }
}
