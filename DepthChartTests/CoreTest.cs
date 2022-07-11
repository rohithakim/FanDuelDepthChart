using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FanDuelDepthChart.Entities;
using FanDuelDepthChart.Enums;
using FanDuelDepthChart.Extensions;

namespace DepthChartTests
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void ShouldNotAddSamePlayerTwiceinSamePosition()
        {
            var depthChart = new DepthChart();
            League nflLeage = new League(1, "NFL");
            depthChart.CurrentLeague.Add(nflLeage);

            Team tampaBay = new Team(1, "Tampa Bay Buccaneers");
            nflLeage.teams.Add(tampaBay);

            var TomBrady = new Player("Tom Brady", 12, tampaBay.ID);

            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady, 0);
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady, 1);

            List<PlayerPosition> playerList = depthChart.getFullDepthChart();

            Assert.AreEqual(1, playerList.Count);
        }

        [TestMethod]
        public void ShouldUpdatePlayerRankingOnRemoval()
        {
            var depthChart = new DepthChart();
            League nflLeage = new League(1, "NFL");
            depthChart.CurrentLeague.Add(nflLeage);

            Team tampaBay = new Team(1, "Tampa Bay Buccaneers");
            nflLeage.teams.Add(tampaBay);

            var TomBrady = new Player("Tom Brady", 12, tampaBay.ID);
            var BlaineGabbert = new Player("Blaine Gabbert", 11, tampaBay.ID);
            var KyleTrask = new Player("Kyle Trask", 2, tampaBay.ID);

            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady, 0);
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), BlaineGabbert, 1);
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), KyleTrask, 2);

            Player removedPlayer = depthChart.removePlayerFromDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), BlaineGabbert);

            List<PlayerPosition> playerList = depthChart.getFullDepthChart();

            PlayerPosition playePosForKyle = playerList.Find(x => x.player.Number == KyleTrask.Number && x.PositionName == PlayerPositionName.QuaterBack.GetStringValue());

            Assert.AreEqual(2, playerList.Count); // Verifying player Count after removall

            Assert.AreEqual(1, playePosForKyle.PositionRanking); //Verifying player position
        }

        [TestMethod]
        public void ShouldUpdatePlayerRankingOnAddingNewPlayer()
        {
            var depthChart = new DepthChart();
            League nflLeage = new League(1, "NFL");
            depthChart.CurrentLeague.Add(nflLeage);

            Team tampaBay = new Team(1, "Tampa Bay Buccaneers");
            nflLeage.teams.Add(tampaBay);

            var TomBrady = new Player("Tom Brady", 12, tampaBay.ID);
            var BlaineGabbert = new Player("Blaine Gabbert", 11, tampaBay.ID);
            var KyleTrask = new Player("Kyle Trask", 2, tampaBay.ID);

            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady, 0);
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), BlaineGabbert, 1);

            //Ading new player at 0 ranking. Should push all playe down.
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), KyleTrask, 0);

            List<PlayerPosition> playerList = depthChart.getFullDepthChart();

            PlayerPosition playePosForBlaine = playerList.Find(x => x.player.Number == BlaineGabbert.Number && x.PositionName == PlayerPositionName.QuaterBack.GetStringValue());

            Assert.AreEqual(3, playerList.Count); // Verifying player Count after addition of new player
            Assert.AreEqual(2, playePosForBlaine.PositionRanking); // Verifying player position
        }

        [TestMethod]
        public void ShouldReturnCorreectPlayerBackups()
        {
            var depthChart = new DepthChart();
            League nflLeage = new League(1, "NFL");
            depthChart.CurrentLeague.Add(nflLeage);

            Team tampaBay = new Team(1, "Tampa Bay Buccaneers");
            nflLeage.teams.Add(tampaBay);

            var TomBrady = new Player("Tom Brady", 12, tampaBay.ID);
            var BlaineGabbert = new Player("Blaine Gabbert", 11, tampaBay.ID);
            var KyleTrask = new Player("Kyle Trask", 2, tampaBay.ID);

            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady, 0);
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), BlaineGabbert, 1);
            depthChart.addPlayerToDepthChart(PlayerPositionName.QuaterBack.GetStringValue(), KyleTrask, 2);


            List<Player> backups = depthChart.getBackups(PlayerPositionName.QuaterBack.GetStringValue(), TomBrady);

            Assert.AreEqual(2, backups.Count);

        }
    }
}
