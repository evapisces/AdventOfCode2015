using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public class Program
    {
        static Dictionary<int, Dictionary<string, int>> sueInfo = new Dictionary<int, Dictionary<string, int>>();
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day16input.txt");

            ProcessInputA(file);

            sueInfo = new Dictionary<int, Dictionary<string, int>>();
            ProcessInputB(file);

            Console.Read();
        }

        public static void ProcessInputA(string[] lines)
        {

        }

        public static void ProcessInputB(string[] lines)
        {

        }
    }
}
