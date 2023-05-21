using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemanWebApi.DTO;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Controllers
{
    [ApiController]
    [Route("api/pokeman")]
    public class PokemanController : ControllerBase
    {
        private readonly IPokeman _pokeman;
        private readonly IMapper _mapper;
        public PokemanController(IPokeman pokeman,IMapper mapper)
        {
            _pokeman = pokeman;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetPokemans()
        {
            var pokemans = _mapper.Map<List<PokemanDTO>>(_pokeman.GetPokemans());
            // pokemans = _pokeman.GetPokemans();
            return Ok(pokemans);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        public IActionResult GetPokeman(int id)
        {
            if (_pokeman.PokemanExists(id))
            {
                return NotFound();
            }
            var pokeman = _mapper.Map<PokemanDTO>(_pokeman.GetPokeman(id));
            //var pokeman = _pokeman.GetPokeman(id);
            return Ok(pokeman);
        }
    }
}
