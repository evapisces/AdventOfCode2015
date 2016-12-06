using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day9input.txt");
            var paths = new List<Path>();

            foreach (var l in file)
            {
                var line = l;
                line = line.Replace(" to ", " ").Replace(" = ", " ");
                var linesegs = line.Split(' ');
                paths.Add(new Path
                {
                    From = linesegs[0],
                    To = linesegs[1],
                    Distance = Convert.ToInt32(linesegs[2])
                });
            }



            //var vertices = new List<string>();
            List<Node> graph = new List<Node>();

            foreach (var path in paths)
            {
                if (graph.All(g => g.name != path.To))
                {
                    graph.Add(new Node
                    {
                        name = path.To,
                        neighbors = new List<Neighbor>()
                    });
                }
                if (graph.All(g => g.name != path.From))
                {
                    graph.Add(new Node
                    {
                        name = path.From,
                        neighbors = new List<Neighbor>(),
                        visited = false
                    });
                }

                var node = graph.Find(g => g.name == path.To);

                if (graph.Find(g => g.name == path.From) != null)
                {
                    graph.Find(g => g.name == path.From).neighbors.Add(new Neighbor
                    {
                        node = node,
                        distance = path.Distance
                    });
                }
            }

            foreach (var node in graph)
            {

            }

            /*TraverseNode(graph[0]);
            foreach (Node node in graph)
            {
                Console.WriteLine("Node : {0}", node.name);
                foreach (string key in node.distanceDict.Keys.OrderBy(x => x))
                {
                    Console.WriteLine(" Path to node {0} is {1}", key,
                        string.Join(",", node.distanceDict[key].ToArray()));
                }
            }*/

            Console.Read();
        }

        /*public static void TraverseNode(Node node)
        {
            if (!node.visited)
            {
                node.visited = true;
                foreach (Neighbor neighbor in node.neighbors)
                {
                    TraverseNode(neighbor.node);
                    string neighborName = neighbor.node.name;
                    int neighborDistance = neighbor.distance;
                    //compair neibors dictionary with current dictionary
                    //update current dictionary as required
                    foreach (string key in neighbor.node.distanceDict.Keys)
                    {
                        if (key != node.name)
                        {
                            int neighborKeyDistance = neighbor.node.distanceDict[key].Count;
                            if (node.distanceDict.ContainsKey(key))
                            {
                                int currentDistance = node.distanceDict[key].Count;
                                if (neighborKeyDistance + neighborDistance < currentDistance)
                                {
                                    List<string> nodeList = new List<string>();
                                    nodeList.AddRange(neighbor.node.distanceDict[key].ToArray());
                                    nodeList.Insert(0, neighbor.node.name);
                                    node.distanceDict[key] = nodeList;
                                }
                            }
                            else
                            {
                                List<string> nodeList = new List<string>();
                                nodeList.AddRange(neighbor.node.distanceDict[key].ToArray());
                                nodeList.Insert(0, neighbor.node.name);
                                node.distanceDict.Add(key, nodeList);
                            }
                        }
                    }
                }
            }
        }*/

        public class Neighbor
        {
            public Node node { get; set; }
            public int distance { get; set; }
        }
        public class Node
        {

            public string name { get; set; }
            //public Dictionary<string, List<string>> distanceDict { get; set; }
            public Boolean visited { get; set; }
            public List<Neighbor> neighbors { get; set; }
        }

        public class Path
        {
            public string To { get; set; }
            public string From { get; set; }
            public int Distance { get; set; }
        }
    }
}
