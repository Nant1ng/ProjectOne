namespace ProjectOne
{
    public class App
    {
        public static void Run()
        {
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
                                                                                                                   
                                                    [1] Shapes

                                                  [2] Calculator

                                               [3] Rock Paper Scissors

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
