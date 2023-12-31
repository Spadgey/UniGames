using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UniGames.Api.Data;
using Microsoft.EntityFrameworkCore;
using UniGames.Api.Models.DTOs;
using System.Reflection.Metadata.Ecma335;
using UniGames.Api.Models.Domain;

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
            var gamesDTO = new List<GameDTO>();

            try
            {
                var gamesDM = dbContext.Game.ToList();

                foreach (var game in gamesDM)
                {
                    gamesDTO.Add(new GameDTO()
                    {
                        GameId = game.GameId,
                        GameTitle = game.GameTitle,
                        GameDeveloper = game.GameDeveloper,
                        GameRelease = game.GameRelease,
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(gamesDTO);
        }

        [HttpPost]
        public IActionResult AddGame([FromBody] GameDTO gameDTO)
        {

            if (gameDTO == null)
            {

                return BadRequest("Invalid Data.");

            }

            var GameDM = new Game
            {

                GameId = gameDTO.GameId,
                GameTitle = gameDTO.GameTitle,
                GameDeveloper = gameDTO.GameDeveloper,
                GameRelease = gameDTO.GameRelease,
                PlatformId = gameDTO.PlatformId

            };

            dbContext.Game.Add(GameDM);
            dbContext.SaveChanges();

            var gamesDTO = new GameDTO
            {

                GameId = gameDTO.GameId,
                GameTitle = gameDTO.GameTitle,
                GameDeveloper = gameDTO.GameDeveloper,
                GameRelease = gameDTO.GameRelease,
                PlatformId = gameDTO.PlatformId

            };

            return CreatedAtAction("AddGame", new { id = gamesDTO.GameId }, gamesDTO);
        }
    }
}