using Microsoft.AspNetCore.Mvc;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Controllers
{
    [ApiController]
    [Route("api/pokeman")]
    public class PokemanController : ControllerBase
    {
        private readonly IPokeman _pokeman;
        public PokemanController(IPokeman pokeman)
        {
            _pokeman = pokeman;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetPokemans()
        {
            var pokemans = _pokeman.GetPokemans();
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
            var pokeman = _pokeman.GetPokeman(id);
            return Ok(pokeman);
        }
    }
}
