﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousTreasureHunter.Classes.Barriers.Static_Barriers
{
    internal class Stone:Barrier,IBarrier
    {

        public Stone(Image image,string theme):base(image,"Stone",theme)
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
            int temp =random.Next(1, 3);
            this.SetWidth(temp);
            this.SetHeight(temp);

        }
    }
    internal class summerStone : Stone
    {
        public summerStone() : base(Resources.Summer_Stone, "summer")
        {
        }
        public override IBarrier changeObjectTheme()
        {
            return new winterStone();
        }
    }
    internal class winterStone : Stone
    {
        public winterStone() : base(Resources.Winter_Stone, "winter")
        {
        }
        public override IBarrier changeObjectTheme()
        {
            return new summerStone();
        }
    }
    
}
