using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Wall:IBarrier
    {
        private static int wallId = 0;
        private int size;
        private int id;
        public Wall()
        {
            SetBarrierId();
        }
        public int GetBarrierId()
        {
            return this.id;
        }

        public void SetBarrierId()
        {
            this.id = wallId;
            wallId++;
        }

        public void SetBarrierSize()
        {
            this.size = 10;            
        }
    }
}
