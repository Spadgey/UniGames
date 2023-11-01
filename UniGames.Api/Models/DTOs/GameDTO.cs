namespace UniGames.Api.Models.DTOs
{
    public class GameDTO
    {
        public int GameId { get; set; }

        public string GameTitle { get; set; }

        public string GameDeveloper { get; set; }

        public string GameRelease { get; set; }

        public int PlatformId { get; set; }
    }
}
