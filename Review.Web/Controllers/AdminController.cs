using Review.Infrastructure.Services.Interfaces;
using Review.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Review.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IReviewService _reviewService;

        public AdminController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public ActionResult Index()
        {
            try
            {
                var model = _reviewService.GetReviews().Select(data => new AdminModel()
                {
                    Address = data.Address,
                    Organization = data.OrganizationName,
                    Rate = data.Rate,
                    Id = data.Id,
                    ReviewInfo = new ReviewInfoModel()
                    {
                        UserName = data.UserName,
                        Comment = data.Comment,
                        DislikeMessage = data.DislikeMessage,
                        Id = data.Id,
                        LikeMessage = data.LikeMessage
                    }
                }).ToList();
                return View(model);
            }
            
            catch(Exception ex)
            {
                return View(new AdminModel());
            }
        }

        [HttpGet]
        public void DeleteReview(int reviewId)
        {
            try
            {
                _reviewService.DeleteReviewById(reviewId);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}