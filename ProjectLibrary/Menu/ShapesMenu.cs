using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Geometry;

namespace ProjectLibrary.Menu
{
    public class ShapesMenu
    {
        public void Menu(DbContextOptionsBuilder<AppDBContext> options)
        {
            bool isRunning = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
             ________                                                                               /\
            |        |                                                                             /  \
            |        |                                                                            /    \
            |________|                                                                           /______\

                                    ███████╗██╗  ██╗ █████╗ ██████╗ ███████╗███████╗
                                    ██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██╔════╝
                                    ███████╗███████║███████║██████╔╝█████╗  ███████╗
                                    ╚════██║██╔══██║██╔══██║██╔═══╝ ██╔══╝  ╚════██║
                                    ███████║██║  ██║██║  ██║██║     ███████╗███████║
                                    ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚══════╝

            ________                                                                                /\
           /       /                                                                               /  \
          /_______/                                                                                \  /
                                                                                                    \/ ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"
                                              [1] Make a Geometry Calculation

                                           [2] See Previous Geometry Calculations

                                              [3] Change a Geometry Calculation

                                              [4] Delete a Geometry Calculation

                                              [5] Recover a Geometry Calculation

                                                         [0] Exit
                ");
                Console.ResetColor();

                char key = Console.ReadKey().KeyChar;
                Console.Clear();

                CreateGeometryCalculation createGeometryCalc = new CreateGeometryCalculation();
                ShowGeometryCalculation showGeometryCalc = new ShowGeometryCalculation();
                UpdateGeometryCalculation updateGeometryCalc = new UpdateGeometryCalculation();
                DeleteGeometryCalculation deleteGeometryCalc = new DeleteGeometryCalculation();
                RecoverGeometryCalculation recoverGeometryCalc = new RecoverGeometryCalculation();


                switch (key)
                {
                    case '1':
                        createGeometryCalc.Create(options);
                        break;

                    case '2':
                        showGeometryCalc.Read(options);
                        break;

                    case '3':
                        updateGeometryCalc.Update(options);
                        break;

                    case '4':
                        deleteGeometryCalc.Delete(options);
                        break;

                    case '5':
                        recoverGeometryCalc.Recover(options);
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
