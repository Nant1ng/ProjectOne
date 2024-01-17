namespace ProjectLibrary.Models
{
    public class GameStatistics
    {
        public int Id { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalLoses { get; set; }
        public int TotalDraws { get; set; }
        public double AverageWins { get; set; }
        public GameStatistics(int totalGamesPlayed, int totalWins, int totalLoses, int totalDraws, double averageWins)
        {
            TotalGamesPlayed = totalGamesPlayed;
            TotalWins = totalWins;
            TotalLoses = totalLoses;
            TotalDraws = totalDraws;
            AverageWins = averageWins;
        }
    }
}
