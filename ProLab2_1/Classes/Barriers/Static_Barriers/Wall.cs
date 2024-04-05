using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousTreasureHunter.Classes.Barriers.Static_Barriers
{
    internal class Wall:Barrier,IBarrier
    {

        public Wall(Image image,string theme):base(image,"Wall", theme)
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
        public summerWall() : base(Resources.summer_wall, "summer")
        {
            
        }
        public override IBarrier changeObjectTheme()
        {
            return new winterWall();
        }
    }
        internal class winterWall:Wall
            {
                public winterWall() : base(Resources.winter_wall,"winter")
                {
            
                }
        public override IBarrier changeObjectTheme()
        {
            return new summerWall();
        }
    }
}
