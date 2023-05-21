using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemanWebApi.DTO;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Controllers
{
    [Route("api/catagories")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private readonly ICatagory _catagory;
        private readonly IMapper _mapper;
        public CatagoryController(ICatagory catagory,IMapper mapper)
        {
            _catagory = catagory;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCatagories()
        {
            // var catagories = _mapper.Map<List<CatagoryDTO>>(_catagory.GetCatagories());
            var catagories = _catagory.GetCatagories();
            return Ok(catagories);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCatagory(int id)
        {
            var catagory = _mapper.Map<CatagoryDTO> (_catagory.GetCatagory(id));
            return Ok(catagory);
        }

        [HttpGet("pokemons/{catagoryId:int}")]
        public IActionResult GetPokemansByCatagory(int id)
        {
            var pokemons = _mapper.Map<List<PokemanDTO>>(_catagory.GetPokemansByCatagory(id));
            return Ok(pokemons);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public ActionResult<bool> CreateCatagory(CatagoryDTO catagoryDTO)
        {
            
            if(_catagory.GetCatagory(catagoryDTO.Name) != null)
            {
                ModelState.AddModelError("err", "catagory object already exist !");
                return StatusCode(422,ModelState);
            }
             
            var created = _catagory.CreateCatagory(_mapper.Map<Catagory>(catagoryDTO));
            if (!created)
            {
                return StatusCode(500, "something went wrong");
            }
            return Ok(created);
        }

        [HttpPut("Update/{id:int}")]
        [ProducesResponseType(200)]
        public ActionResult Update(int id, UpdateCatagory catagoryDTO)
        {
           
            if(!_catagory.CatagoryExists(id)){
                return StatusCode(400,"No catagory exists with id " + id);
            }
            var catagoryMap = _mapper.Map<Catagory>(catagoryDTO);
            var created = _catagory.UpdateCatagory(catagoryMap);
            return Ok(created);
        }
    }
}
