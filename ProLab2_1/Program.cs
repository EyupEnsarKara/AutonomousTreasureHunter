using ProLab2_1.Classes;
using ProLab2_1.Classes.Barriers.Dynamic_Barriers;
using ProLab2_1.Classes.Barriers.Static_Barriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {     

            Map map = new Map();
            map.AddBarrier(new Bee());
            map.AddBarrier(new Mountain());
            map.AddBarrier(new Bee());
            map.AddBarrier(new Bird());
            map.AddBarrier(new Mountain());
            map.AddBarrier(new Bird());
            map.AddBarrier(new Bee());
            map.AddBarrier(new Mountain());
            map.AddBarrier(new Stone());

            
            



            Console.ReadLine();
        }
    }
}
