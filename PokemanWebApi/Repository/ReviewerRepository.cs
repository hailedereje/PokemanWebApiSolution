using PokemanWebApi.Data;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Repository
{
    public class ReviewerRepository : IReviewer
    {
        private readonly ApplicationDbContext _context;

        public ReviewerRepository(ApplicationDbContext context)
        {
            _context = context;  
        }
        public Reviewer GetReviewer(int id)
        {
            var reviewer = _context.Reviewers.FirstOrDefault(x => x.Id == id);
            return reviewer;
        }

        public ICollection<Reviewer> GetReviewers()
        {
            var reviewers = _context.Reviewers.ToList();
            return reviewers;
        }

        public ICollection<Review> GetReviewsByReviewer(int id)
        {
            var review = _context.Reviews.Where(u => u.Reviewer.Id == id).ToList();
            return review;
        }

        public bool ReviewerExists(int id)
        {
            return _context.Reviewers.Any(u => u.Id == id);
        }
    }
}
