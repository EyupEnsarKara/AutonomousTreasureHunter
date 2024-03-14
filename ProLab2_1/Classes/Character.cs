using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
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

        int tempDirection = 0;  

        public void automaticallyMove(Quad[,] quads)
        {
            Random random = new Random();
            int x = CurrentLocation.getX();
            int y = CurrentLocation.getY();

            int direction;
          
            do
            {
                direction = random.Next(0, 4);
            } while ((tempDirection == 0 && direction == 1) || (tempDirection == 2 && direction == 3));

            switch (direction)
            {
                case 0:
                    if (x >= quads.GetLength(0) - 1 || quads[x + 3, y].GetIsBarrier())
                        break;
                    AddVisitedLocation();
                    CurrentLocation.setX(x + 1);
                    break;
                case 1:
                    if (x <= 0 || quads[x - 3, y].GetIsBarrier())
                        break;
                    AddVisitedLocation();

                    CurrentLocation.setX(x - 1);
                    break;
                case 2:
                    if (y <= 0 )
                        if(quads[x, y - 3].GetIsBarrier())
                        break;
                    AddVisitedLocation();
                    CurrentLocation.setY(y - 1);
                    break;
                case 3:
                    if (y >= quads.GetLength(1) - 1 || quads[x, y + 3].GetIsBarrier())
                        break;
                    AddVisitedLocation();
                    CurrentLocation.setY(y + 1);
                    break;
            }
            tempDirection = direction;


            updateFogRemoveArea(quads);



        }

    }
}
