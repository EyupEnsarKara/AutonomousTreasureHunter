using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Dynamic_Barriers
{
    internal class Bee:Barrier,IBarrier
    {   
        private static int beeId = 1;

        public Bee(): base(beeId)
        {
            beeId++;
            SetBarrierSize();
        }




        public void SetBarrierSize()
        {
            this.SetWidth(2);
            this.SetHeight(2);


        }

    }
}
