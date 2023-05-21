using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemanWebApi.DTO.Country;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController :ControllerBase
    {
        private readonly ICountry _country;
        private readonly IMapper _mapper;

        public CountryController(ICountry country,IMapper mapper)
        {
            _country = country;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(ICollection<CountryDTO>))]
        public IActionResult GetCountires()
        {
            var countries = _mapper.Map<ICollection<CountryDTO>>(_country.GetCountries());
            return Ok(countries);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200,Type=typeof(Country))]
        public IActionResult GetCountry(int id)
        {
            if (!_country.CountryExists(id))
            {
                return NotFound();
            }
            var country = _mapper.Map<CountryDTO>(_country.GetCountry(id));
            return Ok(country);
        }

        [HttpGet("owners/{id:int}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        public IActionResult GetCountryByOwner(int id)
        {
            var country = _mapper.Map<CountryDTO>(_country.GetCountryByOwner(id));
            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public ActionResult<bool> CreateCountry(CountryDTO country)
        {
            if(country == null)
            {
                return BadRequest(country);
            }
            if(_country.GetCountry(country.Name) != null)
            {
                ModelState.AddModelError("", "country already exists change the name");
                return StatusCode(400, ModelState);
            }
            var created = _country.CreateCountry(_mapper.Map<Country>(country));
            return Ok(created);
        }
    }
}
