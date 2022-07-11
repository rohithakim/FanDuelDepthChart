using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanDuelDepthChart.Entities
{
    public class League
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Team> teams = new List<Team>();

        public League(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
