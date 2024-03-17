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
    public partial class MapForm : Form
    {
        private int MapSize;
        private Quad[,] quads = Program.map.GetQuads();
        private float quadSize = 0;
        private Character character = Program.map.GetCharacter();
        private int speedOfAutomaticPath = 1;
        public MapForm(int MapSize)
        {
            this.MapSize = MapSize;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Map";
            AddPictureBox(GameMap);
            quadSize = (float)GameMap.Width / MapSize;
            GameEvent.Start();
            MoveObjectTimer.Start();
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
            lbl_counMovements.Text = "Adım Sayısı :"+character.getCountOfMovements().ToString();
            lbl_chestCounts.Text = "Kalan sandık sayısı :"+Program.map.GetChests().Count.ToString();
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
            List<IBarrier> list = Program.map.GetBarriers();
            foreach (IBarrier barrier in list)
            {

                Location location = barrier.getLocation();
                int x = location.getX(), y = location.getY();

                g.FillRectangle(Brushes.Red, x * quadSize, y * quadSize, quadSize * barrier.getBarrierWidth(), quadSize * barrier.getBarrierHeight());

                g.DrawImage(barrier.getImage(), x*quadSize, y *quadSize, quadSize*barrier.getBarrierWidth(), quadSize*barrier.getBarrierHeight());
                

            
            }
            //sandık çizimleri
            
            foreach(Chest chest in Program.map.GetChests())
            {
                Location chestLocation = chest.getLocation();
                int x = chestLocation.getX(), y = chestLocation.getY();
                g.FillRectangle(Brushes.LightSeaGreen, x * quadSize, y * quadSize, quadSize * chest.getWidth(), quadSize * chest.getHeight());

                g.DrawImage(chest.getImage(), x * quadSize, y * quadSize, quadSize * chest.getWidth(), quadSize * chest.getHeight());
            }





            //karakter çizimi
            g.DrawImage(global::ProLab2_1.Resources.steve, character.GetCurrentLocation().getX() * quadSize, character.GetCurrentLocation().getY() * quadSize,quadSize,quadSize);
            g.FillRectangle(Brushes.Black, character.GetCurrentLocation().getX() * quadSize, character.GetCurrentLocation().getY() * quadSize, quadSize, quadSize);



            //Sis katmanı ekleme

            for(int i = 0; i < quads.GetLength(0); i++)
            {
                for (int j = 0; j < quads.GetLength(1); j++)
                {
                    if (!quads[i,j].getVisible())
                    {
                        g.FillRectangle(Brushes.White, i * quadSize, j * quadSize, quadSize, quadSize);
                    }
                }
            }
            //draw visited locations
            Location tempLocation=new Location(0,0);
            bool temp = false;
            Pen pen1 = new Pen(Color.Green, 2);

            foreach (Location location in character.GetVisitedLocations())
            {
                if(temp)
                g.DrawLine(pen1, tempLocation.getX() * quadSize+(quadSize/2), tempLocation.getY() * quadSize + (quadSize / 2), location.getX()*quadSize + (quadSize / 2), location.getY() * quadSize + (quadSize / 2));
                            
                tempLocation = location;
                temp = true;


            }
            if(temp)
              g.DrawLine(pen1, tempLocation.getX() * quadSize + (quadSize / 2), tempLocation.getY() * quadSize + (quadSize / 2), character.GetCurrentLocation().getX() * quadSize + (quadSize / 2), character.GetCurrentLocation().getY() * quadSize + (quadSize / 2));


            //mantıksal işlemler

            if(Program.map.GetChests().Count == 0)
            {
                GameEvent.Stop();
                MoveObjectTimer.Stop();
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
                case Keys.NumPad9:
                    speedOfAutomaticPath = 9;
                    break;
                case Keys.NumPad3:
                    speedOfAutomaticPath = 3;
                    break;
                case Keys.NumPad1:
                    speedOfAutomaticPath = 1;
                    break;
                case Keys.U:
                    speedOfAutomaticPath = 30;
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
            for(int i=0; i < speedOfAutomaticPath; i++)
            {
                character.automaticallyMove(quads);
            }
            



        }



        private void drawLineBetweenQuads(Graphics g,Location p1,Location p2,Brush brush)
        {
            Pen pen = new Pen(brush);


            g.DrawLine(pen, p1.getX() + quadSize / 2, p1.getY() + quadSize / 2, p2.getX() + quadSize / 2, p2.getX() + quadSize / 2);
            
        }

        public List<List<int>> initGraph(int mapSize, List<IBarrier> barriers, Quad[,] quads, int characterX, int characterY)
        {
            List<List<int>> graph = new List<List<int>>();

            // Karakterin etrafındaki bölgeyi oluşturun (örneğin, 5x5 bir alan)
            int regionSize = 50;
            int startX = Math.Max(0, characterX - regionSize / 2);
            int startY = Math.Max(0, characterY - regionSize / 2);
            int endX = Math.Min(mapSize - 1, characterX + regionSize / 2);
            int endY = Math.Min(mapSize - 1, characterY + regionSize / 2);

            // Sadece bu bölgedeki düğümleri ve kenarları oluşturun
            for (int i = startX; i <= endX; i++)
            {
                List<int> row = new List<int>();
                for (int j = startY; j <= endY; j++)
                {
                    if (quads[i, j].getIsFoggy())
                    {
                        row.Add(-2); // Sisli alan için -2 değeri kullanılabilir
                    }
                    else if (quads[i, j].GetIsBarrier())
                    {
                        row.Add(-1); // Engeller için -1 değeri kullanılabilir
                    }
                    else
                    {
                        row.Add(0); // Başlangıçta hiçbir kenar yok
                    }
                }
                graph.Add(row);
            }
            Console.WriteLine("oluşturuldu");
            // Diğer işlemler...

            return graph;
        }





    }
}
