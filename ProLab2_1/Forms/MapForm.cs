using ProLab2_1.Classes;
using ProLab2_1.Classes.Barriers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab2_1.Forms
{
    public partial class MapForm : Form
    {
        private int MapSize;

        public MapForm(int MapSize)
        {
            this.MapSize = MapSize;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Map";
            AddPictureBox(GameMap);
            this.Size = new Size(751+16, 751+40);
        }
        PictureBox AddPictureBox(PictureBox pictureBox)
        {
            pictureBox.Location = new Point(0, 0);
            pictureBox.Size = new Size(751,751);
            return pictureBox;
        }

        private void GameMap_Paint(object sender, PaintEventArgs e)
        {
            float quadSize = (float)GameMap.Width / MapSize;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black,0.001f);
            for (float i = 0; i <= GameMap.Width+1; i += quadSize)
            {
                g.DrawLine(pen, i, 0, i, GameMap.Height);
            }
            for (float i = 0; i <= GameMap.Height+1; i += quadSize)
            {
                g.DrawLine(pen, 0, i, GameMap.Width, i);
            }



            //bu sadece kırmızı boyuyor
            //Quad[,] quads = Program.map.GetQuads();
            //foreach (Quad quad in quads)
            //{
            //    //Console.WriteLine(quad.GetIsBarrier());
            //    if (!quad.GetIsBarrier())
            //    {
            //        continue;
            //    }

            //    Location locate = quad.GetLocation();
            //    int x = locate.getX();
            //    int y = locate.getY();
            //    Console.WriteLine("X:"+x+" Y:"+y);
            //    g.FillRectangle(Brushes.Red, x*quadSize, y*quadSize, quadSize, quadSize);
                
            //}








            

        }










    }
}
