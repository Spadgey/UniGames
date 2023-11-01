using Microsoft.Identity.Client;

namespace UniGames.Api.Models.DTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }

        public string ReviewBody { get; set; }

        public string ReviewScore { get; set; }

        public int GameId { get; set; }

        public int UserId { get; set; }
    }
}
