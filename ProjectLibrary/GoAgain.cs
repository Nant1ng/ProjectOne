namespace ProjectLibrary
{
    public class GoAgain
    {
        public string Restart(string message)
        {
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine($"{message} (yes/no)");
                string? playAgain = Console.ReadLine();

                if (playAgain != null)
                {
                    playAgain = playAgain.Trim().ToLower();

                    if (playAgain == "yes")
                    {
                        Console.Clear();
                        return "yes";
                    }
                    else if (playAgain == "no")
                    {
                        Console.Clear();
                        return "no";
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You must answer with yes or no!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input! You must answer with yes or no");
                    Console.ResetColor();
                }
            }
        }
    }
}
