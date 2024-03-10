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
        private Character character;

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



        public void generateRandomMap()
        {
            Console.WriteLine("Generating Map...");

            Random random = new Random();

            IBarrier[] barriers =this.barriers.ToArray();

            foreach (IBarrier barrier in barriers)
            {
                Location location;
                
                int x;
                int y;
                int width_ = barrier.getBarrierWidth();
                int height_ = barrier.getBarrierHeight();

                if(barrier is DynamicBarrier)
                {   DynamicBarrier barrier_ = (DynamicBarrier)barrier;

                    if (barrier is Bee)
                    {
                        width_+=barrier_.getMaxMove()*2-1;
                    }
                    else if (barrier is Bird)
                    {
                        height_ += barrier_.getMaxMove() * 2 - 1;

                    }
                    Console.WriteLine("width : "+width_);
                    Console.WriteLine("h : "+height_);

                }
             

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
                        
                        quads[i, j].SetBarrier(barrier);
                    }
                }
                barrier.setLocation(new Location(x,y));
                
            }
            Console.WriteLine("Generated Barriers");

            Location playerLocation = generateRandomLocation(mapSize, mapSize);
            while (quads[playerLocation.getX(),playerLocation.getY()].GetIsBarrier())
            {
                playerLocation = generateRandomLocation(mapSize, mapSize);
            }
            character=new Character(1, "Steve", playerLocation);
            Console.WriteLine("Generated player location");
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
            bool isSummer = quads[x, y].GetIsSummer();

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
                    if (quads[i, j].GetIsSummer() != isSummer)
                    {
                        return false;
                    }


                }
            }
            return true;
        }

        public void clearFoggedAllArea()
        {
            for(int i = 0; i < quads.GetLength(0); i++)
            {
                for (int j = 0; j < quads.GetLength(1); j++)
                {
                    quads[i, j].removeFog();
                }
            }
        }

        public List<IBarrier> GetBarriers()
        {
            return barriers;
        }
        
        public Quad[,] GetQuads()
        {
            return quads;
        }
        public Character GetCharacter()
        {
            return character;
        }





    }




}
