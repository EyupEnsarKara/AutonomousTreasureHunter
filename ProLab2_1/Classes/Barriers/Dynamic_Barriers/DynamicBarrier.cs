using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Dynamic_Barriers
{
   
    internal class DynamicBarrier : Barrier
    {
        private string direction;
        private int currentMovedSize = 0;
        private int maxMove;

        public DynamicBarrier(string name,Image image,string direction,int maxMove) : base(image,name,"none")
        {
            this.direction = direction;
            this.maxMove = maxMove;
        }

        public void increaseCurrentMovedSize()
        {
            this.currentMovedSize++;
        }
        public void decreaseCurrentMovedSize()
        {
            this.currentMovedSize--;
        }
        public int getCurrentMovedSize() { return this.currentMovedSize;}
        
        
        public int getMaxMove() { return this.maxMove;}


        
    }
}
