using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Dynamic_Barriers
{
    internal class Bird : DynamicBarrier, IBarrier
    {


        private bool isTurn = false;

        private static int birdId = 1;
        
        public Bird(Image image) : base(birdId,image,"Vertical",5)
        {
            birdId++;
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

         public void Move()
        {
            Location location = this.getLocation();
            int x=location.getX(),y=location.getY();

            int currentmove = getCurrentMovedSize();
            if(!isTurn)
            {
                if(currentmove < this.getMaxMove())
                {
                    this.increaseCurrentMovedSize();
                    x++;
                }
                else isTurn = true;
            }
            else
            {
                if(currentmove > (this.getMaxMove()*-1))
                {
                    this.decreaseCurrentMovedSize();
                    x--;
                }
                else isTurn=false;
            }



            this.setLocation(new Location(x,y));
            
        }
    }
    internal class summerBird : Bird
    {
        public summerBird() : base(Resources.Bird)
        {

        }

    }
    internal class winterBird : Bird
    {
        public winterBird() : base(Resources.Bird)
        {

        }
    }
}
