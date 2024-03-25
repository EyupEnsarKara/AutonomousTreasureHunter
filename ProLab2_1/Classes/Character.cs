using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
    public enum Directions
    {
        Left, Right,
        Top, Bottom,None
    }
    public class Character
    {



        private int Id;
        private string Name;
        private List<Location> VisitedLocations = new List<Location>();
        private Location CurrentLocation;
        private List<Chest> Collected_Chests = new List<Chest>();


        public Character(int id, string name, Location CurrentLocation)
        {
            Id = id;
            Name = name;
            this.CurrentLocation = CurrentLocation;


        }




        public void updateFogRemoveArea(Quad[,] quads)
        {
            int x = CurrentLocation.getX();
            int y = CurrentLocation.getY();
            int width = quads.GetLength(0);
            int height = quads.GetLength(1);
            for (int i = (x + 3); i >= (x - 3); i--)
            {

                for (int j = (y + 3); j >= (y - 3); j--)
                {
                    if (i < 0 || j < 0 || i >= width || j >= height) continue;
                    quads[i, j].removeFog();
                    if (quads[i, j].GetIsBarrier())
                    {
                        int id = quads[i, j].getBarrierID();

                        if (!Program.map.getDiscoveredIds().Contains(id))
                        {
                            Program.map.getDiscoveredIds().Add(id);
                            Program.map.addLineToFoundList(quads[i, j].getBarrierName()+" Has discovered! ("+i+","+j+")");
                        }

                    }
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
            VisitedLocations.Add(new Location(CurrentLocation.getX(), CurrentLocation.getY()));
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


        List<Node> path = new List<Node>();

        public void automaticallyMove(Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y = CurrentLocation.getY();

            Location chest_location = checkChestLocation(quads);
            updateFogRemoveArea(quads);



            if (chest_location != null)
            {
                path = Functions.AStar(Program.map.ConvertToIntArray(), new Node(x, y), chest_location.ConvertNode(), Program.map.getMapSize());
                Location location = path[0].ConvertToLocation();
                path.RemoveAt(0);
            }
            if (path != null)
            {
                if (path.Count > 0)
                {
                    Location location = path[0].ConvertToLocation();
                    path.RemoveAt(0);

                    move(calculateDirectionToChest(location), quads);

                    return;
                }
            }






            getNearestFogLocation(quads);
            if (targetLocation != null)
            {

                path = Functions.AStar(Program.map.ConvertToIntArray(), new Node(x, y), targetLocation.ConvertNode(), Program.map.getMapSize());
            }
            updateFogRemoveArea(quads);





        }

        private int hesap = 0;

        private Location targetLocation = null;

        private int visibilty = 3; //7x7 lik alan için 
        private void getNearestFogLocation(Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y=CurrentLocation.getY();
            int mapsize = quads.GetLength(0);

            for (int i = Math.Max(x-visibilty,0); i < Math.Min(x+visibilty,mapsize); i++)
            {

                for (int j = Math.Max(y - visibilty, 0); j < Math.Min(y + visibilty, mapsize); j++)
                {
                    if (quads[i, j].GetIsBarrier())
                    {
                        quads[i,j].removeFog();
                        continue;
                    }
                    if(quads[i, j].getIsFoggy())
                    {
                        visibilty = 3;
                        targetLocation= new Location(i, j);
                        Console.WriteLine("Alınan nokta X:"+targetLocation.getX()+"  Y:"+targetLocation.getY()+"   visibility:"+visibilty);
                    }

                }
            }
            visibilty++;
        }

        
        




        private Location checkChestLocation(Quad[,] quads)
        {
            int x = CurrentLocation.getX(),y=CurrentLocation.getY();
            int maxMap = quads.GetLength(0);
            for(int i = x-3;i<=x+3;i++)
            {
                for(int j = y-3;j<=y+3;j++)
                {
                    if(i<0 || j<0 || i>=maxMap || j>=maxMap) continue;
                    if (quads[i, j].getCollectible()) return new Location(i,j);
                }
            }
            return null;
        }
        private Directions calculateDirectionToChest(Location location)
        {
            int x = CurrentLocation.getX(),y = CurrentLocation.getY();
            int chest_X = location.getX(), chest_Y = location.getY();
            if (x < chest_X) return Directions.Right;
            if (x > chest_X) return Directions.Left;
            if (y < chest_Y) return Directions.Bottom;
            if(y > chest_Y)return Directions.Top;

            return Directions.None;

        }



        private void move(Directions direction, Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y = CurrentLocation.getY();
            bool notEdited = false;
            switch (direction)
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
                default:
                    notEdited = true;
                    break;
            }
            if(!notEdited)
            {
                AddVisitedLocation();
                hesap++;
                quads[x, y].setIsVisited();
                CurrentLocation = new Location(x, y);
            }
        }

        public int getCountOfMovements()
        {
            return hesap;
        }





    }

}
