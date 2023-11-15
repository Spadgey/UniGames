namespace UniGames.Data.Models
{
    public class UserReview
    {
        public UserReview(string game, string platform, string user ,string review )
        {
            Game = game;
            Platform = platform;
            User = user;
            Review = review;

            
        }

        public string Game { get; set; }

        public string Platform { get; set; }

        public string User { get; set; }

        public string Review { get; set; }

    }
}