using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class Program
    {
        static List<ReindeerStat> ReindeerStats = new List<ReindeerStat>();

        public static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("../../day14input.txt");

            GetReindeerStats(lines);
            ProcessInputA();

            Console.Read();
        }

        public static void ProcessInputA()
        {
            var seconds = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Part1Seconds"]);

            foreach (var reindeer in ReindeerStats)
            {
                var flyingAmt = new List<int[]>();
                var restingAmt = new List<int[]>();
                var timeArray = new int[seconds];
                var timeIndex = 0;

                // break time span up into sections of flying and resting
                while (timeIndex < seconds)
                {
                    if (timeIndex == 0)
                    {
                        flyingAmt.Add(timeArray.Take(reindeer.FlyingTime).ToArray());
                    }
                    else
                    {
                        flyingAmt.Add(timeArray.Skip(timeIndex).Take(reindeer.FlyingTime).ToArray());
                    }

                    timeIndex += reindeer.FlyingTime;
                    restingAmt.Add(timeArray.Skip(timeIndex).Take(reindeer.RestingTime).ToArray());
                    timeIndex += reindeer.RestingTime;
                }

                // get number of times reindeer flew in the given time span
                var numberOfFlying = flyingAmt.Count;

                // gross distance = # of times flown * speed * time
                reindeer.Distance = numberOfFlying * reindeer.FlyingSpeed * reindeer.FlyingTime;

                // if last flight didn't take up entire flight time, adjust distance accordingly
                // subtract out the distance for seconds not travelled
                if (flyingAmt.Last().Length < reindeer.FlyingTime)
                {
                    var amtToDeduct = reindeer.FlyingSpeed * (reindeer.FlyingTime - flyingAmt.Last().Length);
                    reindeer.Distance -= amtToDeduct;
                }
            }

            Console.WriteLine("Reindeer that travelled the furthest was: " + ReindeerStats.OrderByDescending(r => r.Distance).First().Name +
                    " with a distance of " + ReindeerStats.OrderByDescending(r => r.Distance).First().Distance);
        }

        private static void GetReindeerStats(string[] lines)
        {
            foreach (var line in lines)
            {
                var splits = line.Trim().Split(' ');

                var stat = new ReindeerStat
                {
                    Name = splits[0],
                    FlyingSpeed = int.Parse(splits[3]),
                    FlyingTime = int.Parse(splits[6]),
                    RestingTime = int.Parse(splits[13]),
                    Distance = 0
                };

                ReindeerStats.Add(stat);
            }
        }

        public class ReindeerStat
        {
            public string Name { get; set; }
            public int FlyingSpeed { get; set; }
            public int FlyingTime { get; set; }
            public int RestingTime { get; set; }
            public int Distance { get; set; }
        }
    }
}
