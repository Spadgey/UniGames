using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniGames.Data;
using UniGames.Data.Models;
using UniGames.Data.Models.Repositories;

namespace UniGames.Api.Controllers

{


    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewsController : ControllerBase
    {
        [HttpGet(Name = "GetUserReview")]
        public IEnumerable<UserReview> Get()
        {
            UserReviewRepository userreviewrepository = new UserReviewRepository();

            IEnumerable<UserReview> UserReview = userreviewrepository.GetUserReview();

            return UserReview.Take(20);
        }
    }
}
