using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Dynamic_Barriers
{
    internal class Bee:IBarrier
    {   
        private static int beeId = 0;
        private int size;
        private int id;
        public Bee()
        {
        }
        public int GetBarrierId()
        {
            return this.id;
        }



        public void SetBarrierSize()
        {

         this.size = 2;

        }

    }
}
