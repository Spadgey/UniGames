using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniGames.Data.Models;

namespace UniGames.Api.Models.Domain
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        public string GameTitle { get; set;}

        public string GameDeveloper { get; set;}

        public string GameRelease { get; set;}

        public int PlatformId { get; set;}

        // navigation properties
        public Platform Platform { get; set;}
    }
}
