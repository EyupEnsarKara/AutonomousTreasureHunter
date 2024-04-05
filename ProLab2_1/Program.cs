using AutonomousTreasureHunter.Classes;
using AutonomousTreasureHunter.Classes.Barriers.Dynamic_Barriers;
using AutonomousTreasureHunter.Classes.Barriers.Static_Barriers;
using AutonomousTreasureHunter.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousTreasureHunter
{
    internal class Program
    {
        static public Map map;
        static void Main(string[] args)
        {     


            


            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            
          



            Console.ReadLine();
        }

        
        

    }
}
