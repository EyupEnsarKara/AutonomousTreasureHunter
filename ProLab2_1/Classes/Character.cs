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
            bool foundBarrier;

            // Ziyaret edilen konumları işaretlemek için isVisited değerini true yap
            quads[x, y].setIsVisited(true);

            // Görüş alanındaki koordinatları temsil eden bir döngü
            for (int i = x - 3; i <= x + 3; i++)
            {
                for (int j = y - 3; j <= y + 3; j++)
                {
                    if (i >= 0 && i < quads.GetLength(0) && j >= 0 && j < quads.GetLength(1))
                    {
                        if (quads[i, j].getCollectible())
                        { // Eğer görüş alanında bir toplanabilir nesne varsa
                          // O nesneye doğru git
                            if (i > x)
                            {
                                AddVisitedLocation();
                                CurrentLocation.setX(x + 1);
                                updateFogRemoveArea(quads);
                                return;
                            }
                            else if (i < x)
                            {
                                AddVisitedLocation();
                                CurrentLocation.setX(x - 1);
                                updateFogRemoveArea(quads);
                                return;
                            }

                            if (j > y)
                            {
                                AddVisitedLocation();
                                CurrentLocation.setY(y + 1);
                                updateFogRemoveArea(quads);
                                return;
                            }
                            else if (j < y)
                            {
                                AddVisitedLocation();
                                CurrentLocation.setY(y - 1);
                                updateFogRemoveArea(quads);
                                return;
                            }
                        }
                    }
                }
            }

            // Eğer toplanabilir bir nesne yoksa rastgele bir yöne git
            int direction;
            do
            {
                direction = random.Next(0, 4); // Rastgele bir yön seç
            } while (direction == (tempDirection + 2) % 4); // Geldiği yöne geri dönmemesi için kontrol

            tempDirection = direction; // Geldiği yönü kaydet

            switch (direction)
            {
                case 0: // Sağa git
                    if (x < quads.GetLength(0) - 1 && !quads[x + 1, y].GetIsBarrier() && !quads[x + 1, y].getIsVisited())
                    {
                        AddVisitedLocation();
                        CurrentLocation.setX(x + 1);
                        updateFogRemoveArea(quads);
                    }
                    break;

                case 1: // Sola git
                    if (x > 0 && !quads[x - 1, y].GetIsBarrier() && !quads[x - 1, y].getIsVisited())
                    {
                        AddVisitedLocation();
                        CurrentLocation.setX(x - 1);
                        updateFogRemoveArea(quads);
                    }
                    break;

                case 2: // Yukarı git
                    if (y > 0 && !quads[x, y - 1].GetIsBarrier() && !quads[x, y - 1].getIsVisited())
                    {
                        AddVisitedLocation();
                        CurrentLocation.setY(y - 1);
                        updateFogRemoveArea(quads);
                    }
                    break;

                case 3: // Aşağı git
                    if (y < quads.GetLength(1) - 1 && !quads[x, y + 1].GetIsBarrier() && !quads[x, y + 1].getIsVisited())
                    {
                        AddVisitedLocation();
                        CurrentLocation.setY(y + 1);
                        updateFogRemoveArea(quads);
                    }
                    break;
            }
        }



    }
}
