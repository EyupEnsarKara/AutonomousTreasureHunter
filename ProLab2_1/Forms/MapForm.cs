using ProLab2_1.Classes;
using ProLab2_1.Classes.Barriers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private Quad[,] quads = Program.map.GetQuads();
        private float quadSize = 0;
        private Character character = Program.map.GetCharacter();
        public MapForm(int MapSize)
        {
            this.MapSize = MapSize;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Map";
            AddPictureBox(GameMap);
            this.Size = new Size(751+16, 751+40);
            quadSize = (float)GameMap.Width / MapSize;
        }
        PictureBox AddPictureBox(PictureBox pictureBox)
        {
            pictureBox.Location = new Point(0, 0);
            pictureBox.Size = new Size(751,751);
            return pictureBox;
        }

        private void GameMap_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;


            //mevsimlere göre renklendirme

            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (quads[i, j].GetIsSummer())
                    {
                        g.FillRectangle(Brushes.LightYellow, i * quadSize, j * quadSize, quadSize, quadSize);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.LightBlue, i * quadSize, j * quadSize, quadSize, quadSize);
                    }
                }
            }





            Pen pen = new Pen(Color.Black,0.001f);

            //kareli düzlem çizimi
            for (float i = 0; i <= GameMap.Width+1; i += quadSize)
            {
                g.DrawLine(pen, i, 0, i, GameMap.Height);
            }
            for (float i = 0; i <= GameMap.Height+1; i += quadSize)
            {
                g.DrawLine(pen, 0, i, GameMap.Width, i);
            }

            

            




            //bariyer çizimleri
            List<IBarrier> list = Program.map.GetBarriers();
            foreach (IBarrier barrier in list)
            {

                Location location = barrier.getLocation();
                int x = location.getX(), y = location.getY();
               

                g.DrawImage(barrier.getImage(), x*quadSize, y *quadSize, quadSize*barrier.getBarrierWidth(), quadSize*barrier.getBarrierHeight());
                
            
            }
            //karakter çizimi
            g.DrawImage(global::ProLab2_1.Resources.steve, character.GetCurrentLocation().getX() * quadSize, character.GetCurrentLocation().getY() * quadSize,quadSize,quadSize);




        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            
            int x = character.GetCurrentLocation().getX();
            int y = character.GetCurrentLocation().getY();
            Console.WriteLine(x);
            switch (e.KeyCode)
            {
                
                case Keys.Right:
                    if ( x >= MapSize-1|| quads[x + 1, y].GetIsBarrier())
                        break;
                    character.GetCurrentLocation().setX(x+1);
                    break;
                case Keys.Left:
                    if (x <= 0 || quads[x - 1, y].GetIsBarrier())
                        break;
                    character.GetCurrentLocation().setX(x-1);
                    break;
                case Keys.Up:
                    if (y <= 0 ||quads[x, y-1].GetIsBarrier())
                        break;
                    character.GetCurrentLocation().setY(y-1);
                    break;
                case Keys.Down:
                    if (y >= MapSize-1 || quads[x, y + 1].GetIsBarrier())
                        break;
                    character.GetCurrentLocation().setY(y+ 1);
                    break;

                    
            }
            GameMap.Invalidate();
        }
    }
}
