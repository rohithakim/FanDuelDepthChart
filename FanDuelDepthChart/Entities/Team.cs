using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanDuelDepthChart.Entities
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public Team(int id,string name )
        {
            ID = id; ;
            Name = name;
        }

    }
}
