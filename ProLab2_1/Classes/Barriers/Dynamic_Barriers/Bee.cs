using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Dynamic_Barriers
{
    internal class Bee:Barrier,IBarrier
    {   
        private static int beeId = 1;
        private string direction = "right-left";
        public Bee(Image image): base(beeId,image)
        {
            beeId++;
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
            this.SetWidth(2);
            this.SetHeight(2);


        }


    }
        
    internal class summerBee:Bee
    {
        public summerBee():base(Resources.Summer_Bee)
        {
            
        }

    }
    internal class winterBee:Bee
    {
        public winterBee():base(Resources.Winter_Bee)
        {
            
        }
    }



}
