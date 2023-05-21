using PokemanWebApi.Data;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;
using System.Linq;

namespace PokemanWebApi.Repository
{
    public class ReviewRepository : IReview
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Pokeman? GetPokemanByReview(int reviewId)
        {
            var pokeman = _context.Reviews.Where(u => u.Id == reviewId).Select(u =>u.Pokeman).FirstOrDefault();
            return pokeman;
        }

        public Review GetReview(int reviewId)
        {
            var review = _context.Reviews.FirstOrDefault(u => u.Id == reviewId);
            return review;
        }

        public ICollection<Review> GetReviewByPokeman(int pokemanId)
        {
            var reviews = _context.Reviews.Where(u => u.Pokeman.Id == pokemanId).ToList();
            return reviews;
        }

        public Reviewer GetReviewerByReview(int reviewId)
        {
            var reviewer = _context.Reviews.Where(u =>u.Id == reviewId)
                                           .Select(u =>u.Reviewer)
                                           .FirstOrDefault();
            return reviewer;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public bool ReviewExist(int reviewId)
        {
            return _context.Reviews.Any(u=> u.Id == reviewId);
        }
    }
}
