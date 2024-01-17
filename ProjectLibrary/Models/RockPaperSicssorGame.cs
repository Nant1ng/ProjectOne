using ProjectLibrary.Enumeration;

namespace ProjectLibrary.Models
{
    /// <summary>
    /// Represents a single game of Rock Paper Scissors. 
    /// It includes properties for tracking the player's choice, 
    /// the computer's choice, the result of the game, and the date the game was played.
    /// </summary>
    public class RockPaperSicssorGame
    {
        public int Id { get; set; }
        public RockPaperScissor PlayerChoice { get; set; }
        public RockPaperScissor ComputerChoice { get; set; }
        public Result Result { get; set; }
        public DateOnly GameDate { get; set; }

        public RockPaperSicssorGame(RockPaperScissor playerChoice, RockPaperScissor computerChoice, Result result, DateOnly gameDate)
        {
            PlayerChoice = playerChoice;
            ComputerChoice = computerChoice;
            Result = result;
            GameDate = gameDate;
        }
    }
}