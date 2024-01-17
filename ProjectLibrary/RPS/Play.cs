using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Models;

namespace ProjectLibrary.RPS
{
    public class Play
    {
        public void Game(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                bool isPlaying = true;
                do
                {
                    UserChoice userChoice = new UserChoice();
                    ComputerChoice computerChoice = new ComputerChoice();
                    WinnerCheck result = new WinnerCheck();
                    DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                    GoAgain goAgain = new GoAgain();

                    try
                    {
                        RockPaperScissor player = userChoice.GetUserChoice();
                        RockPaperScissor computer = computerChoice.GetComputerChoice();
                        var gameResult = result.DetermineResult(player, computer);

                        if (gameResult == Result.Draw)
                            Console.WriteLine($"You chose {player}, computer chose {computer}. It's a {gameResult}!");
                        else if (gameResult == Result.Win)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You chose {player}, computer chose {computer}. You {gameResult}!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"You chose {player}, computer chose {computer}. You {gameResult}!");
                            Console.ResetColor();
                        }

                        RockPaperSicssorGame newGame = new RockPaperSicssorGame(player, computer, gameResult, today);
                        dbContext.RockPaperScissorGame.Add(newGame);
                        dbContext.SaveChanges();

                        UpdateStats statsUpdater = new UpdateStats();
                        statsUpdater.UpdateGameStats(options);

                        string message = "Do you want to play again?";
                        string restart = goAgain.Restart(message);

                        if (restart == "yes")
                            Console.Clear();
                        else
                        {
                            isPlaying = false;
                            Console.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                } while (isPlaying);
            }
        }
    }
}
