using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Stone:IBarrier
    {
        private static int stoneId = 0;
        private int size;
        private int id;
        public Stone()
        {
            SetBarrierId();
        }
        public int GetBarrierId()
        {
            return this.id;
        }

        public void SetBarrierId()
        {
            this.id = stoneId;
            stoneId++;
        }

        public void SetBarrierSize()
        {

            Random random = new Random();
            this.size = random.Next(1, 3);

        }
    }
}
