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
        private Object item;

        public quad(Location location, Object item)
        {
            this.location =(Location) location;
            this.item = item;

        }


        public Location GetLocation()
        {
            return this.location;
        }
        public Object GetItem()
        {
            return this.item;
        }
        public void SetLocation(Location location)
        {
            this.location = location;
        }
        public void SetItem(Object item)
        {
            this.item= item;
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
