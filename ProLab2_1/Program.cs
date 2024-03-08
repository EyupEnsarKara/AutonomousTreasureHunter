using ProLab2_1.Classes;
using ProLab2_1.Classes.Barriers.Dynamic_Barriers;
using ProLab2_1.Classes.Barriers.Static_Barriers;
using ProLab2_1.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab2_1
{
    internal class Program
    {
        static public Map map;
        static void Main(string[] args)
        {     
            Console.Write("Enter map size: ");
            int mapSize = Convert.ToInt32(Console.ReadLine());

            map = new Map(mapSize);
            addBarriers(map);

            


            map.generateRandomMap();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MapForm(mapSize));

            
          



            Console.ReadLine();
        }

        public static void addBarriers(Map map)
        {
            for (int i = 0;i<2;i++)
            {
                map.AddBarrier(new summerBee());
                map.AddBarrier(new summerBird());
                map.AddBarrier(new summerMountain());
                map.AddBarrier(new summerStone());
                map.AddBarrier(new summerTree());
                map.AddBarrier(new summerWall());
                map.AddBarrier(new winterBee());
                map.AddBarrier(new winterBird());
                map.AddBarrier(new winterMountain());
                map.AddBarrier(new winterStone());
                map.AddBarrier(new winterTree());
                map.AddBarrier(new winterWall());
     
            }

            
        }
        

    }
}
