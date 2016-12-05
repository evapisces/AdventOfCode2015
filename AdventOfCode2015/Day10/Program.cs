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
            //var input = "1113122113";
            var input = "312211";

            ProcessInputA(input);

            Console.Read();
        }

        public static void ProcessInputA(string input)
        {
            var numbersList = new List<string>();
            string splitList = "";
            var currNum = input[0];
            splitList += currNum;

            for (var index = 1; index <= input.Length; index++)
            {
                if (input[index] == currNum)
                {
                    splitList += input[index];
                    currNum = input[index];
                }
                else
                {
                    numbersList.Add(splitList);
                    currNum = input[index];
                    splitList = input[index].ToString();
                    if (index == input.Length - 1)
                    {
                        numbersList.Add(splitList);
                        break;
                    }
                }
            }
        }
    }
}
