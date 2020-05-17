using System;
using System.Collections.Generic;
using System.Linq;
using TeamSource.Enteties;
using TeamSource.Helpers;

namespace GameCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = TeamsDataBase.GetAllTeams();

            // Find all TEAMS with names starting with LA
            var teamsStartingWithLA = teams.Where(team => team.Name.StartsWith("LA")).ToList();
            // teamsStartingWithLA.ForEach(team => Console.WriteLine(team.Name));


            // Find all team NAMES which are playing in "Staples Center"
            var teamsPlayingInStaplesCenter = teams.Where(team => team.Arena.Equals("Staples Center"))
                                                      .Select(team => team.Name).ToList();
            // teamsPlayingInStaplesCenter.ForEach(team => Console.WriteLine(team));



            // Find all teams coaches
            var allCoaches = teams.Select(team => team.Coach).ToList();
            // allCoaches.ForEach(coach => Console.WriteLine(coach.FullName));



            // Find 3 oldest coaches NAMES
            var oldest3CoahcesNames = allCoaches.OrderByDescending(coach => coach.Age)
                                                          .Take(3)
                                                            .Select(coach => coach.FullName)
                                                              .ToList();
            // oldest3CoahcesNames.ForEach(trainerName => Console.WriteLine(trainerName));



            // Group all teams by their arenas
            var groupedTeamsByArenas = teams.GroupBy(team => team.Arena).ToList();
            //foreach (var group in groupedTeamsByArenas)
            //{
            //    Console.WriteLine($"{group.Key}");
            //    foreach (var team in group)
            //    {
            //        Console.WriteLine($"-------------{team.Name}");
            //    }
            //}


            // Find all players in one LIST
             var allPlayers = new List<Player>();
            teams.ForEach(team => allPlayers.AddRange(team.Players));
            //allPlayers.ForEach(player => Console.WriteLine(player.FullName));

            //Find player with best avgPtsPerGame
            var playerWithMostPtsPerGame = allPlayers.OrderByDescending(player => player.PlayerStatistic["PtsPerGame"])
                                                          .FirstOrDefault();
            //Console.WriteLine(playerWithMostPtsPerGame.FullName);


            //_________________________________________HOMEWORK________________________________________

            // ***** Find all coaches NAMES with Age > 50

            var allCoachesName50 = allCoaches
                                  .Where(coach => coach.Age > 50)
                                  .Select(coach => coach.FullName)
                                  .ToList();
            // allCoachesName50.ForEach(coach => Console.WriteLine(coach));


            // ***** Order players by AGE - DESC
            
            var orderPlayersByAge = allPlayers
                                   .OrderByDescending(player => player.Age)
                                   .Select(player => new { player.FullName, player.Age })
                                   .ToList();
            // orderPlayersByAge.ForEach(player => Console.WriteLine(player));


            // ***** Find player with highest RebPerGame *****

            var playerHighestRebPerGame = allPlayers
                                         .OrderByDescending(player => player.PlayerStatistic["RebPerGame"])
                                         .Take(1)
                                         .ToList();
            // playerHighestRebPerGame.ForEach(player => Console.WriteLine(player.FullName));


            // ***** Find all players with PtsPerGame > 20 *****
            var allplayerHighestRebPerGame = allPlayers
                                            .OrderByDescending(player => player.PlayerStatistic["RebPerGame"] > 20)                                          
                                            .ToList();
            // allplayerHighestRebPerGame.ForEach(player => Console.WriteLine(player.FullName));


            // ***** Find all players NAMES older then 30 years *****
            var playersNameOlder30 = allPlayers
                                    .Where(player => player.Age > 30)
                                    .ToList();
            // playersNameOlder30.ForEach(player => Console.WriteLine(player.FullName));


            // ***** Group players by age *****
          
            var groupedPlayersByAge = allPlayers
                                     .OrderBy(player => player.Age)
                                     .GroupBy(player => player.Age)
                                     .ToList();
                    foreach (var group in groupedPlayersByAge)
                    {             
                        foreach (var player in group)
                        {
                           // Console.WriteLine($"Name = {player.FullName}. Age = {group.Key}");
                        }
                    }


            // ***** Find All players NAMES and PtsPerGame if have RebPerGame > 7.0 *****

            var namesPtsPerGameRebPerGame7 = allPlayers
                                            .Where(player => player.PlayerStatistic["RebPerGame"] > 7)
                                            .OrderBy(player => player.PlayerStatistic["PtsPerGame"])                                          
                                            .ToList();
            // namesPtsPerGameRebPerGame7.ForEach(player => Console.WriteLine($"{player.FullName}____{player.PlayerStatistic["PtsPerGame"]}"));


            // ***** Find first 3 players with highest PtsPerGame *****

            var first3PlayersPtsPerGame = allPlayers
                                         .OrderBy(player => player.PlayerStatistic["PtsPerGame"])
                                         .Take(3)
                                         .ToList();
            // first3PlayersPtsPerGame.ForEach(player => Console.WriteLine(player.FullName));


            // ***** Find the team  which has the player with highest PtsPerGame ***** (Ne mi e jasna) 

            //var teamWhichPlayerHigPTsPerGame = teams.......

            // ***** Find first 4 players with highest RebPerGame and order them by PtsPerGame - ASC *****

            var first4HighestRebPtsPerGame = allPlayers
                                            .OrderByDescending(player => player.PlayerStatistic["RebPerGame"])
                                            .Take(4)
                                            .OrderBy(player => player.PlayerStatistic["PtsPerGame"])
                                            .ToList();
            // first4HighestRebPtsPerGame.ForEach(player => Console.WriteLine(player.FullName));

        }
    }
}
