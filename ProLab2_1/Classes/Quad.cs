﻿using AutonomousTreasureHunter.Classes.Barriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousTreasureHunter.Classes
{
    public class Quad
    {
        private Location location;
        private bool isBarrier= false;
        private bool isSummer = false;
        private bool isVisible = false;
        private bool isCollectible = false;
        private bool isVisited = false;

        private IBarrier barrier;

        public Quad(Location location)
        {
            this.location = location;
            
        }
        public void SetBarrier(IBarrier barrier)
        {
            this.isBarrier = true;
            this.barrier = barrier;   
        }   



        public Location GetLocation()
        {
            return this.location;
        }

        public void SetLocation(Location location)
        {
            this.location = location;
        }

        public bool GetIsBarrier()
        {
            return this.isBarrier;
        }
        public bool GetIsSummer()
        {
            return this.isSummer;
        }
        public void SetSummer()
        {
            this.isSummer = true;
        }

        public void removeFog()
        {
            this.isVisible = true;
        }
        public bool getVisible()
        {
            return this.isVisible;
        }
        public void setCollectible()
        {
            this.isCollectible = true;
        }
        public bool getCollectible()
        {
            return this.isCollectible;
        }
        public void resetCollectible()
        {
            this.isCollectible = false;
        }
        public void setIsVisited()
        { this.isVisited = true; }
        public bool getIsVisited()
        {
            return this.isVisited;
        }
        public bool getIsFoggy()
        {
            return !this.isVisible;
        }
        public int getBarrierID()
        {
            return barrier.GetId();
        }
        public string getBarrierName()
        {
            return barrier.getName();
        }
        public void setFog()
        {
            this.isVisible = false;
        }


    }
}
