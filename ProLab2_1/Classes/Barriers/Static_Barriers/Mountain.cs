﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Mountain:Barrier,IBarrier
    {   
        private static int mountainId = 1;

        public Mountain(Image image):base(mountainId,image)
        {
            mountainId++;
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
            this.SetHeight(15);
            this.SetWidth(15);
        }
    }
    //add summer and winter classeS
    internal class summerMountain:Mountain
    {
        public summerMountain():base(Resources.Golden_Chest)
        {
           
        }

    }
    internal class winterMountain:Mountain
    {
        public winterMountain():base(Resources.Winter_Mountain)
        {
            
        }
    }
    
}
