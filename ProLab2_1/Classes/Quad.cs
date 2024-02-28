using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
    public class Quad
    {
        private Location location;
        private bool isBarrier=false;
        private int id;
        private string barrierType;

        public Quad(Location location)
        {
            this.location = location;
            

        }

        public Location GetLocation()
        {
            return this.location;
        }

        public void SetLocation(Location location)
        {
            this.location = location;
        }

    }
}
