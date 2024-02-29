using ProLab2_1.Classes.Barriers.Dynamic_Barriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProLab2_1.Classes.Barriers;
using System.Collections.Specialized;

namespace ProLab2_1.Classes
{ 



    


    public class Map
    {
        Quad[,] mapSpace = new Quad[300, 300];

        private List<IBarrier> barriers = new List<IBarrier>();

        public void AddBarrier(IBarrier barrier)
        {
            barriers.Add(barrier);
        }


        public Map()
        {
           
            
        }

        //generating random map


        public Quad[,] generateRandomMap(int witdh, int height)
        {
            Quad[,] map = new Quad[witdh, height];

            Random random = new Random();

            IBarrier[] barriers =this.barriers.ToArray();

            foreach (IBarrier barrier in barriers)
            {
                Location location = generateRandomLocation(random,witdh,height);

                for (int i = location.getX(); i <location.getX()+ barrier.; i++)
                {
                    for (int j = location.getY();i<location.getY()+ barriers.Length; j++)
                    {
                        map[i,j].SetBarrier(barrier);
                    }
                }

            }
            return map;
        }

        private Location generateRandomLocation(Random random,int width, int height)
        {
            int x=random.Next(width);
            int y=random.Next(height);
            return new Location(x, y);
        }


        



    }




}
