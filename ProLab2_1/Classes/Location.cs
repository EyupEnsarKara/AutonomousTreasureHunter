using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes
{
    public class Location
    {
        private int X, Y;


        public Location(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }






        //Getter ve setter metodları
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }

        public void setX(int x)
        {
            this.X = x;
        }
        public void setY(int y)
        {
            this.Y = y;
        }
        public Node ConvertNode()
        {
            return new Node(this.X,this.Y);
        }



    }
}
