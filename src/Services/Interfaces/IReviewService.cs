using ShoeLandia.ViewModels.Review;

namespace ShoeLandia.Services.Interfaces
{
    public interface IReviewService
    {
        public List<ReviewViewModel> All();
        void AddNewReviewInDB(ReviewViewModel review, string userId);
        public ShoeLandia.Data.Models.Review GetById<Review>(string reviewId);

        public Task EditReviewAsync(ReviewViewModel model, string reviewId);

        public Task<ReviewViewModel> GetReviewForEditByIdAsync(string reviewId);

        public Task DeleteAsync(string reviewId);
    }
}
