using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Wall:Barrier,IBarrier
    {

        public Wall(Image image):base(image,"Wall")
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
            SetWidth(10);
            SetHeight(1);
        }
    }
    internal class summerWall:Wall
    {
        public summerWall() : base(Resources.Winter_Rock)
        {
            
        }
    }
        internal class winterWall:Wall
            {
                public winterWall() : base(Resources.Winter_Rock)
                {
            
                }
            }
}
