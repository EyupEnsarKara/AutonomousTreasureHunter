using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Dynamic_Barriers
{
    internal class Bird:IBarrier
    {
        private static int birdId = 0;

        private int id;
        public Bird()
        {
            SetBarrierId();
        }
        public int GetBarrierId()
        {
            return this.id;
        }

        public void SetBarrierId()
        {
            this.id= birdId;
            birdId++;
        }

    }
}
