﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousTreasureHunter.Classes.Barriers
{
    public class Barrier
    {
        private static int barriersCount = 0;
        private int width;
        private  int height;
        private int id;
        private Location location;
        private Image image;
        private string Name;
        private string theme;
        public Barrier(Image image,string name, string theme)
        {
            this.image = image;
            this.id = barriersCount;
            barriersCount++;
            this.Name = name;
            this.theme = theme;
        }
        public void SetWidth(int width)
        {
            this.width = width;
        }
        
        public void SetHeight(int height)
        {
            this.height = height;
        }
        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetWidth()
        {
            return this.width;
        }
        public int GetHeight()
        {
            return this.height;
        }
        public int GetId()
        {
            return this.id;
        }
        public Location getLocation()
        {
            return this.location;
        }
        public void setLocation(Location location)
        {
            this.location = location;
        }
        public Image getImage()
        {
         return this.image;

        }   
        public string getName() {
            return Name;
        }
        public string getTheme()
        {
            return theme;
        }
        public virtual IBarrier changeObjectTheme()
        {
            throw new NotImplementedException();
        }

    }
}
