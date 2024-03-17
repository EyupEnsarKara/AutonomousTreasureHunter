using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
    public enum Directions
    {
        Left, Right,
        Top, Bottom
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

        Directions tempDirect = Directions.Right;
        private int onceMovedSize = 0;

        public void automaticallyMove(Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y = CurrentLocation.getY();

            if (!checkLocation(tempDirect, quads) && onceMovedSize < 1)
            {
                move(tempDirect, quads);
                onceMovedSize++;

            }
            else
            {

                tempDirect = getDirection(quads);
                onceMovedSize = 0;
            }

            updateFogRemoveArea(quads);


        }
        class element
        {
            public Directions direction;
            public int priority;
        }
        private bool isLooping = false;
        public Directions getDirection(Quad[,] quads)
        {
            int L = -1, R = -1, T = -1, B = -1;
            element[] directions = new element[4];
            //elementlerin oluşumu
            for (int i = 0; i < 4; i++) directions[i] = new element();


            if (!checkLocation(Directions.Left, quads))
            {
                directions[0].direction = Directions.Left;
                directions[0].priority = 3;
            }
            else
            {
                directions[0].direction = Directions.Left;
                directions[0].priority = 0;
            }
            if (!checkLocation(Directions.Right, quads))
            {
                directions[1].direction = Directions.Right;
                directions[1].priority = 3;
            }
            else
            {
                directions[1].direction = Directions.Right;
                directions[1].priority = 0;
            }
            if (!checkLocation(Directions.Top, quads))
            {
                directions[2].direction = Directions.Top;
                directions[2].priority = 3;
            }
            else
            {
                directions[2].direction = Directions.Top;
                directions[2].priority = 0;
            }
            if (!checkLocation(Directions.Bottom, quads))
            {
                directions[3].direction = Directions.Bottom;
                directions[3].priority = 3;
            }
            else
            {
                directions[3].direction = Directions.Bottom;
                directions[3].priority = 0;
            }

            //şimdi de ziyaret edilen yönlerin önceliğini düşelim

            foreach (element element in directions)
            {
                if (element.priority != 0)
                    if (checkIsVisited(element.direction, quads))
                    {
                        element.priority = 1;
                    }
                //araya bide zaten gittiği yönün değerini arttırmakla başlayalım
                if (element.direction == tempDirect && element.priority == 3)
                {
                    element.priority = 4;
                }
                if (element.direction == tempDirect && isLooping && element.priority != 0)
                {
                    element.priority = 2;
                }


            }


            //şimdi de duruma göre en uygununu göndermesini sağlamak lazım demi :)
            //Console.WriteLine("-----------------------------------");
            foreach (element element in directions)
            {
             //   Console.WriteLine("Yön: " + element.direction + "  Öncelik: " + element.priority);
            }
            int count_visitedPaths = 0;
            foreach (element element in directions)
            {
                if (element.priority == 4) return element.direction;
                if (element.priority <= 2) count_visitedPaths++;
            }
            if (count_visitedPaths == 4) isLooping = true;
            else isLooping = false;


            //normal boş yol
            foreach (element element in directions)
            {
                if (element.priority == 3) return element.direction;
            }
            //bu arkadaş da döngü için
            foreach (element element in directions)
            {
                if (element.priority == 2) return element.direction;
            }





            //buda ziyaret edilenler için
            foreach (element element in directions)
            {
                if (element.priority > 0) return element.direction;
            }







            //buda boş kalmaması için :D
            return Directions.Bottom;


            //4 gelidği yönden devam
            //3 başlangıçta verilen normal yol
            //2döngüdeyken kurtaracak yol
            //1 zaten geldiği yol


        }
        private bool checkIsVisited(Directions direction, Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y = CurrentLocation.getY();

            switch (direction)
            {
                case Directions.Left:
                    return quads[x - 1, y].getIsVisited();

                case Directions.Right:
                    return quads[x + 1, y].getIsVisited();

                case Directions.Top:
                    return quads[x, y - 1].getIsVisited();

                case Directions.Bottom:
                    return quads[x, y + 1].getIsVisited();
            }
            return false;
        }





        private bool checkLocation(Directions direction, Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y = CurrentLocation.getY();
            bool barrierDetected = false;
            int max_lenght = quads.GetLength(0);

            switch (direction)
            {
                case Directions.Left:
                    if (x - 1 < 0) return true;
                    if (quads[x - 1, y].GetIsBarrier()) return true;

                    break;
                case Directions.Right:
                    if (x + 1 >= max_lenght) return true;
                    if (quads[x + 1, y].GetIsBarrier()) return true;
                    break;
                case Directions.Top:
                    if (y - 1 < 0) return true;
                    if (quads[x, y - 1].GetIsBarrier()) return true;
                    break;
                case Directions.Bottom:
                    if (y + 1 >= max_lenght) return true;
                    if (quads[x, y + 1].GetIsBarrier()) return true;
                    break;
            }

            return barrierDetected;

        }



        private void move(Directions direction, Quad[,] quads)
        {
            int x = CurrentLocation.getX(), y = CurrentLocation.getY();
            AddVisitedLocation();

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
            }
            quads[x, y].setIsVisited();
            CurrentLocation = new Location(x, y);
        }



        private Directions getLastDirection()
        {
            Location lastLocation = VisitedLocations[VisitedLocations.Count - 1];
            int x = lastLocation.getX(), y = lastLocation.getY();
            int current_x = CurrentLocation.getX(), current_y = CurrentLocation.getY();

            if (current_x == x)
            {
                if (current_y < y) return Directions.Top;
                else return Directions.Bottom;
            }
            else
            {
                if (current_x < x) return Directions.Right;
                else return Directions.Left;
            }


        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------

        // Move fonksiyonunuza entegre etme
        






    }

}
