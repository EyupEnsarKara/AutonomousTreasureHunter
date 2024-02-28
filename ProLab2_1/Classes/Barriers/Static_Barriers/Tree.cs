﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1.Classes.Barriers.Static_Barriers
{
    internal class Tree:IBarrier
    {
        private static int treeId = 0;
         
        private int size;
        private int id;
        public Tree()
        {
           SetBarrierId();
        }
        public int GetBarrierId()
        {
            return this.id;
        }

        public void SetBarrierId()
        {
            this.id = treeId;
            treeId++;
        }

        public void SetBarrierSize()
        {
            Random random = new Random();
            this.size = random.Next(2, 6);
        }
    }
}
