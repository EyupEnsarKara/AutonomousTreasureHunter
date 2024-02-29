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
        Quad[,] quads;

        private List<IBarrier> barriers = new List<IBarrier>();

        public void AddBarrier(IBarrier barrier)
        {
            barriers.Add(barrier);
        }


        public Map()
        {
           
            
        }

        //generating random map


        public void generateRandomMap(int mapWidth, int mapHeight)
        {
            this.quads = new Quad[mapWidth, mapHeight];

            Random random = new Random();

            IBarrier[] barriers =this.barriers.ToArray();

            //add barriers to the map
            foreach (IBarrier barrier in barriers)
            {
                Location location;
                
                int x;
                int y;
                int width_ = barrier.getBarrierWidth();
                int height_ = barrier.getBarrierHeight();

                do
                {
                    location = generateRandomLocation(mapWidth, mapHeight);
                    x = location.getX();
                    y = location.getY();
                } while (!testLocation(quads, x, y, width_, height_));

                for (int i = x; i < x + width_; i++)
                {
                    for (int j = y; j < y + height_; j++)
                    {
                        quads[i, j] = new Quad(new Location(i, j));
                        quads[i, j].SetBarrier(barrier);
                    }
                }

            }

        }

        private Location generateRandomLocation(int width, int height)
        {
            Random random = new Random();
            int x=random.Next(width);
            int y=random.Next(height);
            return new Location(x, y);
        }


        //add barriers is true or false method
        private bool testLocation(Quad[,] quads, int x, int y, int width, int height)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    if (quads[i, j].GetIsBarrier())
                    {
                        return false;
                    }

                }
            }
            return true;
        }



    }




}
