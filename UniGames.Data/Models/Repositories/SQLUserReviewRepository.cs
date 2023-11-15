using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniGames.Data.Models.Repositories
{
    public class SQLUserReviewRepository : UserReviewRepository
    {
        private readonly UniGamesDbContext dbContext;

        public SQLUserReviewRepository(UniGamesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<UserReview> GetAllUserReviews()
        {
            return dbContext.UserReview.ToList();
        }
    }
}
