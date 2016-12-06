using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = "ckczppom";
            
            ProcessInputA(input);
            ProcessInputB(input);

            Console.Read();
        }

        public static void ProcessInputA(string input)
        {
            var hash = "";
            var i = 0; // loop counter;
            var stop = false;

            using (var md5Hash = MD5.Create())
            {
                do
                {
                    hash = getMd5Hash(md5Hash, input + i);
                    if (hash.StartsWith("00000"))
                    {
                        Console.WriteLine("Smallest value to produce hash with 5 leading zeros = " + i);
                        stop = true;
                    }
                    else
                    {
                        i++;
                    }
                } while (!stop);
            }
        }

        public static void ProcessInputB(string input)
        {
            var hash = "";
            var i = 0; // loop counter;
            var stop = false;

            using (var md5Hash = MD5.Create())
            {
                do
                {
                    hash = getMd5Hash(md5Hash, input + i);
                    if (hash.StartsWith("000000"))
                    {
                        Console.WriteLine("Smallest value to produce hash with 6 leading zeros = " + i);
                        stop = true;
                    }
                    else
                    {
                        i++;
                    }
                } while (!stop);
            }
        }

        public static string getMd5Hash(MD5 md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
