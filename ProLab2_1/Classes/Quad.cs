using ProLab2_1.Classes.Barriers;
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
        private object barrier;

        public Quad(Location location)
        {
            this.location = location;
            
        }
        public void SetBarrier(IBarrier barrier)
        {
            this.isBarrier = true;
            this.id= barrier.GetId();
            this.barrier = barrier;
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
