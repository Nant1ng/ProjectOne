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

                                                   [3] Change a Calculation

                                                   [4] Delete a Calculation

                                                   [5] Recover a Calculation

                                                          [0] Exit

                ");
                Console.ResetColor();

                char key = Console.ReadKey().KeyChar;
                Console.Clear();

                CreateCalculation createCalc = new CreateCalculation();
                ShowCalculation readCalc = new ShowCalculation();
                UpdateCalculation updateCalc = new UpdateCalculation();
                DeleteCalculation deleteCalc = new DeleteCalculation();
                RecoverCalculation recoverCalc = new RecoverCalculation();

                switch (key)
                {
                    case '1':
                        createCalc.Create(options);
                        break;

                    case '2':
                        readCalc.Read(options);
                        break;

                    case '3':
                        updateCalc.Update(options);
                        break;

                    case '4':
                        deleteCalc.Delete(options);
                        break;

                    case '5':
                        recoverCalc.Recover(options);
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
