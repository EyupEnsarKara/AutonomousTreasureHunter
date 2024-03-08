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

        public Wall():base(wallId, Resources.Winter_Rock)
        {
            wallId++;
            SetBarrierSize();

        }

        public int getBarrierHeight()
        {
            return (int)this.GetHeight();
        }

        public int getBarrierWidth()
        {
            return (int)this.GetWidth();
        }
        public void SetBarrierSize()
        {
            SetWidth(10);
            SetHeight(1);
        }
    }
}
