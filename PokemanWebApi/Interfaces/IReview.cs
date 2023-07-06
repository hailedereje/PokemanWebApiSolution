using PokemanWebApi.Model;

namespace PokemanWebApi.Interfaces
{
    public interface IReview
    {
        ICollection<Review> GetReviews();
        Review? GetReview(int reviewId);
        Pokeman? GetPokemanByReview(int reviewId);
        Reviewer GetReviewerByReview(int reviewId);
        ICollection<Review> GetReviewByPokeman(int pokemanId);
        bool ReviewExist(int reviewId);
    }
}
