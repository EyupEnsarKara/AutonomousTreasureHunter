using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Tree:Barrier,IBarrier
    {
        private static int treeId = 1;

        public Tree() : base(treeId)
        {
            treeId++;
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
            Random random = new Random();
            int size = random.Next(2, 6);
            SetWidth(size);
            SetHeight(size);
        }
    }
}
