using ShoeLandia.ViewModels.Review;

namespace ShoeLandia.Services.Interfaces
{
    public interface IReviewService
    {
        public List<ReviewViewModel> All();
        void AddNewItemInDB(ReviewViewModel review, string userId);
        public ShoeLandia.Data.Models.Review GetById<Review>(string reviewId);

        public Task EditItemAsync(ReviewViewModel model, string reviewId, string userId);

        public Task<ReviewViewModel> GetItemForEditByIdAsync(string reviewId, string userId);

        public Task DeleteAsync(string reviewId, string userId);
    }
}
