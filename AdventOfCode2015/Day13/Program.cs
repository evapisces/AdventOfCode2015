using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Program
    {
        static Dictionary<string, List<Neighbor>> seating = new Dictionary<string, List<Neighbor>>();
        static List<string[]> seatingPermutations = new List<string[]>();

        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day13input.txt");

            ProcessInputA(file);

            var file2 = File.ReadAllLines("../../day13inputB.txt");
            seating = new Dictionary<string, List<Neighbor>>();
            seatingPermutations = new List<string[]>();

            ProcessInputB(file2);

            Console.Read();
        }

        public static bool Evaluate(string[] names)
        {
            //Console.WriteLine(string.Format("{0},{1},{2},{3}", names[0], names[1], names[2], names[3]));

            var perm = new string[names.Count()+1];
            for (var i = 0; i < names.Count(); i++)
            {
                perm[i] = names[i];
            }

            perm[names.Count()] = names[0];
            seatingPermutations.Add(perm);

            var someCondition = false;

            if (someCondition)
                return true;

            return false;
        }

        public static void ProcessInputA(string[] file)
        {
            var names = new List<string>();

            foreach (var line in file)
            {
                var splits = line.Substring(0, line.Length - 1).Split(' ');
                names.Add(splits[0]);
            }

            var distinctNames = names.Distinct().ToList();

            foreach (var distinctName in distinctNames)
            {
                var neighbors = new List<Neighbor>();
                foreach (var line in file)
                {
                    var words = line.Substring(0, line.Length - 1).Split(' ');
                    if (words[0] == distinctName)
                    {
                        var happiness = int.Parse(words[3]);
                        var happinessSign = words[2].ToLower() == "gain" ? 1 : -1;
                        var neighborName = words.Last();
                        var neighbor = new Neighbor
                        {
                            Name = neighborName,
                            Happiness = happiness * happinessSign
                        };
                        neighbors.Add(neighbor);

                        if (neighbors.Count == distinctNames.Count - 1)
                            break;
                    }
                }
                seating.Add(distinctName, neighbors);
            }

            new PermutationFinder<string>().Evaluate(distinctNames.ToArray(), Evaluate);


            var maxHappiness = 0;

            foreach (var sp in seatingPermutations)
            {
                var netHappiness = 0;
                var one = sp[0];
                for (var i = 1; i < sp.Length; i++)
                {
                    var two = sp[i];
                    var oneSeating = seating.Where(s => s.Key == one).Select(s => s.Value).First();
                    var oneNeighborNeeded = oneSeating.FirstOrDefault(n => n.Name == two);

                    var twoSeating = seating.Where(s => s.Key == two).Select(s => s.Value).First();
                    var twoNeighborNeeded = twoSeating.FirstOrDefault(n => n.Name == one);

                    netHappiness += (oneNeighborNeeded.Happiness + twoNeighborNeeded.Happiness);

                    one = sp[i];
                }

                if (netHappiness > maxHappiness)
                    maxHappiness = netHappiness;
            }

            Console.WriteLine("Part 1 Maximum Happiness is " + maxHappiness);
        }

        public static void ProcessInputB(string[] file)
        {
            var names = new List<string>();

            foreach (var line in file)
            {
                var splits = line.Substring(0, line.Length - 1).Split(' ');
                names.Add(splits[0]);
            }

            var distinctNames = names.Distinct().ToList();

            foreach (var distinctName in distinctNames)
            {
                var neighbors = new List<Neighbor>();
                foreach (var line in file)
                {
                    var words = line.Substring(0, line.Length - 1).Split(' ');
                    if (words[0] == distinctName)
                    {
                        var happiness = int.Parse(words[3]);
                        var happinessSign = words[2].ToLower() == "gain" ? 1 : -1;
                        var neighborName = words.Last();
                        var neighbor = new Neighbor
                        {
                            Name = neighborName,
                            Happiness = happiness * happinessSign
                        };
                        neighbors.Add(neighbor);

                        if (neighbors.Count == distinctNames.Count - 1)
                            break;
                    }
                }
                if (!seating.ContainsKey(distinctName))
                    seating.Add(distinctName, neighbors);
            }

            new PermutationFinder<string>().Evaluate(distinctNames.ToArray(), Evaluate);


            var maxHappiness = 0;

            foreach (var sp in seatingPermutations)
            {
                var netHappiness = 0;
                var one = sp[0];
                for (var i = 1; i < sp.Length; i++)
                {
                    var two = sp[i];
                    var oneSeating = seating.Where(s => s.Key == one).Select(s => s.Value).First();
                    var oneNeighborNeeded = oneSeating.FirstOrDefault(n => n.Name == two);

                    var twoSeating = seating.Where(s => s.Key == two).Select(s => s.Value).First();
                    var twoNeighborNeeded = twoSeating.FirstOrDefault(n => n.Name == one);

                    netHappiness += (oneNeighborNeeded.Happiness + twoNeighborNeeded.Happiness);

                    one = sp[i];
                }

                if (netHappiness > maxHappiness)
                    maxHappiness = netHappiness;
            }

            Console.WriteLine("Part 2 Maximum Happiness is " + maxHappiness);
        }

        public class Neighbor
        {
            public string Name { get; set; }
            public int Happiness { get; set; }
        }
    }


    /// <summary>
    /// Class to get the combinations of seats
    /// Source: http://stackoverflow.com/questions/11208446/generating-permutations-of-a-set-most-efficiently
    /// Poster: Sam (http://stackoverflow.com/users/866293/sam)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PermutationFinder<T>
    {
        private T[] items;
        private Predicate<T[]> SuccessFunc;
        private bool success = false;
        private int itemsCount;

        public void Evaluate(T[] items, Predicate<T[]> SuccessFunc)
        {
            this.items = items;
            this.SuccessFunc = SuccessFunc;
            this.itemsCount = items.Count();

            Recurse(0);
        }

        private void Recurse(int index)
        {
            T temp;

            if (index == itemsCount)
                success = SuccessFunc(items);
            else
            {
                for(int i = index; i < itemsCount; i++)
                {
                    temp = items[index];
                    items[index] = items[i];
                    items[i] = temp;

                    Recurse(index + 1);

                    if (success)
                        break;

                    temp = items[index];
                    items[index] = items[i];
                    items[i] = temp;
                }
            }
        }
    }
}
