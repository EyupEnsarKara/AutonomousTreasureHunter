using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers
{
    public class Barrier
    {
        private int width;
        private  int height;
        private int id;
        public Barrier(int width, int height, int id)
        {
            this.width = width;
            this.height = height;
            this.id = id;
        }
        public int GetWidth()
        {
            return this.width;
        }
        public int GetHeight()
        {
            return this.height;
        }
        public int GetId()
        {
            return this.id;
        }

    }
}
