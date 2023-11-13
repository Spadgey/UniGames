using UniGames.Api.Data;
using UniGames.Api.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UniGames.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly UniGamesDbContext dbContext;

        public PlatformController(UniGamesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetPlatform")]
        public IActionResult GetPlatforms()
        {
            var platformsDM = dbContext.Platform.ToList();
            var platformsDTO = new List<PlatformDTO>();
            foreach (var platform in platformsDM)
            {
                platformsDTO.Add(new PlatformDTO()
                {
                    PlatformId = platform.PlatformId,
                    PlatformSystem = platform.PlatformSystem
                });
            }
            return Ok(platformsDTO);
        }
    }
}
