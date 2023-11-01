using UniGames.Api.Data;
using UniGames.Api.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UniGames.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly UniGamesDbContext dbContext;

        public ReviewController(UniGamesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetReviews")]
        public IActionResult GetReviews()
        {
            var reviewsDM = dbContext.Review.ToList();
            var reviewsDTO = new List<ReviewDTO>();
            foreach (var review in reviewsDM)
            {
                reviewsDTO.Add(new ReviewDTO()
                {
                    ReviewId = review.ReviewId,
                    ReviewBody = review.ReviewBody,
                    ReviewScore = review.ReviewScore,
                    GameId = Game.GameId,
                    UserId = User.UserId
                });
            }
            return Ok(reviewsDTO);
        }
    }
}
