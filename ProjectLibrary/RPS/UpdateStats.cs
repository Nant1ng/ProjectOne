using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Models;

namespace ProjectLibrary.RPS
{
    public class UpdateStats
    {
        public void UpdateGameStats(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                var stats = dbContext.GameStatistics.FirstOrDefault();

                int totalGamesPlayed = dbContext.RockPaperScissorGame.Count();
                int totalWins = dbContext.RockPaperScissorGame.Count(game => game.Result == Result.Win);
                int totalLoses = dbContext.RockPaperScissorGame.Count(game => game.Result == Result.Lose);
                int totalDraws = dbContext.RockPaperScissorGame.Count(game => game.Result == Result.Draw);
                double averageWins = totalGamesPlayed > 0 ? (double)totalWins / totalGamesPlayed : 0;

                if (stats == null)
                {
                    stats = new GameStatistics(totalGamesPlayed, totalWins, totalLoses, totalDraws, averageWins);
                    dbContext.GameStatistics.Add(stats);
                }
                else
                {
                    stats.TotalGamesPlayed = totalGamesPlayed;
                    stats.TotalWins = totalWins;
                    stats.TotalLoses = totalLoses;
                    stats.TotalDraws = totalDraws;
                    stats.AverageWins = averageWins;
                    dbContext.GameStatistics.Update(stats);
                }

                dbContext.SaveChanges();
            }
        }
    }
}
