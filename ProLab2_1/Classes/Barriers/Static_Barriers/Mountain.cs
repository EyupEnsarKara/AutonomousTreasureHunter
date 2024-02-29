using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Mountain:Barrier,IBarrier
    {   
        private static int mountainId = 1;

        public Mountain():base(mountainId)
        {
            mountainId++;
            SetBarrierSize();
        }

 



        public void SetBarrierSize()
        {
            this.SetHeight(15);
            this.SetWidth(15);
        }
    }
}
