using ProjectLibrary.Enumeration;

namespace ProjectLibrary.RPS
{
    public class ComputerChoice
    {
        public RockPaperScissor GetComputerChoice()
        {
            Random random = new Random();
            int computerChoice = random.Next(0, 3);

            return (RockPaperScissor)computerChoice;
        }
    }
}
