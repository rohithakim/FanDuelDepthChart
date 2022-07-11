using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace FanDuelDepthChart.Entities
{
    public class DepthChart
    {
        private List<PlayerPosition> Player_Position = new List<PlayerPosition>();
        public List<League> CurrentLeague = new List<League>();
        public List<Team> Teams = new List<Team>();

        public void addPlayerToDepthChart(string position,Player player, int? playerDepth = null)
        {
            
            PlayerPosition cPos = new PlayerPosition();
            cPos.PositionName = position;
            cPos.player = player;
            if (playerDepth != null)
            {
                cPos.PositionRanking = Convert.ToInt16(playerDepth);
            }
            else
            {
                int CurrMaxRanking = (Player_Position.FindAll(x => x.PositionName == position)).Max(x => x.PositionRanking);
                cPos.PositionRanking = CurrMaxRanking +1 ;
            }
            
            if(Player_Position.Any(x=> x.PositionName == position && x.player.Number == player.Number))
            {
                return;
            }

            foreach (PlayerPosition pPos in Player_Position.FindAll(x=> x.PositionName == position && x.PositionRanking >= Convert.ToInt16(playerDepth)))
            {
                pPos.PositionRanking += 1; 
            }

            Player_Position.Add(cPos);
            
        }

        public Player removePlayerFromDepthChart(string position, Player Player)
        {
            Player playerTobeRemoved = new Player();

            if (Player_Position.Count >0)
            {
                var playerToBeRemoved = Player_Position.Single(x => x.PositionName == position && x.player == Player);

                Player_Position.Remove(playerToBeRemoved);

                foreach (PlayerPosition pPos in Player_Position.FindAll(x => x.PositionName == position && x.PositionRanking > playerToBeRemoved.PositionRanking))
                {
                    pPos.PositionRanking -= 1;
                }

                return playerToBeRemoved.player;
            }

            return playerTobeRemoved;
        }

        public List<Player> getBackups(string position, Player player)
        {
            List<Player> playerBackups = new List<Player>();

            PlayerPosition currPlayerPosition = Player_Position.Find(x => x.PositionName == position && x.player.Number == player.Number);

            foreach(PlayerPosition posPlayer in Player_Position.FindAll(x => x.PositionName == position && x.PositionRanking > currPlayerPosition.PositionRanking ).OrderBy(x=> x.PositionRanking).ToList())
            {
                playerBackups.Add(posPlayer.player);
            }

            return playerBackups;
        }

        public List<PlayerPosition> getFullDepthChart()
        {
            return Player_Position;
        }
    }
}
