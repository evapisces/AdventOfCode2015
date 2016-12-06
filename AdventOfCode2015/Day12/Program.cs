using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var jsonLines = System.IO.File.ReadAllLines("../../day12input.txt");
            var sum = 0;

            //ProcessInputA("{\"a\":[-1,1,-3,5]}", ref sum);

            foreach (var json in jsonLines)
                ProcessInputA(json, ref sum);

            Console.Read();
        }

        public static void ProcessInputA(string json, ref int sum)
        {
            //json = json.Replace("[", "").Replace("]", "").Replace("\"", "");
            var jSplit = json.Split(new string[] { "[", "]", ":", "\"", "{", "}", "," }, StringSplitOptions.None);
            var test = Regex.Match(json, @"-?\d+").Value;
            
            foreach(var sp in jSplit.Where(s => !string.IsNullOrEmpty(s)))
            {
                var num = Regex.Match(sp, @"-?\d+").Value;

                if (!string.IsNullOrEmpty(num))
                    sum += Int32.Parse(num);
            }

            Console.WriteLine("Sum = " + sum);
        }
    }
}
