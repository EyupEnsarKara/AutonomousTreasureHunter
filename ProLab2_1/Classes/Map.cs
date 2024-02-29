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

            //add barriers to the map
            foreach (IBarrier barrier in barriers)
            {
                Location location = generateRandomLocation(random, witdh, height);
                
                
                
                int x = location.getX();
                int y = location.getY();
                int width = barrier.getBarrierWidth();
                int height_ = barrier.getBarrierHeight();
                for (int i = x; i < x + width; i++)
                {
                    for (int j = y; j < y + height_; j++)
                    {
                        
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

        private bool testLocation(Location location,IBarrier barrier)
        {
            int x = location.getX();
            int y = location.getY();
            int width = barrier.getBarrierWidth();
            int height = barrier.getBarrierHeight();
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    if(this.mapSpace[i, j].GetisBarrier())
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        



    }




}
