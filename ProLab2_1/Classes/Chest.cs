using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
    public class Chest
    {
        private Image image;
        private int Value;
        private int width;
        private int height;
        private Location location;
        

        public Chest(Image image, int value)
        {
            this.image = image;
            Value = value;
            this.height = 3;
            this.width = 3;
        }

        public Image getImage()
        {
            return this.image;
        }
        public int getValue()
        {
            return this.Value;
        }
        public int getWidth()
        {
            return this.width;
        }
        public int getHeight()
        {
            return this.height;
        }
        public Location getLocation()
        {
            return this.location;
        }
        public void setLocation(Location location)
        {
            this.location = location;
        }
    }



    public class Golden_Chest : Chest
    {



        public Golden_Chest() : base(Resources.Golden_Chest,100)
        {

        }
    }

    public class Silver_Chest : Chest
    {
        public Silver_Chest() : base(Resources.Silver_Chest,50)
        {

        }

    }

    public class Emerald_Chest : Chest
    {
        public Emerald_Chest() : base(Resources.Emerald_Chest,200)
        {

        }
    }

    public class Copper_Chest : Chest
    {
        public Copper_Chest(): base(Resources.Copper_Chest,20)
        {

        }
    }

}
