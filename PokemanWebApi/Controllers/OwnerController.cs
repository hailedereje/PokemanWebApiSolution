using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemanWebApi.DTO;
using PokemanWebApi.DTO.Owner;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwner _owner;
        private readonly IMapper _mapper;
        private readonly ICountry _country;

        public OwnerController(IOwner owner,ICountry country, IMapper mapper)
        {
            _mapper = mapper;
            _owner = owner;
            _country = country;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<OwnerDTO>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDTO>>(_owner.GetOwners());
            return Ok(owners);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(OwnerDTO))]
        public IActionResult GetOwner(int id)
        {
            if(!_owner.OnwerExists(id))
            {
                return NotFound();
            }

            var owner = _mapper.Map<OwnerDTO>(_owner.GetOwner(id));
            return Ok(owner);
        }

        [HttpGet("{ownerId:int}/pokemans")]
        [ProducesResponseType(200, Type = typeof(ICollection<PokemanDTO>))]
        public ActionResult<ICollection<PokemanDTO>> GetPokemansByOwner(int ownerId)
        {
            if (_owner.OnwerExists(ownerId))
            {
                return NotFound(ownerId);
            }
            var pokemans = _mapper.Map<List<PokemanDTO>>(_owner.GetPokemansByOwner(ownerId));
            return Ok(pokemans);
        }

        [HttpGet("{pokemanId:int}/owners")]
        [ProducesResponseType(200, Type = typeof(ICollection<OwnerDTO>))]
        public ActionResult<ICollection<OwnerDTO>> GetOwnersByPokeman(int pokemanId)
        {
            var owners = _mapper.Map<OwnerDTO>(_owner.GetOwnersByPokeman(pokemanId));
            return Ok(owners);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public  ActionResult<bool> CreateOwner(CreateOwnerDTO owner)
        {
            
            var ownerMap = _mapper.Map<Owner>(owner);
            var created =  _owner.CreateOwner(ownerMap);
            return Ok(created);
        }
    }
}
