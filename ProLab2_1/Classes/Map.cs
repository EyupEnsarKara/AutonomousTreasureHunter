using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab2_1.Classes
{ 
    //add quad class


    public class quad
    {
        private Location location;

        public quad(Location location)
        {
            this.location = location;

        }


        public Location GetLocation()
        {
            return this.location;
        }
  
        public void SetLocation(Location location)
        {
            this.location = location;
        }

    }


    public class Map
    {
        quad[,] mapSpace = new quad[300,300];
        
           
        public Map()
        {
            
            
        }
        

    }
}
