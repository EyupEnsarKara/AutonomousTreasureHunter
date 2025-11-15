using AutonomousTreasureHunter.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousTreasureHunter.Forms
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {

                if (textBox1.Text.All(char.IsDigit))
            {
                if (textBox1.Text != "")
                {
                    Program.map = new Map(Convert.ToInt32(textBox1.Text));
                    Program.map.generateRandomMap();
                    MapForm mapForm = new MapForm(Convert.ToInt32(textBox1.Text));

                    mapForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lütfen bir değer giriniz");
                }
            }
            else
            {
                MessageBox.Show("Lütfen sadece sayı giriniz");
            }
       

        }
    }
}
