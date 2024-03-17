using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
    public class Node : IComparable<Node>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int FCost { get; set; }
        public Node Parent { get; set; }

        public Node(int x, int y, Node parent = null)
        {
            X = x;
            Y = y;
            Parent = parent;
            Cost = parent != null ? parent.Cost + 1 : 0;
        }

        public int CompareTo(Node other)
        {
            return FCost.CompareTo(other.FCost);
        }

        public Location ConvertToLocation()
        {
            return new Location(X, Y);
        }
    }

    public class Functions
    {
        public static List<Node> AStar(int[,] map, Node start, Node goal, int size)
        {
            var openList = new List<Node>() { start };
            var closedList = new HashSet<(int, int)>();
            var gCosts = new Dictionary<(int, int), int>() { { (start.X, start.Y), 0 } };

            while (openList.Count > 0)
            {
                openList.Sort((node1, node2) => (node1.Cost + ManhattanDistance(node1, goal)).CompareTo(node2.Cost + ManhattanDistance(node2, goal)));
                var current = openList[0];
                openList.RemoveAt(0);

                if (current.X == goal.X && current.Y == goal.Y)
                    return ConstructPath(current);

                closedList.Add((current.X, current.Y));

                foreach (var neighbor in GetNeighbors(current, size, map))
                {
                    if (closedList.Contains((neighbor.X, neighbor.Y)))
                        continue;

                    var newGCost = gCosts[(current.X, current.Y)] + 1;
                    if (!gCosts.ContainsKey((neighbor.X, neighbor.Y)) || newGCost < gCosts[(neighbor.X, neighbor.Y)])
                    {
                        gCosts[(neighbor.X, neighbor.Y)] = newGCost;
                        neighbor.Cost = newGCost;
                        neighbor.Parent = current;

                        if (!openList.Any(n => n.X == neighbor.X && n.Y == neighbor.Y))
                            openList.Add(neighbor);
                    }
                }
            }

            return null;
        }

        static List<Node> ConstructPath(Node node)
        {
            var path = new List<Node>();
            while (node != null)
            {
                path.Add(node);
                node = node.Parent;
            }
            path.Reverse();
            return path;
        }

        static IEnumerable<Node> GetNeighbors(Node node, int size, int[,] map)
        {
            var movements = new List<(int, int)>() { (-1, 0), (1, 0), (0, -1), (0, 1) };
            foreach (var movement in movements)
            {
                int x = node.X + movement.Item1, y = node.Y + movement.Item2;
                if (x >= 0 && x < size && y >= 0 && y < size && map[x, y] != 1)
                {
                    yield return new Node(x, y);
                }
            }
        }

        static int ManhattanDistance(Node node1, Node node2)
        {
            return Math.Abs(node1.X - node2.X) + Math.Abs(node1.Y - node2.Y);
        }
    }

}
