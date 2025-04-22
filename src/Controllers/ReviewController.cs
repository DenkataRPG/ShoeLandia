using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeLandia.Data.Models;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Review;

namespace ShoeLandia.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var reviews = reviewService.All();
            return View(reviews);
        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public IActionResult SubmitReview(ReviewViewModel model)
        {
            var userId = this.GetUserId();
            this.reviewService.AddNewReviewInDB(model, userId);

            return RedirectToAction("All", "Review");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AdminReviews()
        {
            var reviews = reviewService.All();
            return View(reviews);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ReviewViewModel model = await this.reviewService.GetReviewForEditByIdAsync(id);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, ReviewViewModel model)
        {
            await this.reviewService.EditReviewAsync(model, id);
            return RedirectToAction("All", "Review");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.reviewService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return this.Forbid();
            }

            return this.RedirectToAction("AdminReviews", "Review");
        }
    }
}