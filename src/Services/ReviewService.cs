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

        public void AddNewItemInDB(ReviewViewModel reviewModel, string userId)
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

        public Task EditItemAsync(ReviewViewModel model, string reviewId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewViewModel> GetItemForEditByIdAsync(string reviewId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string reviewId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
