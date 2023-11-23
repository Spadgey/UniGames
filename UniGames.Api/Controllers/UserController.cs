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
        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteUser([FromRoute] int id)
        {
            var UserDM = dbContext.User.FirstOrDefault(x => x.UserId == id);

            if (UserDM == null)
            {
                return NotFound();
            }

            // Delete author
            dbContext.User.Remove(UserDM);
            dbContext.SaveChanges();

            //return deleted author back - map DM to DTO
            var userDTO = new UserDTO
            {
                UserId = UserDM.UserId,
                UserFName = UserDM.UserFName,
                UserLName = UserDM.UserLName,
            };
            return Ok(userDTO);
        }
    }
}