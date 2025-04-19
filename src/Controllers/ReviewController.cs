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
        public IActionResult Review()
        {
            var reviews = reviewService.All();
            return View(reviews);
        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public IActionResult SubmitReview(ReviewViewModel model)
        {
            var userId = this.GetUserId();
            this.reviewService.AddNewItemInDB(model, userId);

            return RedirectToAction("Review");
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
        public IActionResult Edit()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
    }
}