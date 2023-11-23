using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGames.Api.Data;
using UniGames.Api.Models.DTOs;

namespace UniGames.Api.Controllers

{

    [Route("[controller]")]
    [ApiController]
    public class GameReviewController : ControllerBase
    {
        private readonly UniGamesDbContext dbContext;

        public GameReviewController(UniGamesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetGameReviews")]
        public IActionResult GetAllGameReviewss(int GameId)
        {
            var game = dbContext.Game.Include(x => x.Platform).Where(x => x.GameId == GameId).FirstOrDefault();

            var reviews = dbContext.Review.Include(x => x.User).Where(x => x.GameId == GameId);

            var userreviewsDTO = new List<GameReviewsDTO>();
            foreach (var review in reviews)
            {
                userreviewsDTO.Add(new GameReviewsDTO()
                {
                    GameTitle = game.GameTitle,
                    UserFName = review.User.UserFName,
                    UserLName = review.User.UserLName,
                    PlatformSystem =game.Platform.PlatformSystem,

                });
                
            }
            return Ok(userreviewsDTO);
        }

    }
}
