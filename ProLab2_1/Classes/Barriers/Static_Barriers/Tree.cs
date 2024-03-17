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

        public Tree(Image image) : base(image,"Tree")
        {
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
    internal class summerTree : Tree
    {
        public summerTree() : base(Resources.Summer_Tree)
        {
        }
    }
    internal class winterTree : Tree
    {
        public winterTree() : base(Resources.Winter_Tree)
        {
        }
    }
}
