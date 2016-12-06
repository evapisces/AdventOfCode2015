using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var totalWrappingPaper = 0;
            var totalRibbon = 0;

            var file = File.ReadAllLines("../../day2input.txt");

            foreach (var line in file)
            {
                var dimensions = line.Split('x');
                var l = Convert.ToInt16(dimensions[0]);
                var w = Convert.ToInt16(dimensions[1]);
                var h = Convert.ToInt16(dimensions[2]);
                var smallestarea = l * w;
                var smallestperimeter = 2 * l + 2 * w;

                if (w * h < smallestarea)
                    smallestarea = w * h;
                if (h * l < smallestarea)
                    smallestarea = h * l;

                if (2 * w + 2 * h < smallestperimeter)
                    smallestperimeter = 2 * w + 2 * h;
                if (2 * h + 2 * l < smallestperimeter)
                    smallestperimeter = 2 * l + 2 * h;

                var surfacearea = 2 * l * w + 2 * w * h + 2 * h * l;
                totalWrappingPaper += (surfacearea + smallestarea);

                var bowRibbon = l * w * h;
                totalRibbon += (smallestperimeter + bowRibbon);
            }

            Console.WriteLine("total wrapping paper amount = " + totalWrappingPaper);       // PART 1 Answer
            Console.WriteLine("total ribbon amount = " + totalRibbon);                      // PART 2 Answer
            Console.Read();
        }
    }
}
