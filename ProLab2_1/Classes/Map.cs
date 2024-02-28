using ProLab2_1.Classes.Barriers.Dynamic_Barriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProLab2_1.Classes.Barriers;

namespace ProLab2_1.Classes
{ 



    


    public class Map
    {
        Quad[,] mapSpace = new Quad[300, 300];

        private List<IBarrier> barriers = new List<IBarrier>();

        public void AddBarrier(IBarrier barrier)
        {
            barriers.Add(barrier);
        }

 
        
           
        public Map()
        {
            
            
        }



    }




}
