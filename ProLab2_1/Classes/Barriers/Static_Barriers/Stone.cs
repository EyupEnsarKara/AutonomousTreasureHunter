using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Stone:Barrier,IBarrier
    {
        private static int stoneId = 1;

        public Stone(Image image):base(stoneId,image)
        {
            stoneId++;
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
            int temp =random.Next(1, 3);
            this.SetWidth(temp);
            this.SetHeight(temp);

        }
    }
    //add summer and winter classes
    internal class summerStone : Stone
    {
        public summerStone() : base(Resources.Summer_Stone)
        {
        }
    }
    internal class winterStone : Stone
    {
        public winterStone() : base(Resources.Summer_Stone)
        {
        }
    }
    
}
