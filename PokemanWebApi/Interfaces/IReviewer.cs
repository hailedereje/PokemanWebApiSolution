using PokemanWebApi.Model;

namespace PokemanWebApi.Interfaces
{
    public interface IReviewer
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewsByReviewer(int id);
        bool ReviewerExists(int id);
    }
}
