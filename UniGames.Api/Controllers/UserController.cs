using UniGames.Api.Data;
using UniGames.Api.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniGames.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UniGamesDbContext dbContext;

        public UserController(UniGamesDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetUsers")]
        public IActionResult GetAllUsers()
        {
            var usersDM = dbContext.User.ToList();
            var usersDTO = new List<UserDTO>();
            foreach (var user in usersDM)
            {
                usersDTO.Add(new UserDTO()
                {
                    UserId = user.UserId,
                    UserFName = user.UserFName,
                    UserLName = user.UserLName
                });
            }


            return Ok(usersDTO);
        }
    }
}
