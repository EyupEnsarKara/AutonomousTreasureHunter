using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Mountain:Barrier,IBarrier
    {   

        public Mountain(Image image,string theme):base(image,"Mountain",theme)
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
            this.SetHeight(15);
            this.SetWidth(15);
        }
    }
    //add summer and winter classeS
    internal class summerMountain:Mountain
    {
        public summerMountain():base(Resources.Summer_Mountain,"summer")
        {
           
        }

    }
    internal class winterMountain:Mountain
    {
        public winterMountain():base(Resources.Winter_Mountain,"winter")
        {
            
        }
    }
    
}
