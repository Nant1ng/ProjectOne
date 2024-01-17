using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Models;

namespace ProjectLibrary.RPS
{
    public class Show
    {
        public void Stats(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                Console.WriteLine("Rock Paper Scissor Stats.");

                foreach (GameStatistics statistics in dbContext.GameStatistics)
                {
                    double averageWinsPercentage = statistics.AverageWins * 100;

                    Console.WriteLine($"Total Games Played: {statistics.TotalGamesPlayed}");
                    Console.WriteLine($"Wins: {statistics.TotalWins}");
                    Console.WriteLine($"Loses: {statistics.TotalLoses}");
                    Console.WriteLine($"Draws: {statistics.TotalDraws}");
                    Console.WriteLine($"Average Wins: {averageWinsPercentage:N1}%");
                }

                Console.WriteLine();
                Console.WriteLine("Rock Paper Scissor Games.");

                foreach (RockPaperSicssorGame game in dbContext.RockPaperScissorGame)
                {
                    Console.WriteLine($"Player Choice: {game.PlayerChoice}, Computer Choice: {game.ComputerChoice}, Result: {game.Result}, Date: {game.GameDate}");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
