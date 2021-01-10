using Review.Infrastructure.Services.Interfaces;
using Review.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using Review.Infrastructure.Domain;
using Review.Infrastructure.Data.Interfaces;

namespace Review.Infrastructure.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<ReviewDomain> _reviewRepository;

        public ReviewService(IRepository<ReviewDomain> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void AddReview(ReviewDomain review)
        {
            _reviewRepository.Insert(review);
        }

        public void DeleteReviewById(int reviewId)
        {
           var review = _reviewRepository.Table.FirstOrDefault(domain => domain.Id == reviewId);
            review.IsDeleted = true;
            _reviewRepository.Update(review);
        }

        public List<ReviewDomain> GetReviews()
            => _reviewRepository.Table.Where(review => !review.IsDeleted).OrderByDescending(data => data.CreateDate).ToList();
    }
}
