using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers
{
    public class Barrier
    {
        private int width;
        private  int height;
        private int id;
        private Location location;
        
        public Barrier(int id)
        {
        }
        public void SetWidth(int width)
        {
            this.width = width;
        }
        
        public void SetHeight(int height)
        {
            this.height = height;
        }
        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetWidth()
        {
            return this.width;
        }
        public int GetHeight()
        {
            return this.height;
        }
        public int GetId()
        {
            return this.id;
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
}
