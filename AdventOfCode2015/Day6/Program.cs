using System;
using System.IO;

namespace Day6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day6input.txt");
            var grid = new int[1000, 1000];
            var lightsOn = 0;
            var totalBrightness = 0;

            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    grid[i, j] = 0;
                }
            }

            ProcessInputA(file, ref grid);
            ProcessInputB(file, ref grid);
            Console.Read();
        }

        public static void ProcessInputA(string[] lines, ref int[,] grid)
        {
            var lightsOn = 0;
            var totalBrightness = 0;

            foreach (var line in lines)
            {
                var linesegs = line.Split(',');
                var pt1x = 0;
                var pt1y = 0;
                var pt2x = 0;
                var pt2y = 0;

                if (line.StartsWith("turn on") || line.StartsWith("turn off"))
                {
                    pt1x = Convert.ToInt16(linesegs[0].Split(' ')[2]); // x
                    pt1y = Convert.ToInt16(linesegs[1].Split(' ')[0]); // y
                    pt2x = Convert.ToInt16(linesegs[1].Split(' ')[2]); // a
                    pt2y = Convert.ToInt16(linesegs[2]); // b
                }
                else if (line.StartsWith("toggle"))
                {
                    pt1x = Convert.ToInt16(linesegs[0].Split(' ')[1]); // x
                    pt1y = Convert.ToInt16(linesegs[1].Split(' ')[0]); // y
                    pt2x = Convert.ToInt16(linesegs[1].Split(' ')[2]); // a
                    pt2y = Convert.ToInt16(linesegs[2]); // b
                }

                // loop from y to b
                for (var i = pt1y; i <= pt2y; i++)
                {
                    for (var j = pt1x; j <= pt2x; j++)
                    {
                        if (line.StartsWith("turn on"))
                        {
                            if (grid[i, j] == 0)
                            {
                                grid[i, j] = 1;
                                lightsOn++;
                            }
                        }
                        else if (line.StartsWith("turn off"))
                        {
                            if (grid[i, j] == 1)
                            {
                                grid[i, j] = 0;
                                lightsOn--;
                            } 
                        }
                        else if (line.StartsWith("toggle"))
                        {
                            if (grid[i, j] == 0)
                            {
                                grid[i, j] = 1;
                                lightsOn++;
                            }
                            else if (grid[i, j] == 1)
                            {
                                grid[i, j] = 0;
                                lightsOn--;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("# of lights turned on = " + lightsOn);
        }

        public static void ProcessInputB(string[] lines, ref int[,] grid)
        {
            var lightsOn = 0;
            var totalBrightness = 0;

            foreach (var line in lines)
            {
                var linesegs = line.Split(',');
                var pt1x = 0;
                var pt1y = 0;
                var pt2x = 0;
                var pt2y = 0;

                if (line.StartsWith("turn on") || line.StartsWith("turn off"))
                {
                    pt1x = Convert.ToInt16(linesegs[0].Split(' ')[2]); // x
                    pt1y = Convert.ToInt16(linesegs[1].Split(' ')[0]); // y
                    pt2x = Convert.ToInt16(linesegs[1].Split(' ')[2]); // a
                    pt2y = Convert.ToInt16(linesegs[2]); // b
                }
                else if (line.StartsWith("toggle"))
                {
                    pt1x = Convert.ToInt16(linesegs[0].Split(' ')[1]); // x
                    pt1y = Convert.ToInt16(linesegs[1].Split(' ')[0]); // y
                    pt2x = Convert.ToInt16(linesegs[1].Split(' ')[2]); // a
                    pt2y = Convert.ToInt16(linesegs[2]); // b
                }

                // loop from y to b
                for (var i = pt1y; i <= pt2y; i++)
                {
                    for (var j = pt1x; j <= pt2x; j++)
                    {
                        if (line.StartsWith("turn on"))
                        {
                            grid[i, j]++;
                            totalBrightness++;
                        }
                        else if (line.StartsWith("turn off"))
                        {
                            if (grid[i, j] > 0)
                            {
                                grid[i, j]--;
                                totalBrightness--;
                            }
                            else
                            {
                                grid[i, j] = 0;
                            }
                        }
                        else if (line.StartsWith("toggle"))
                        {
                            grid[i, j] += 2;
                            totalBrightness += 2;
                        }
                    }
                }
            }
            Console.WriteLine("total brightness = " + totalBrightness);
        }
    }
}
