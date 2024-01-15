namespace ProjectLibrary.Menu
{
    public class ShapesMenu
    {
        public void Menu()
        {
            bool isRunning = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
             _____                                                                                  /\
            |     |                                                                                /  \
            |     |                                                                               /    \
            |_____|                                                                              /______\

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
                                                      [1] Rectangle

                                                    [2] Parallelogram

                                                      [3] Triangle

                                                      [4] Rhombus

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

                    case '4':

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
