using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly BookEcommerceContext _context;
        public ReviewRepository(BookEcommerceContext context) => _context = context;

        public void addReview(Review newreview)
        {
            try
            {
                _context.Reviews.Add(newreview);
                _context.SaveChanges();
            }
            catch ( Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool deleteReview(int reviewId)
        {
            Review review = _context.Reviews.Find(reviewId);
            if (review != null)
            {
                try
                {
                    _context.Reviews.Remove(review);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public List<Review> getAllReview()
        {
            List<Review> reviews = _context.Reviews.ToList();
            return reviews;
        }
        public Review getReview(int reviewId)
        {
            Review review = _context.Reviews.Find(reviewId);
            return review;
        }

        public List<Review> searchReview(string keyword)
        {
            List<Review> reviews = _context.Reviews.Where(r => r.Account.Username.Contains(keyword)).ToList();
            return reviews;
        }

        public bool updateReview(Review newreview)
        {
            Review review = _context.Reviews.SingleOrDefault(review => review.Id.Equals(newreview.Id));
            if(review != null)
            {
                try
                {
                    //review.BookId = newreview.BookId;
                    //review.AccountId = newreview.AccountId;
                    review.Comment = newreview.Comment;
                    _context.Reviews.Update(review);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
    }
}
