using Microsoft.AspNetCore.Mvc;
using UniGames.Data;
using UniGames.Data.Models;

// testing a change in Git

namespace UniGames.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet(Name = "GetGames")]
        public IEnumerable<Game> Get()
        {
            GameRepository gamesRepository = new GameRepository();

            IEnumerable<Game> games = gamesRepository.GetGames();

            return games.Take(20);
        }
    }
}