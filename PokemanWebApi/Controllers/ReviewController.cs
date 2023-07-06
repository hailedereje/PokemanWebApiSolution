using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemanWebApi.DTO;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;
using System.Collections.Generic;

namespace PokemanWebApi.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReview _review;
        private readonly IMapper _mapper;
        private readonly IPokeman _pokeman;

        public ReviewController(IReview review,IMapper mapper,IPokeman pokeman)
        {
            _mapper = mapper;
            _review = review;
            _pokeman = pokeman;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ReviewDTO>))]
        public ActionResult<ICollection<ReviewDTO>> GetReviews()
        {
            var reviews = _mapper.Map<ICollection<ReviewDTO>>(_review.GetReviews());
            return Ok(reviews);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(ReviewDTO))]
        public ActionResult<ReviewDTO> GetReview(int id)
        {
            if (!_review.ReviewExist(id))
            {
                return NotFound(id);
            }
            var review = _mapper.Map<ReviewDTO>(_review.GetReview(id));
            return Ok(review);
        }

        [HttpGet("{id:int}/reviewer")]
        [ProducesResponseType(200, Type = typeof(ReviewDTO))]
        public ActionResult<ReviewerDTO> GetReviewerByReview(int id)
        {
            if (!_review.ReviewExist(id))
            {
                return NotFound(id);
            }
            var reviewer = _mapper.Map<ReviewerDTO>(_review.GetReviewerByReview(id));
            return Ok(reviewer);
        }

        [HttpGet("pokeman/{id:int}")]
        [ProducesResponseType(200, Type = typeof(ReviewDTO))]
        public ActionResult<ICollection<ReviewDTO>> GetReviewByPokeman(int id)
        {
            if (_pokeman.PokemanExists(id))
            {
                return NotFound(id);
            }
            var reviews = _mapper.Map<ICollection<ReviewDTO>>(_review.GetReviewByPokeman(id));
            return Ok(reviews);
        }
    }
}
