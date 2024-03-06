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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab2_1.Forms
{
    public partial class MapForm : Form
    {
        private int MapSize;
        private Location head = new Location(0,0);
        private Quad[,] quads = Program.map.GetQuads();

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
            //    Console.WriteLine("X:" + x + " Y:" + y);
            //    g.FillRectangle(Brushes.Red, x * quadSize, y * quadSize, quadSize, quadSize);

            //}


            List<IBarrier> list = Program.map.GetBarriers();
            foreach (IBarrier barrier in list)
            {

                Location location = barrier.getLocation();
                int x = location.getX(), y = location.getY();

                g.DrawImage(global::ProLab2_1.Resources.tree, x*quadSize, y *quadSize, quadSize*barrier.getBarrierWidth(), quadSize*barrier.getBarrierHeight());
            }
            g.DrawImage(global::ProLab2_1.Resources.steve, head.getX() * quadSize, head.getY() * quadSize,quadSize,quadSize);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            int x = head.getX();
            int y = head.getY();
            switch (e.KeyCode)
            {
                
                case Keys.Right:
                    if (quads[x + 1, y].GetIsBarrier())
                        break;
                    head.setX(x+1);
                    break;
                case Keys.Left:
                    if (quads[x - 1, y].GetIsBarrier())
                        break;
                    head.setX(x-1);
                    break;
                case Keys.Up:
                    if (quads[x, y-1].GetIsBarrier())
                        break;
                    head.setY(y-1);
                    break;
                case Keys.Down:
                    if (quads[x, y+1].GetIsBarrier())
                        break;
                    head.setY(y+ 1);
                    break;
            }
            GameMap.Invalidate();
        }
    }
}
