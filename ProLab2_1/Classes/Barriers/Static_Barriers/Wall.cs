using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Wall:Barrier,IBarrier
    {
        private static int wallId = 1;

        public Wall():base(wallId)
        {
            wallId++;
            SetBarrierSize();

        }


        public void SetBarrierSize()
        {
            SetWidth(10);
            SetHeight(1);
        }
    }
}
