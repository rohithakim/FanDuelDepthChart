using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using FanDuelDepthChart.Entities;
using FanDuelDepthChart.Enums;
using FanDuelDepthChart.Extensions;

namespace FanDuelDepthChart
{
    class Program
    {
        static void Main(string[] args)
        {
            var depthChart = new DepthChart();
            League nflLeage = new League(1, "NFL");

            depthChart.CurrentLeague.Add(nflLeage);
            Team tampaBay = new Team(1, "Tampa Bay Buccaneers");

            nflLeage.teams.Add(tampaBay);
            var TomBrady = new Player("Tom Brady", 12, tampaBay.ID);
            var BlaineGabbert = new Player("Blaine Gabbert", 11, tampaBay.ID);
            var KyleTrask = new Player("Kyle Trask", 2, tampaBay.ID);
            var MikeEvans = new Player("Mike Evans", 13, tampaBay.ID);
            var JaelonDarden = new Player("Jaelon Darden", 1, tampaBay.ID);
            var ScottMiller = new Player("Scott Miller", 10, tampaBay.ID);

            //Player removedPlayer = depthChart.removePlayerFromDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady);

            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady, 0); 
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), BlaineGabbert, 1);
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), KyleTrask, 2);
            depthChart.addPlayerToDepthChart(PlayerPositionName.LeftWideReceiver.GetStringValue(), MikeEvans, 0);
            depthChart.addPlayerToDepthChart(PlayerPositionName.LeftWideReceiver.GetStringValue(), JaelonDarden, 1);
            depthChart.addPlayerToDepthChart(PlayerPositionName.LeftWideReceiver.GetStringValue(), ScottMiller, 2);

            List<PlayerPosition> playerList = depthChart.getFullDepthChart();

            foreach (PlayerPositionName name in Enum.GetValues(typeof(PlayerPositionName)))
            {
                Console.Write(name.GetStringValue() + ":    ");
                List<PlayerPosition> playerListforEachPosition = (playerList.FindAll(x => x.PositionName == name.GetStringValue())).OrderBy(x=> x.PositionRanking).ToList();

                foreach(PlayerPosition Cplayer in playerListforEachPosition)
                {
                    Console.Write(Cplayer.player.Number + ": " + Cplayer.player.Name +"     ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();

            Player removedPlayer = depthChart.removePlayerFromDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady);

            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady, 1);

            List<Player> backups = depthChart.getBackups(PlayerPositionName.LeftWideReceiver.GetStringValue(), ScottMiller);

            foreach(Player p in backups)
            {
                Console.WriteLine(p.Number + ": " + p.Name);
            }

            Console.ReadKey();
        }
    }
}
