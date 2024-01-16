namespace ProjectLibrary.Menu
{
    public class RPSMenu
    {
        public void Menu()
        {
            bool isRunning = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
██████╗  ██████╗  ██████╗██╗  ██╗  ██████╗  █████╗ ██████╗ ███████╗██████╗   ███████╗██╗ ██████╗███████╗███████╗ ██████╗ ██████╗
██╔══██╗██╔═══██╗██╔════╝██║ ██╔╝  ██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗  ██╔════╝██║██╔════╝██╔════╝██╔════╝██╔═══██╗██╔══██╗
██████╔╝██║   ██║██║     █████╔╝   ██████╔╝███████║██████╔╝█████╗  ██████╔╝  ███████╗██║██║     ███████╗███████╗██║   ██║██████╔╝
██╔══██╗██║   ██║██║     ██╔═██╗   ██╔═══╝ ██╔══██║██╔═══╝ ██╔══╝  ██╔══██╗  ╚════██║██║██║     ╚════██║╚════██║██║   ██║██╔══██╗
██║  ██║╚██████╔╝╚██████╗██║  ██╗  ██║     ██║  ██║██║     ███████╗██║  ██║  ███████║██║╚██████╗███████║███████║╚██████╔╝██║  ██║
╚═╝  ╚═╝ ╚═════╝  ╚═════╝╚═╝  ╚═╝  ╚═╝     ╚═╝  ╚═╝╚═╝     ╚══════╝╚═╝  ╚═╝  ╚══════╝╚═╝ ╚═════╝╚══════╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝
            _______                                   _______                                         _______
        ---'   ____)                              ---'   ____)____                                ---'   ____)____
              (_____)                                       ______)                                         ______)
               (_____)                                      _______)                                     __________)
               (____)                                      _______)                                     (____)
        ---.__(___)                               ---.__________)                                 ---.__(___)
                 ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"
                                                      [1] Play

                                               [2] See Previous Matches

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
