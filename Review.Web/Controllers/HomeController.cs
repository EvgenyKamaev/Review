using Review.Infrastructure.Domain;
using Review.Infrastructure.Services.Interfaces;
using Review.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Review.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReviewService _reviewService;

        public HomeController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public ActionResult Index()
        {
            var model = new HomeModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateReview(HomeModel model)
        {
            var review = new ReviewDomain()
            {
                UserName = model.UserName,
                LikeMessage = model.LikeMessage,
                DislikeMessage = model.DislikeMessage,
                Comment = model.Comment,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                Rate = Int32.Parse(model.Rate),
                Address = model.Address,
                OrganizationName = model.Organization
            };
            try
            {
                _reviewService.AddReview(review);
                return Json(new { redirectUrl = Url.Action("Index", "Review") });
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}