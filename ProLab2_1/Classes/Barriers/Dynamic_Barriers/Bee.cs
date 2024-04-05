using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousTreasureHunter.Classes.Barriers.Dynamic_Barriers
{
    internal class Bee:DynamicBarrier,IBarrier
    {   
        enum Directions
        {
            Right=0, Left=1
        }
        private bool isTurn = false;
        public Bee(): base("Bee",Resources.Bee,"Horizontial", 3)
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
            this.SetWidth(2);
            this.SetHeight(2);


        }
        public void Move()
        {
            Location location = this.getLocation();
            int x = location.getX(), y = location.getY();

            int currentmove = getCurrentMovedSize();
            if (!isTurn)
            {
                if (currentmove < this.getMaxMove()*2-1)
                {
                    this.increaseCurrentMovedSize();
                    x++;
                }
                else isTurn = true;
            }
            else
            {
                if (currentmove > 0)
                {
                    this.decreaseCurrentMovedSize();
                    x--;
                }
                else isTurn = false;
                           
            }



            this.setLocation(new Location(x, y));

        }


    }
        




}
