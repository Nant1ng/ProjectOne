using ProjectLibrary.Enumeration;

namespace ProjectLibrary.RPS
{
    public class UserChoice
    {
        public RockPaperScissor GetUserChoice()
        {
            Console.ResetColor();
            Console.WriteLine("Choose Rock, Paper, or Scissor.");
            Console.WriteLine("You can also pick by 0, 1, 2.");
            Console.Write("Your Choice: ");
            string? userInput = Console.ReadLine();

            if (Enum.TryParse<RockPaperScissor>(userInput, true, out var userChoice))
            {
                return userChoice;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Invalid choice. Please enter Rock, Paper, Scissor or 0, 1, 2.");
            }
        }
    }
}
