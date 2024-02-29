using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Stone:Barrier,IBarrier
    {
        private static int stoneId = 1;

        public Stone():base(stoneId)
        {
            stoneId++;
            SetBarrierSize();
        }




        public void SetBarrierSize()
        {

            Random random = new Random();
            int temp =random.Next(1, 3);
            this.SetWidth(temp);
            this.SetHeight(temp);

        }
    }
}
