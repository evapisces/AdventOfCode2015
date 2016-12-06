using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // (?![\n\r])\s?\\\\w? - double slash
            // (?![\n\r])\s?\\\""? - slash quote
            // (?![\n\r])\s?\\x\d\d? - \x## (hex)
            //
            var file = File.ReadAllLines("../../testinput.txt");

            foreach (var l in file)
            {
                var line = l;
                var totalLineLen = @line.Length;
                line = line.Remove(0, 1);
                line = line.Remove(line.Length - 1, 1);

                Console.WriteLine("Line = " + line);
                Console.WriteLine("==============================================");
                if (Regex.IsMatch(line, @"(?![\n\r])\s?\\\\\w"))
                {
                    Console.WriteLine("Line contains two slashes!");
                }
                if (Regex.IsMatch(line, @"(?![\n\r])\s?\\\"""))
                {
                    Console.WriteLine("Line contains a single quote");
                }
                if (Regex.IsMatch(line, @"(?![\n\r])\s?\\x\d[0-9a-fA-F]"))
                {
                    Console.WriteLine("Line contains hex");
                }
                Console.WriteLine();

                //Console.WriteLine(line);
            }

            Console.Read();
        }
    }
}
