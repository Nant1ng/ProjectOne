using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectLibrary.Data;
using ProjectLibrary.Menu;
using ProjectLibrary.RPS;

namespace ProjectOne
{
    public class App
    {
        public static void Run()
        {
            // Boiler Plate Code
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"Appsettings.json", true, true);
            var config = builder.Build();

            DbContextOptionsBuilder<AppDBContext> options = new DbContextOptionsBuilder<AppDBContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new AppDBContext(options.Options))
            {
                var dataPopulator = new DataPopulator();
                dataPopulator.MigrateAndPopulate(dbContext);

                UpdateStats statsUpdater = new UpdateStats();
                statsUpdater.UpdateGameStats(options);
            }

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
                 ██████╗ █████╗ ██╗      ██████╗██╗   ██╗██╗      █████╗ ████████╗██╗ ██████╗ ███╗   ██╗
                ██╔════╝██╔══██╗██║     ██╔════╝██║   ██║██║     ██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║
                ██║     ███████║██║     ██║     ██║   ██║██║     ███████║   ██║   ██║██║   ██║██╔██╗ ██║
                ██║     ██╔══██║██║     ██║     ██║   ██║██║     ██╔══██║   ██║   ██║██║   ██║██║╚██╗██║
                ╚██████╗██║  ██║███████╗╚██████╗╚██████╔╝███████╗██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║
                 ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝
                 ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"
                                                    [1] Shapes

                                                  [2] Calculator

                                               [3] Rock Paper Scissors

                                                     [0] Exit
                ");
                Console.ResetColor();

                char key = Console.ReadKey().KeyChar;
                Console.Clear();

                ShapesMenu shapes = new ShapesMenu();
                CalculatorMenu calculator = new CalculatorMenu();
                RPSMenu rockPaperScissors = new RPSMenu();

                switch (key)
                {
                    case '1':
                        shapes.Menu();
                        break;

                    case '2':
                        calculator.Menu();
                        break;

                    case '3':
                        rockPaperScissors.Menu(options);
                        break;

                    case '0':
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid selection. Please choose a valid option.");
                        Console.ResetColor();
                        break;
                }
            } while (true);
        }
    }
}
