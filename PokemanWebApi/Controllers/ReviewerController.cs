using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemanWebApi.DTO;
using PokemanWebApi.Interfaces;

namespace PokemanWebApi.Controllers
{
    [ApiController]
    [Route("api/reviewer")]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewer _reviewer;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewer reviewer, IMapper mapper)
        {
            _mapper = mapper;
            _reviewer = reviewer;
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(ICollection<ReviewerDTO>))]
        public ActionResult<ICollection<ReviewerDTO>> GetReviewers()
        {
            var reviewers = _mapper.Map<ICollection<ReviewerDTO>>(_reviewer.GetReviewers());
            return Ok(reviewers);
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(200,Type=typeof(ReviewerDTO))]
        public ActionResult<ReviewerDTO> GetReviewer(int id)
        {
            if (!_reviewer.ReviewerExists(id))
                return NotFound(id);
            var reviewer = _mapper.Map<ReviewDTO>(_reviewer.GetReviewer(id));
            return Ok(reviewer);
        }

        [HttpGet("{id:int}/reviewer")]
        [ProducesResponseType(200,Type = typeof(ICollection<ReviewDTO>))]
        public ActionResult<ICollection<ReviewDTO>> GetReviewsByReviewer(int id)
        {
            if (_reviewer.ReviewerExists(id))
                return NotFound(id);
            var reviews = _mapper.Map<ICollection<ReviewDTO>>(_reviewer.GetReviewsByReviewer(id));
            return Ok(reviews);
        }
    }
}
