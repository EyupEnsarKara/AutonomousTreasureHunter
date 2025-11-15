using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousTreasureHunter.Classes.Barriers
{
    public interface IBarrier
    {

        int GetId();
        void SetBarrierSize();

        int getBarrierWidth();
        int getBarrierHeight();
        Location getLocation();
        void setLocation(Location location);
        Image getImage();
        string getName();
        string getTheme();
        IBarrier changeObjectTheme();
    }
}
