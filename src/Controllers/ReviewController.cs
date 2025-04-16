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

        [HttpPost]
        public IActionResult SubmitReview(ReviewViewModel model)
        {
            var userId = this.GetUserId();
            this.reviewService.AddNewItemInDB(model, userId);
            return RedirectToAction("Review");
        }

        [HttpGet]
        public IActionResult AdminReviews()
        {
            var reviews = reviewService.All();
            return View(reviews);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
    }
}