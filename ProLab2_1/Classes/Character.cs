using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
    public enum Directions
    {
        Left,Right,
        Top,Bottom
    }
    public class Character
    {
        


        private int Id;
        private string Name;
        private List<Location> VisitedLocations= new List<Location>();
        private Location CurrentLocation;
        private List<Chest> Collected_Chests = new List<Chest>();


        public Character(int id, string name,Location CurrentLocation)
        {
            Id = id;
            Name = name;
            this.CurrentLocation = CurrentLocation;
            VisitedLocations.Add(CurrentLocation);
        }



        public void updateFogRemoveArea(Quad[,] quads)
        {
            int x=CurrentLocation.getX();
            int y=CurrentLocation.getY();
            int width = quads.GetLength(0);
            int height = quads.GetLength(1);
            for (int i = (x+3); i >=(x-3); i--)
            {

                for (int j = (y+3); j >=(y-3); j--)
                {
                    if(i<0 || j<0 || i>=width || j >= height) continue;
                    quads[i, j].removeFog();
                }
            }
            
            
        }
        
        public int GetId()
        {
            return Id;
        }
        public string GetName()
        {
            return Name;
        }

        public void AddVisitedLocation()
        {
            VisitedLocations.Add(new Location(CurrentLocation.getX(),CurrentLocation.getY()));
        }
        public List<Location> GetVisitedLocations()
        {
            return VisitedLocations;
        }
        public Location GetCurrentLocation()
        {
            return CurrentLocation;
        }
        
        public void CollectChest(Chest chest)
        {
            Collected_Chests.Add(chest);
        }

        public List<Chest> GetCollectedChests()
        {
            return Collected_Chests;
        }

        Directions tempDirect = Directions.Right;


        public void automaticallyMove(Quad[,] quads)
        {
            int x = CurrentLocation.getX(),y = CurrentLocation.getY();

            if (!checkLocation(tempDirect, quads))
            {
                move(tempDirect, quads);
                Console.WriteLine("mOOve");

            }    
            else
            {
                
                tempDirect = getDirection(quads);
                Console.WriteLine(tempDirect);

            }
                
            updateFogRemoveArea(quads);

            
        }
        public Directions getDirection(Quad[,] quads)
        {
            int L=-1, R=-1, T=-1, B=-1;

            if(!checkLocation(Directions.Left,quads))
            {
                L = 1;
            }
            if (!checkLocation(Directions.Right, quads))
            {
                R = 2;
            }
            if (!checkLocation(Directions.Top, quads))
            {
                T = 3;
            }
            if (!checkLocation(Directions.Bottom, quads))
            {
                B = 4;
            }

            Random random = new Random();
            int tempDirect = random.Next(1, 5);
            Directions direct=Directions.Right;
            switch(tempDirect)
            {
                case 1:
                    if (tempDirect != L)
                        break;
                    direct=Directions.Left;
                    break;
                case 2:
                    if (tempDirect != R)
                        break;
                    direct = Directions.Right;
                    break;
                case 3:
                    if (tempDirect != T)
                        break;
                    direct = Directions.Top;
                    break;
                case 4:
                    if (tempDirect != B)
                        break;
                    direct = Directions.Bottom;
                    break;

            }
            checkChest(quads);
            if (checkChest(quads) != null)
            {
                moveTowardsChest(checkChest(quads), quads);
            }

                
            Console.WriteLine("L:"+L+" R:"+R+" T:"+T+" B:"+B);
            if ((L == -1) && (R == -1) && (T == -1) )
                return getLastDirection();
            else if ((L == -1) && (R == -1) &&  (B == -1))
                return getLastDirection();
            else if ((L == -1) &&  (T == -1) && (B == -1))
                return getLastDirection();
            else if ((R == -1)  && (T == -1) && (B == -1))
                return getLastDirection();
            else if (direct==getLastDirection())
            {
                 return getDirection(quads);
            }
            else 
                return direct;
          



        }
        public Directions getLastDirection()
        {
            Location lastLocation = VisitedLocations[VisitedLocations.Count - 1];
            int x = lastLocation.getX(), y = lastLocation.getY();
            int x1 = CurrentLocation.getX(), y1 = CurrentLocation.getY();
            if (x1 == x)
            {
                if (y1 < y)
                    return Directions.Bottom;
                else
                    return Directions.Top;
            }
            else
            {
                if (x1 > x)
                    return Directions.Left;
                else
                    return Directions.Right;
            }
        }
        public Location checkChest(Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y = CurrentLocation.getY();
            int width = quads.GetLength(0);
            int height = quads.GetLength(1);
            for (int i = (x + 3); i >= (x - 3); i--)
            {

                for (int j = (y + 3); j >= (y - 3); j--)
                {
                    if (i < 0 || j < 0 || i >= width || j >= height) continue;
                    if (quads[i, j].getCollectible())
                    {
                        //return locaiton of the chest
                        return new Location(i, j);
         
                    }
                }
            }
            return null;
        }

        public void moveTowardsChest(Location chestLocation, Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y = CurrentLocation.getY();
            int x1 = chestLocation.getX(), y1 = chestLocation.getY();
            if (x1 == x)
            {
                if (y1 < y)
                    move(Directions.Bottom, quads);
                else
                    move(Directions.Top, quads);
            }
            else
            {
                if (x1 > x)
                    move(Directions.Left, quads);
                else
                    move(Directions.Right, quads);
            }
        }







        private bool checkLocation(Directions direction, Quad[,] quads)
        {
            int x = CurrentLocation.getX(),y = CurrentLocation.getY();
            bool barrierDetected = false;
            int max_lenght = quads.GetLength(0);
            
            switch(direction)
            {
                case Directions.Left:
                    if (x - 1 < 0) return true;
                    for (int i =x;i >= x - 1;i--)
                    {
                        if (quads[i,y].GetIsBarrier()) barrierDetected = true;
                        
                    }
                    
                    break;
                case Directions.Right:
                    if (x + 1 >= max_lenght) return true;
                    for (int i = x; i <= x + 1 ; i++)
                    {
                        if (quads[i, y].GetIsBarrier()) barrierDetected = true;

                    }
                    break;
                case Directions.Top:
                    if (y - 1 <0) return true;
                    for (int i = y; i >= y - 1 ; i--)
                    {
                        if (quads[x, i].GetIsBarrier()) barrierDetected = true;
                    }
                    break;
                case Directions.Bottom:
                    if (y + 1 >= max_lenght) return true;
                    for (int i = y; i <= y + 1 ; i++)
                    {
                        if (quads[x, i].GetIsBarrier()) barrierDetected = true;
                    }
                    break;
            }

            return barrierDetected;

        }



        private void move(Directions direction, Quad[,] quads)
        {
            int x=CurrentLocation.getX(),y=CurrentLocation.getY();
            AddVisitedLocation();
            
            switch(direction)
            {
                case Directions.Left:
                    x--;
                    break;
                case Directions.Right:
                    x++;
                    break;
                case Directions.Top:
                    y--;
                    break;
                case Directions.Bottom:
                    y++;
                    break;
            }
            quads[x,y].setIsVisited(true);
            CurrentLocation = new Location(x,y);
        }




    }
}
