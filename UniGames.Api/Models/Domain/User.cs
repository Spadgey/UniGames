using System.ComponentModel.DataAnnotations;

namespace UniGames.Api.Models.Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserFName { get; set;}

        public string UserLName { get; set;}

        public string UserDOB { get; set;}

        public string UserEmail { get; set;}
    }
}
