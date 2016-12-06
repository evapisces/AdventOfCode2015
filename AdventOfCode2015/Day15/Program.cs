using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public class Program
    {
        const int MAXTSP = 100;
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day15input.txt");
            var ingredientList = new List<Ingredient>();

            foreach (var line in file)
            {
                var split1 = line.Split(':');
                var name = split1[0];
                var props = split1[1].Split(',');
                var cap = Convert.ToInt32(props[0].Trim().Split(' ')[1]);
                var dur = Convert.ToInt32(props[1].Trim().Split(' ')[1]);
                var flav = Convert.ToInt32(props[2].Trim().Split(' ')[1]);
                var text = Convert.ToInt32(props[3].Trim().Split(' ')[1]);
                var cal = Convert.ToInt32(props[4].Trim().Split(' ')[1]);

                ingredientList.Add(new Ingredient
                {
                    Name = name,
                    Capacity = cap,
                    Durability = dur,
                    Flavor = flav,
                    Texture = text,
                    Calories = cal
                });
            }

            ProcessInputA(ingredientList);
            ProcessInputB(ingredientList);

            Console.Read();
        }
        public static void ProcessInputA(List<Ingredient> ingredientList)
        {
            var combos = GetNumberCombinations();
            var maxScore = 0;
            foreach (var combo in combos)
            {
                var cap = ingredientList[0].Capacity * combo.Num1 + ingredientList[1].Capacity * combo.Num2 +
                          ingredientList[2].Capacity * combo.Num3 + ingredientList[3].Capacity * combo.Num4;

                var dur = ingredientList[0].Durability * combo.Num1 + ingredientList[1].Durability * combo.Num2 +
                          ingredientList[2].Durability * combo.Num3 + ingredientList[3].Durability * combo.Num4;

                var flav = ingredientList[0].Flavor * combo.Num1 + ingredientList[1].Flavor * combo.Num2 +
                          ingredientList[2].Flavor * combo.Num3 + ingredientList[3].Flavor * combo.Num4;

                var text = ingredientList[0].Texture * combo.Num1 + ingredientList[1].Texture * combo.Num2 +
                          ingredientList[2].Texture * combo.Num3 + ingredientList[3].Texture * combo.Num4;

                var cal = ingredientList[0].Calories * combo.Num1 + ingredientList[1].Calories * combo.Num2 +
                          ingredientList[2].Calories * combo.Num3 + ingredientList[3].Calories * combo.Num4;

                cap = cap < 0 ? 0 : cap;
                dur = dur < 0 ? 0 : dur;
                flav = flav < 0 ? 0 : flav;
                text = text < 0 ? 0 : text;
                cal = cal < 0 ? 0 : cal;

                var total = cap * dur * flav * text;

                if (total > maxScore)
                    maxScore = total;
            }

            Console.WriteLine("Part 1 Max Cookie Score = " + maxScore);
            Console.Read();
        }

        public static void ProcessInputB(List<Ingredient> ingredientList)
        {
            var combos = GetNumberCombinations();
            var maxScore = 0;
            foreach (var combo in combos)
            {
                var cap = ingredientList[0].Capacity * combo.Num1 + ingredientList[1].Capacity * combo.Num2 +
                          ingredientList[2].Capacity * combo.Num3 + ingredientList[3].Capacity * combo.Num4;

                var dur = ingredientList[0].Durability * combo.Num1 + ingredientList[1].Durability * combo.Num2 +
                          ingredientList[2].Durability * combo.Num3 + ingredientList[3].Durability * combo.Num4;

                var flav = ingredientList[0].Flavor * combo.Num1 + ingredientList[1].Flavor * combo.Num2 +
                          ingredientList[2].Flavor * combo.Num3 + ingredientList[3].Flavor * combo.Num4;

                var text = ingredientList[0].Texture * combo.Num1 + ingredientList[1].Texture * combo.Num2 +
                          ingredientList[2].Texture * combo.Num3 + ingredientList[3].Texture * combo.Num4;

                var cal = ingredientList[0].Calories * combo.Num1 + ingredientList[1].Calories * combo.Num2 +
                          ingredientList[2].Calories * combo.Num3 + ingredientList[3].Calories * combo.Num4;

                cap = cap < 0 ? 0 : cap;
                dur = dur < 0 ? 0 : dur;
                flav = flav < 0 ? 0 : flav;
                text = text < 0 ? 0 : text;
                cal = cal < 0 ? 0 : cal;

                var total = cap * dur * flav * text;

                if (total > maxScore && cal == 500)
                    maxScore = total;
            }

            Console.WriteLine("Part 2 Max Cookie Score = " + maxScore);
            Console.Read();
        }

        private static List<Numbers> GetNumberCombinations()
        {
            var combos = new List<Numbers>();

            for (var i = 0; i < MAXTSP; i++)
            {
                for (var j = 0; j < MAXTSP; j++)
                {
                    for (var k = 0; k < MAXTSP; k++)
                    {
                        for (var l = 0; l < MAXTSP; l++)
                        {
                            int result = i + j + k + l;
                            if (result == MAXTSP && i > 0 && j > 0 && k > 0 && l > 0)
                            {
                                combos.Add(new Numbers
                                {
                                    Num1 = i,
                                    Num2 = j,
                                    Num3 = k,
                                    Num4 = l
                                });
                            }
                        }
                    }
                }
            }

            return combos;
        }

        public class Numbers
        {
            public int Num1 { get; set; }
            public int Num2 { get; set; }
            public int Num3 { get; set; }
            public int Num4 { get; set; }
        }

        public class Ingredient
        {
            public string Name { get; set; }
            public int Capacity { get; set; }
            public int Durability { get; set; }
            public int Flavor { get; set; }
            public int Texture { get; set; }
            public int Calories { get; set; }
        }
    }
}
