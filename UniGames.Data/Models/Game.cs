namespace UniGames.Data.Models
{
    public class Game
    {
        public Game(string title, string platform, int uniGamesScore)
        {
            Title = title;
            Platform = platform;
            UniGamesScore = uniGamesScore;
        }
        
        public string Title { get; set; }
        
        public string Platform { get; set; }

        public int UniGamesScore { get; set; }
    }
}