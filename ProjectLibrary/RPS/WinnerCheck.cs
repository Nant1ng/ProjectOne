using ProjectLibrary.Enumeration;

namespace ProjectLibrary.RPS
{
    public class WinnerCheck
    {
        public Result DetermineResult(RockPaperScissor playerChoice, RockPaperScissor computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return Result.Draw;
            }

            switch (playerChoice)
            {
                case RockPaperScissor.Rock:
                    return (computerChoice == RockPaperScissor.Scissor) ? Result.Win : Result.Lose;
                case RockPaperScissor.Paper:
                    return (computerChoice == RockPaperScissor.Rock) ? Result.Win : Result.Lose;
                case RockPaperScissor.Scissor:
                    return (computerChoice == RockPaperScissor.Paper) ? Result.Win : Result.Lose;
                default:
                    throw new InvalidOperationException("Invalid choice.");
            }
        }
    }
}
