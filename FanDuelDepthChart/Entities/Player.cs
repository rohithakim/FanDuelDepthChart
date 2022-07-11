using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace FanDuelDepthChart.Entities
{
    public class Player  
    {
        public string Name { get; set; }
        public int Number { get; set; } 
        public int TeamID { get; set; }

        public Player()
        {

        }
        public Player(string name, int number,int teamID)
        {
            Name = name;
            Number = number;
            TeamID = teamID;
        }

    }
}
