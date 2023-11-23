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
                    GameId = review.GameId,
                    UserId = review.UserId
                });
            }
            return Ok(reviewsDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteReview([FromRoute] int id)
        {
            var ReviewDM = dbContext.Review.FirstOrDefault(x => x.ReviewId == id);

            if (ReviewDM == null)
            {
                return NotFound();
            }

            dbContext.Review.Remove(ReviewDM);
            dbContext.SaveChanges();

            var ReviewDTO = new ReviewDTO
            {
                ReviewId = ReviewDM.ReviewId,
                ReviewBody = ReviewDM.ReviewBody,
                ReviewScore = ReviewDM.ReviewScore,
                GameId = ReviewDM.GameId,
                UserId = ReviewDM.UserId
            };
           return Ok(ReviewDTO);
        }  
   
    }
}
