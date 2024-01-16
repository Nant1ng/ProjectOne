using ProjectLibrary.Enumeration;

namespace ProjectLibrary.Models
{
    public class RockPaperSicssor
    {
        public int Id { get; set; }
        public RockPaperScissor PlayerChoice { get; set; }
        public RockPaperScissor ComputerChoice { get; set; }
        public Result Result { get; set; }
        public DateOnly GameDate { get; set; }

        public RockPaperSicssor(RockPaperScissor playerChoice, RockPaperScissor computerChoice, Result result, DateOnly gameDate)
        {
            PlayerChoice = playerChoice;
            ComputerChoice = computerChoice;
            Result = result;
            GameDate = gameDate;
        }
    }
}