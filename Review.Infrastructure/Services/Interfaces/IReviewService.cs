using Review.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Infrastructure.Services.Interfaces
{
    public interface IReviewService
    {
       void AddReview(ReviewDomain review);

       void DeleteReviewById(int reviewId);

       List<ReviewDomain> GetReviews();
    }
}
