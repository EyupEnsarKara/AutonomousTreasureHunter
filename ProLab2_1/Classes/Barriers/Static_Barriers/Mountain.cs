using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Mountain:IBarrier
    {   
        private static int mountainId = 0;

        private int id;
        public Mountain()
        {
            SetBarrierId();
        }
        public int GetId()
        {
            return id;
        }

        public void SetBarrierId()
        {
            this.id = mountainId;
            mountainId++;
        }


    }
}
