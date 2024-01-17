using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.RPS;

namespace ProjectLibrary.Menu
{
    public class RPSMenu
    {
        public void Menu(DbContextOptionsBuilder<AppDBContext> options)
        {
            bool isRunning = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
                    ██████╗                   ██████╗                      ███████╗
                    ██╔══██╗                  ██╔══██╗                     ██╔════╝
                    ██████╔╝                  ██████╔╝                     ███████╗
                    ██╔══██╗                  ██╔═══╝                      ╚════██║
                    ██║  ██║                  ██║                          ███████║
                    ╚═╝  ╚═╝                  ╚═╝                          ╚══════╝
                    _______                 _______                        _______
                ---'   ____)            ---'   ____)____               ---'   ____)____
                      (_____)                     ______)                        ______)
                       (_____)                    _______)                    __________)
                       (____)                     _______)                   (____)
                ---.__(___)             ---.__________)                ---.__(___)
                 ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"
                                              [1] Play Rock Paper Scissors

                                               [2] See Previous Matches

                                                      [0] Exit
                ");
                Console.ResetColor();

                char key = Console.ReadKey().KeyChar;
                Console.Clear();

                Play play = new Play();
                Show show = new Show();

                switch (key)
                {
                    case '1':
                        play.Game(options);
                        break;

                    case '2':
                        show.Stats(options);
                        break;

                    case '0':
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid selection. Please choose a valid option.");
                        Console.ResetColor();
                        break;
                }
            } while (isRunning);
        }
    }
}
