using Review.Infrastructure.Services.Interfaces;
using Review.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Review.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public ActionResult Index()
        {
            try
            {
                var model = _reviewService.GetReviews().Select(data => new ReviewModel()
                {
                    Address = data.Address,
                    Organization = data.OrganizationName,
                    Rate = data.Rate,
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
                throw;
            }
        }

        [HttpPost]
        public ActionResult ShowInfo(ReviewInfoModel infoModel)
        {
            TempData["infoModel"] = infoModel;
            return Json(new { redirectUrl = Url.Action("Info", "Review") });
        }

        public ActionResult Info()
        {
            TempData.Keep("infoModel");
            var info = TempData["infoModel"];
            return View(info);
        }
    }
}