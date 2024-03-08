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
        private Quad[,] quads;
        private int mapSize;

        private List<IBarrier> barriers = new List<IBarrier>();

        public void AddBarrier(IBarrier barrier)
        {
            barriers.Add(barrier);
        }


        public Map(int mapSize)
        {
            this.mapSize = mapSize;
            quads= new Quad[mapSize,mapSize];
            generateEmptyMap();

        }
        //print map methods
        public void printMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (quads[i, j].GetIsBarrier())
                    {
               

                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
        }


        public void generateRandomMap()
        {
            

            Random random = new Random();

            IBarrier[] barriers =this.barriers.ToArray();

            foreach (IBarrier barrier in barriers)
            {
                Location location;
                
                int x;
                int y;
                int width_ = barrier.getBarrierWidth();
                int height_ = barrier.getBarrierHeight();

                do
                {
                    location = generateRandomLocation(mapSize, mapSize);
                    x = location.getX();
                    y = location.getY();
                } while (!testLocation(x, y, width_, height_));

                for (int i = x; i < x + width_; i++)
                {
                    for (int j = y; j < y + height_; j++)
                    {
                        
                        //quads[i, j] = new Quad(new Location(i, j));
                        quads[i, j].SetBarrier(barrier);
                    }
                }
                barrier.setLocation(new Location(x,y));
                

            }

        }

        private Location generateRandomLocation(int width, int height)
        {
            Random random = new Random();
            int x=random.Next(width);
            int y=random.Next(height);
            return new Location(x, y);
        }
        public void generateEmptyMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {

                    this.quads[i, j] = new Quad(new Location(i, j));
                    if (i >= mapSize / 2) this.quads[i, j].SetSummer();
                }
            }
        }
        private bool testLocation(int x, int y, int width, int height)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {


                    if (i >= mapSize || j >= mapSize)
                    {
                        return false;
                    }
                    

                    if (quads[i, j].GetIsBarrier())
                    {
                        return false;
                    }


                }
            }
            return true;
        }

        public List<IBarrier> GetBarriers()
        {
            return barriers;
        }
        
        public Quad[,] GetQuads()
        {
            return quads;
        }





    }




}
