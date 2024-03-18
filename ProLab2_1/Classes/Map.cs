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
using ProLab2_1.Classes.Barriers.Static_Barriers;

namespace ProLab2_1.Classes
{ 



    


    public class Map
    {
        private Quad[,] quads;
        private int mapSize;

        private List<IBarrier> barriers = new List<IBarrier>();
        private Character character;
        private List<Chest> chests = new List<Chest>();
        private string foundList = string.Empty;
        private List<int> discoveredIDs = new List<int>();
        public void AddBarrier(IBarrier barrier)
        {
            barriers.Add(barrier);
        }


        public Map(int mapSize)
        {
            this.mapSize = mapSize;
            quads= new Quad[mapSize,mapSize];
            addBarriers();
            generateEmptyMap();

        }

        public void addBarriers()
        {
            //for default barriers
            for (int i = 0; i < 2; i++)
            {
                AddBarrier(new Bee());
                AddBarrier(new Bird());
                AddBarrier(new summerMountain());
                AddBarrier(new summerStone());
                AddBarrier(new summerTree());
                AddBarrier(new summerWall());
                AddBarrier(new Bee());
                AddBarrier(new Bird());
                AddBarrier(new winterMountain());
                AddBarrier(new winterStone());
                AddBarrier(new winterTree());
                AddBarrier(new winterWall());

            }
            //for default chests
            for (int i = 0; i < 5; i++)
            {
                addChest(new Golden_Chest());
                addChest(new Emerald_Chest());
                addChest(new Copper_Chest());
                addChest(new Silver_Chest());
                    
            }

            //for random adding barriers
            Type[] barrierTypes = {typeof(Bee),typeof(Bird),typeof(summerMountain),typeof(winterMountain),typeof(summerStone),typeof(winterStone),typeof(winterTree),typeof(summerTree),typeof(summerWall),typeof(winterWall)};

            Random random = new Random();

            for(int i = 0;i <mapSize/5;i++)
            {
                AddBarrier((IBarrier)Activator.CreateInstance(barrierTypes[random.Next(barrierTypes.Length)]));
            }

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
                    location = generateRandomLocation(mapSize, mapSize, random);
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
            generateChestLocations(random);

            Location playerLocation = generateRandomLocation(mapSize, mapSize, random);
            while (quads[playerLocation.getX(),playerLocation.getY()].GetIsBarrier())
            {
                playerLocation = generateRandomLocation(mapSize, mapSize,random);
            }
            character=new Character(1, "Steve", playerLocation);
            Console.WriteLine("Generated player location");
            optimizeMap();
        }
        public void optimizeMap()
        {
            for(int i = 0;i<barriers.Count;i++)
            {
                IBarrier barrier = barriers[i];
                if (barrier.getTheme() == "summer" && barrier.getLocation().getX() < mapSize / 2)
                {
                    barriers.RemoveAt(i);
                    IBarrier barrier1 = barrier.changeObjectTheme();
                    barrier1.setLocation(barrier.getLocation());
                    barriers.Add(barrier1);
                    i = 0;
                }
                else if (barrier.getTheme() == "winter" && barrier.getLocation().getX() > mapSize / 2)
                {
                    barriers.RemoveAt(i);
                    IBarrier barrier1 = barrier.changeObjectTheme();
                    barrier1.setLocation(barrier.getLocation());
                    barriers.Add(barrier1);
                    i = 0;
                }
            }
        }

        public void generateChestLocations(Random random)
        {
            Console.WriteLine("Generating Map...");



            foreach (Chest chest in chests)
            {
                Location location;

                int x;
                int y;
                int width_ = chest.getWidth();
                int height_ = chest.getHeight();



                do
                {
                    location = generateRandomLocation(mapSize, mapSize,random);
                    x = location.getX();
                    y = location.getY();
                   
                } while (!testLocation(x, y, width_, height_));

                for (int i = x; i < x + width_; i++)
                {
                    for (int j = y; j < y + height_; j++)
                    {

                        quads[i, j].setCollectible();
                    }
                }
                Console.WriteLine("Sanıdk konumu atandı : "+x+" y:"+y);
                chest.setLocation(new Location(x, y));

            }
            Console.WriteLine("Generated Chests");


        }

        private Location generateRandomLocation(int width, int height,Random random)
        {
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
                    if (quads[i,j].getCollectible())
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
        public void makeFoggedAllArea()
        {
            for (int i = 0; i < quads.GetLength(0); i++)
            {
                for (int j = 0; j < quads.GetLength(1); j++)
                {
                    quads[i, j].setFog();
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

        public void addChest(Chest chest)
        {
            chests.Add(chest);
        }
        public List<Chest> GetChests()
        {
            return this.chests;
        }

        public void removeChest(Chest chest)
        {
            int x = chest.getLocation().getX();
            int y = chest.getLocation().getY();

            for(int i = x; i < x + chest.getWidth(); i++)
            {
                for(int j = y; j < y + chest.getHeight(); j++)
                {
                    quads[i, j].resetCollectible();
                }
            }   
            chests.Remove(chest);
        }
        public int[,] ConvertToIntArray()
        {
            int[,] array= new int[mapSize,mapSize];
            for(int i = 0; i <mapSize; i++)
            {
                for (int j = 0; j <mapSize; j++)
                {
                    if (quads[i,j].GetIsBarrier()) array[i,j] = 1;
                    else array[i,j] = 0;
                }
            }
            return array;
        }
        public int getMapSize()
        {
            return mapSize;
        }
        public int[,] ConvertToVisibiltyIntArray(int size,int startX,int StartY)
        {
            int convertsize= (2*size)+1;
            int[,] array = new int[convertsize, convertsize];
            int innerX=0, innerY=0;
            for (int i = Math.Max(0, startX - size); i < Math.Min(startX + size,mapSize); i++,innerX++)
            {
                innerY = 0;
                for (int j = Math.Max(0, StartY - size); j < Math.Min(StartY + size, mapSize); j++,innerY++)
                {
                    Console.WriteLine("i: "+i+"   j:"+j+"    size:"+size+"   innerX"+innerX+"   innerY"+innerY);
                    if (quads[i, j].GetIsBarrier()) array[innerX, innerY] = 1;
                    else array[innerX,innerY] = 0;
                }
            }
            return array;
        }
        public string getFoundList()
        { return foundList; }
        public void addLineToFoundList(string str)
        {
            foundList=foundList+"\n"+str;
        }
        public List<int> getDiscoveredIds()
        {
            return discoveredIDs;
        }


    }




}
