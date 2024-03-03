using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab2_1.Forms
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }

        private void PictureBoxUpdateGraphic(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int w = 100; int h = 100;

            
            for (int i = pictureBox1.Width; i >=0; i-=w)
            {
                g.DrawLine(new Pen(Brushes.Black), i, 0, i, pictureBox1.Height);
                Console.WriteLine("ilk");
            }

            for (int i = pictureBox1.Height; i >= 0; i -= h)
            {
                g.DrawLine(new Pen(Brushes.Black),0,i,pictureBox1.Width,i);
                Console.WriteLine("iki");
            }
            g.DrawLine(new Pen(Brushes.Black),0,pictureBox1.Height-1,pictureBox1.Width,pictureBox1.Height-1);


            //g.DrawLine(new Pen(Brushes.Black), 0, 5, pictureBox1.Width, 5);


        }

        private void StartAction(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}
