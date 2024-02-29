using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Mountain:IBarrier
    {   
        private static int mountainId = 0;

        private int size;

        private int id;
        public Mountain()
        {
        }

        public int GetBarrierId()
        {
            return this.id;
        }



        public void SetBarrierSize()
        {
            this.size = 15;
        }
    }
}
