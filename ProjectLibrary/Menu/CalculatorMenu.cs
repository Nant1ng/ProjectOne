namespace ProjectLibrary.Menu
{
    public class CalculatorMenu
    {
        public void Menu()
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
                                                    [1] Plus

                                                    [2] Minus

                                                    [3] Times

                                                   [4] Division

                                                  [5] Square Root

                                                    [6] Modulus

                                                     [0] Exit
                ");
                Console.ResetColor();

                char key = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (key)
                {
                    case '1':

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
