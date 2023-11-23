using System.ComponentModel.DataAnnotations;

namespace UniGames.Api.Models.Domain
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public string ReviewBody { get; set; }

        public string ReviewScore { get; set; }

        public int GameId { get; set; }

        public int UserId { get; set; }

        //navigation properties

        public Game Game { get; set; }

        public User User { get; set; }
    }
}
