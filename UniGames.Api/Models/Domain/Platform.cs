using System.ComponentModel.DataAnnotations;
using UniGames.Data.Models;

namespace UniGames.Api.Models.Domain
{
    public class Platform
    {
        public int PlatformId { get; set; }

        public string PlatformSystem { get; set; }
    }
}
