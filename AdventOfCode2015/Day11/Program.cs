using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var oldPassword = "vzbxkghb";
            //var oldPassword = "abbceffg";

            ProcessInputA(oldPassword);
        }

        public static void ProcessInputA(string pw)
        {
            var isValid = false;
            var newPw = pw;
            while (!isValid)
            {
                newPw = IncrementPassword(newPw);

                isValid = IsPasswordValid(newPw);
            }

            if (isValid)
                Console.WriteLine("New Valid Password = " + pw);
        }

        public static void ProcessInputB(string pw)
        {
            
        }

        private static bool IsPasswordValid(string pw)
        {
            var rule1Valid = true;
            var rule2Valid = true;
            var rule3Valid = false;
            // Rule 1: Increasing straight of 3+ letters
            // ex: abc, def, jkl
            var straights = new List<char[]>();
            var invalid = new List<int>();

            for (var i = 0; i < pw.Length; i++)
            {
                var one = i;
                var two = i + 1;
                var three = i + 2;

                straights.Add(new []{pw[one], pw[two], pw[three]});

                if (three == pw.Length - 1)
                    break;
            }

            foreach (var s in straights)
            {
                var firstLetter = s[0];
                for (var i = 1; i < s.Length; i++)
                {
                    if (Convert.ToInt32(firstLetter) + 1 != Convert.ToInt32(s[i]))
                    {
                        invalid.Add(1);
                        break;
                    }

                    firstLetter = s[i];
                }
            }

            if (invalid.Count(b => b == 1) == straights.Count)
            {
                rule1Valid = false;
            }


            // Rule 2: Can't contain i, o, or l
            if (pw.Contains('i') || pw.Contains('o') || pw.Contains('l'))
            {
                rule2Valid = false;
            }

            // Rule 3: 2+ different non-overlapping pairs of letters
            // ex: aa, bb, zz
            List<char> pairs = new List<char>();
            for (var i = 2; i <= pw.Length; i++)
            {
                var rule3ProcessingResult = pw.Where(c => pw[i - 1] == c && pw[i - 2] == c).ToList();
                
                if (rule3ProcessingResult.Count == 2)
                {
                    pairs.Add(rule3ProcessingResult.First());
                }
            }

            if (pairs.Count >= 2)
            {
                rule3Valid = true;
            }

            return (rule1Valid && rule2Valid && rule3Valid);
        }

        public static string IncrementPassword(string pw)
        {
            var array = pw.ToCharArray();
            for (var i = array.Length - 1; i >= 0; i--)
            {
                var ch = array[i];

                if (ch == 'z')
                    array[i] = 'a';
                else
                {
                    array[i] = Convert.ToChar(Convert.ToInt32(ch) + 1);
                }
            }

            return new string(array);
        }
    }

}
