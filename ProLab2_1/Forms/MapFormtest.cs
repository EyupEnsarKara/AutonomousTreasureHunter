using ProLab2_1.Classes;
using ProLab2_1.Classes.Barriers;
using ProLab2_1.Classes.Barriers.Dynamic_Barriers;
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
    public partial class MapFormtest : Form
    {
        private int MapSize;
        private Quad[,] quads = Program.map.GetQuads();
        private float quadSize = 0;
        private Character character = Program.map.GetCharacter();
        public MapFormtest(int MapSize)
        {
            this.MapSize = MapSize;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Map";
            AddPictureBox(GameMap);
            this.Size = new Size(751+16, 751+42);
            quadSize = (float)GameMap.Width / MapSize;
 
            character.updateFogRemoveArea(quads);
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

            Pen pen = new Pen(Color.Black, 0.001f);

            //kareli düzlem çizimi
            for (float i = 0; i <= GameMap.Width + 1; i += quadSize)
            {
                g.DrawLine(pen, i, 0, i, GameMap.Height);
            }
            for (float i = 0; i <= GameMap.Height + 1; i += quadSize)
            {
                g.DrawLine(pen, 0, i, GameMap.Width, i);
            }

            //bariyer çizimleri
            for(int i = 0; i<quads.GetLength(0);i++)
            {
                for(int j = 0;j < quads.GetLength(1);j++)
                {
                    if (quads[i,j].getIsVisited())
                    g.FillRectangle(Brushes.Red, i * quadSize, j * quadSize,quadSize, quadSize);
                }
            }
            
            




        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            Location previousLocation = character.GetCurrentLocation();
            int x = character.GetCurrentLocation().getX();
            int y = character.GetCurrentLocation().getY();
            switch (e.KeyCode)
            {
                
                case Keys.Right:
                    if ( x >= MapSize-1|| quads[x + 1, y].GetIsBarrier())
                        break;
                    character.AddVisitedLocation();
                    character.GetCurrentLocation().setX(x+1);
                    break;
                case Keys.Left:
                    if (x <= 0 || quads[x - 1, y].GetIsBarrier())
                        break;
                    character.AddVisitedLocation();

                    character.GetCurrentLocation().setX(x-1);
                    break;
                case Keys.Up:
                    if (y <= 0 ||quads[x, y-1].GetIsBarrier())
                        break;
                    character.AddVisitedLocation();

                    character.GetCurrentLocation().setY(y-1);
                    break;
                case Keys.Down:
                    if (y >= MapSize-1 || quads[x, y + 1].GetIsBarrier())
                        break;
                    character.AddVisitedLocation();

                    character.GetCurrentLocation().setY(y+ 1);
                    break;
                case Keys.Enter:
                    Program.map.clearFoggedAllArea();
                    break;
                
            }
            
            character.updateFogRemoveArea(quads);
            
        }

        private void GameTimerTick(object sender, EventArgs e)
        {
            GameMap.Invalidate();
        }

        private void MoveObjectEvent(object sender, EventArgs e)
        {
            List<IBarrier> list = Program.map.GetBarriers();

            foreach(IBarrier barrier in list)
            {
                if(barrier is DynamicBarrier)
                {
                    if(barrier is Bird)
                    {
                        Bird bird = (Bird)barrier;
                        bird.Move();
                    }
                    if(barrier is Bee)
                    {
                        Bee bee = (Bee)barrier;
                        bee.Move();
                    }
                }
            }


            foreach(Chest chest in Program.map.GetChests())
            {
                if (character.GetCurrentLocation().getX() >= chest.getLocation().getX() && character.GetCurrentLocation().getX() <= chest.getLocation().getX() + chest.getWidth() - 1 && character.GetCurrentLocation().getY() >= chest.getLocation().getY() && character.GetCurrentLocation().getY() <= chest.getLocation().getY() + chest.getHeight() - 1)
                {
                    character.CollectChest(chest);
                    Program.map.removeChest(chest);
                    //sadece tür ismini bastırsın
                    Console.WriteLine(chest.GetType().Name+" Toplandı (x:"+chest.getLocation().getX()+" y:"+chest.getLocation().getY()+") Id:"+chest.getId());

                    break;
                }
            }
            character.automaticallyMove(quads);
            character.automaticallyMove(quads);
            character.automaticallyMove(quads);



        }



        private void drawLineBetweenQuads(Graphics g,Location p1,Location p2,Brush brush)
        {
            Pen pen = new Pen(brush);


            g.DrawLine(pen, p1.getX() + quadSize / 2, p1.getY() + quadSize / 2, p2.getX() + quadSize / 2, p2.getX() + quadSize / 2);
            
        }
    }
}
