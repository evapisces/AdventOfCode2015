using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = "1113122113";
            //var input = "1";
            /*var result = ProcessInputA(input);

            for (var i = 0; i < 40; i++)
            {
                result = ProcessInputA(string.Join("", result.ToArray()));
            }

            Console.WriteLine(string.Join("", result.ToArray()).Length);*/
            ProcessInputA(input);
            ProcessInputB(input);
            Console.Read();
        }

        public static void ProcessInputA(string input)
        {
            for (var i = 0; i < 40; i++)
            {
                input = elvesLookElvesSay(input);
            }
            Console.WriteLine("Length after 40 iterations = " + input.Length);
        }

        public static void ProcessInputB(string input)
        {
            for (var i = 0; i < 50; i++)
            {
                input = elvesLookElvesSay(input);
            }
            Console.WriteLine("Length after 50 iterations = " + input.Length);
        }

        private static string elvesLookElvesSay(string str)
        {
            var result = new StringBuilder();

            var currNum = str[0];
            str = str.Substring(1, str.Length - 1) + " ";
            int times = 1;

            foreach(var ch in str)
            {
                if (ch != currNum)
                {
                    result.Append(Convert.ToString(times) + currNum);
                    times = 1;
                    currNum = ch;
                } else
                {
                    times += 1;
                }
            }

            return result.ToString();
        }

        /*public static IEnumerable<int> ProcessInputA(string input)
        {
            var currNum = input[0];
            var ctr = 1;
            var index = 1;

            while (index < input.Length)
            {
                if (input[index] == currNum)
                {
                    ctr++;
                }
                else
                {
                    yield return ctr;
                    yield return currNum - '0';
                    currNum = input[index];
                    ctr = 1;
                }

                index++;
            }

            yield return ctr;
            yield return currNum - '0';
        }*/
    }
}
