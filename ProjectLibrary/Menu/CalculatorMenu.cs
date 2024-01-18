using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Calc;
using ProjectLibrary.Data;

namespace ProjectLibrary.Menu
{
    public class CalculatorMenu
    {
        public void Menu(DbContextOptionsBuilder<AppDBContext> options)
        {
            bool isRunning = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
          +         ██████╗ █████╗ ██╗      ██████╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗      /
                   ██╔════╝██╔══██╗██║     ██╔════╝██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗     
          -        ██║     ███████║██║     ██║     ██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝     √
                   ██║     ██╔══██║██║     ██║     ██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗     
          *        ╚██████╗██║  ██║███████╗╚██████╗╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║     %
                    ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝     

                 ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"
                                                   [1] Make a Calculation

                                                 [2] See Previous Calculations

                                                  [3] Change a Calculations

                                                  [4] Delete a Calculations

                                                          [0] Exit

                ");
                Console.ResetColor();

                char key = Console.ReadKey().KeyChar;
                Console.Clear();

                StartCalculation calc = new StartCalculation();

                switch (key)
                {
                    case '1':
                        calc.Start(options);
                        break;

                    case '2':

                        break;

                    case '3':

                        break;

                    case '0':
                        isRunning = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid selection. Please choose a valid option.");
                        Console.ResetColor();
                        break;
                }
            } while (isRunning);
        }
    }
}
