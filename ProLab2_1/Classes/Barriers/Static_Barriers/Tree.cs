using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Tree:Barrier,IBarrier
    {
        private static int treeId = 1;

        public Tree(Image image) : base(treeId, image)
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
    internal class SummerTree : Tree
    {
        public SummerTree() : base(Resources.Summer_Tree)
        {
        }
    }
    internal class WinterTree : Tree
    {
        public WinterTree() : base(Resources.Winter_Tree)
        {
        }
    }
}
