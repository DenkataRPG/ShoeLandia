using Microsoft.EntityFrameworkCore;
using ShoeLandia.Data;
using ShoeLandia.Data.Models;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Review;

namespace ShoeLandia.Services
{
    public class ReviewService: IReviewService
    {
        private readonly ApplicationDbContext dbContext;

        public ReviewService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ReviewViewModel> All()
        {
            var reviews = dbContext.Reviews.Where(x => x.IsDeleted == false).Select(x => new ReviewViewModel()
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                Rating = x.Rating,
                Comment = x.Comment,
                Date = x.Date,
                IsDeleted = x.IsDeleted,
                AuthorId = x.AuthorId,
            }).ToList();

            return reviews.ToList();
        }

        public void AddNewReviewInDB(ReviewViewModel reviewModel, string userId)
        {
            Review review = new Review()
            {
                Id = Guid.NewGuid().ToString(),
                CustomerName = reviewModel.CustomerName,
                Rating = reviewModel.Rating,
                Comment = reviewModel.Comment,
                Date = DateTime.UtcNow.AddHours(+3),
                IsDeleted = reviewModel.IsDeleted,
                AuthorId = userId,
            };

            dbContext.Reviews.Add(review);
            dbContext.SaveChanges();
        }

        public Data.Models.Review GetById<Review>(string reviewId)
        {
            throw new NotImplementedException();
        }

        public async Task EditReviewAsync(ReviewViewModel model, string reviewId)
        {
            Review review = await dbContext
                .Reviews
                .Where(x => x.IsDeleted == false)
                .FirstAsync(x => x.Id == reviewId);

            review.CustomerName = model.CustomerName;
            review.Rating = model.Rating;
            review.Comment = model.Comment;
            review.Date = DateTime.UtcNow.AddHours(3);
            review.Id = model.Id;
            review.IsDeleted = model.IsDeleted;
            review.AuthorId = model.AuthorId;

            await this.dbContext.SaveChangesAsync();

        }

        public async Task<ReviewViewModel> GetReviewForEditByIdAsync(string reviewId)
        {
            return await dbContext
                .Reviews
                .Where(x => x.Id == reviewId)
                .Select(x => new ReviewViewModel
                {
                    Comment = x.Comment,
                    Date = x.Date,
                    Id = x.Id,
                    IsDeleted = x.IsDeleted,
                    AuthorId = x.AuthorId,
                    CustomerName = x.CustomerName,
                    Rating = x.Rating,
                })
                .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(string reviewId)
        {
             Review review = await this.dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == reviewId);

            review.IsDeleted = true;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
