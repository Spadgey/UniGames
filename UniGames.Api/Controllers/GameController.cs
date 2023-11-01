using Microsoft.AspNetCore.Mvc;
using UniGames.Data;
using Microsoft.AspNetCore.Http;
using UniGames.Api.Data;
using Microsoft.EntityFrameworkCore;

// testing a change in Git

namespace UniGames.Api.Controllers
{    
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly UniGamesDbContext dbContext;

        public GameController(UniGamesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet(Name = "GetGames")]
        public IActionResult GetGames()
        {
            var games = dbContext.Game.Include(x => x.Platform).ToList();
            return Ok(games);
        }
    }
}