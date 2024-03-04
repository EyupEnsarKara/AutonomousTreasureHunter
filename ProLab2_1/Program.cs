using ProLab2_1.Classes;
using ProLab2_1.Classes.Barriers.Dynamic_Barriers;
using ProLab2_1.Classes.Barriers.Static_Barriers;
using ProLab2_1.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab2_1
{
    internal class Program
    {
        static Map map;
        static void Main(string[] args)
        {     
            Console.Write("Enter map size: ");
            int mapSize = Convert.ToInt32(Console.ReadLine());

            map = new Map(mapSize);
            map.AddBarrier(new Bee());
            map.AddBarrier(new Bird());
            map.AddBarrier(new Tree());
            map.AddBarrier(new Tree());
            map.AddBarrier(new Tree());
            map.AddBarrier(new Bird());
            map.generateRandomMap();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MapForm());






            Console.ReadLine();
        }


    }
}
