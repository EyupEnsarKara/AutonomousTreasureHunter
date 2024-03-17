using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public Node Parent { get; set; }

        public Node(int x, int y, Node parent = null)
        {
            X = x;
            Y = y;
            Parent = parent;
            Cost = parent != null ? parent.Cost + 1 : 0;
        }
        public Location convertLocationClass()
        {
            return new Location(X, Y);
        }
    }



    public class Functions
    {
        public static List<Node> AStar(int[,] harita, Node baslangic, Node bitis, int boyut)
        {
            var acikListe = new List<Node>() { baslangic };
            var kapaliListe = new HashSet<Node>();
            var gCosts = new Dictionary<(int, int), int>() { { (baslangic.X, baslangic.Y), 0 } };

            while (acikListe.Any())
            {
                var suanki = acikListe.OrderBy(node => node.Cost + ManhattanUzakligi(node, bitis)).First();
                if (suanki.X == bitis.X && suanki.Y == bitis.Y)
                    return YoluOlustur(suanki);

                acikListe.Remove(suanki);
                kapaliListe.Add(suanki);

                var komsular = KomsulariGetir(suanki, boyut, harita);
                foreach (var komsu in komsular)
                {
                    if (kapaliListe.Contains(komsu))
                        continue;

                    if (!acikListe.Contains(komsu))
                    {
                        gCosts[(komsu.X, komsu.Y)] = int.MaxValue;
                        komsu.Parent = null;
                    }

                    var yeniGCost = gCosts[(suanki.X, suanki.Y)] + 1;
                    if (yeniGCost < gCosts[(komsu.X, komsu.Y)])
                    {
                        gCosts[(komsu.X, komsu.Y)] = yeniGCost;
                        komsu.Cost = yeniGCost;
                        komsu.Parent = suanki;
                        if (!acikListe.Contains(komsu))
                            acikListe.Add(komsu);
                    }
                }
            }

            return null;
        }

        static List<Node> YoluOlustur(Node node)
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

        static IEnumerable<Node> KomsulariGetir(Node node, int boyut, int[,] harita)
        {
            var hareketler = new List<(int, int)>() { (-1, 0), (1, 0), (0, -1), (0, 1) };
            foreach (var hareket in hareketler)
            {
                int x = node.X + hareket.Item1, y = node.Y + hareket.Item2;
                if (x >= 0 && x < boyut && y >= 0 && y < boyut)
                    if(harita[x, y] != 1)
                    yield return new Node(x, y);
            }
        }

        static int ManhattanUzakligi(Node node1, Node node2)
        {
            return Math.Abs(node1.X - node2.X) + Math.Abs(node1.Y - node2.Y);
        }


    }
}
