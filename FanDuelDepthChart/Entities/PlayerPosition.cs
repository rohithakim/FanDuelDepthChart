using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanDuelDepthChart.Entities
{
    public class PlayerPosition
    {
        public int ID { get; set; }
        public int leagueID { get; set; }
        public string PositionName { get; set; }
        public Player player { get; set; }
        public int PositionRanking { get; set; }
    }
}
