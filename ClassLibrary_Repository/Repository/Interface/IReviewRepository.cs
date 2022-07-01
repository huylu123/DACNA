using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface IReviewRepository
    {
        List<Review> searchReview(string keyword);
        List<Review> getAllReview();
        void addReview (Review newreview);
        bool updateReview (Review newreview);
        bool deleteReview(int reviewId);
        Review getReview(int reviewId);
    }
}
