using AutoMapper;
using AutoTerraApi.VMs;
using AutoTerraAPI.VMs;
using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AutoTerraAPI.Controllers
{
    [ApiController]
    [Route("autoterra/v1")]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalService animalService, IMapper mapper)
        {
            _animalService = animalService;
            _mapper = mapper;
        }

        [HttpGet("animales")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<AnimalDTO> animalDTOs = await _animalService.GetAll();
            ICollection<AnimalVM> animalVMs = _mapper.Map<ICollection<AnimalVM>>(animalDTOs);

            return Ok(animalVMs);
        }

        [HttpGet("animales/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AnimalDTO AnimalDTO = await _animalService.GetById(id);
            AnimalVM AnimalVM = _mapper.Map<AnimalVM>(AnimalDTO);

            return Ok(AnimalVM);
        }

        [HttpPost("animales")]
        public async Task<IActionResult> Create(AnimalVM AnimalVM)
        {
            AnimalDTO AnimalDTO = _mapper.Map<AnimalDTO>(AnimalVM);

            _animalService.Create(AnimalDTO);
            return Ok();
        }

        [HttpPut("animales/{id}")]
        public async Task<IActionResult> Update(int id, AnimalVM AnimalVM)
        {
            AnimalDTO AnimalDTO = _mapper.Map<AnimalDTO>(AnimalVM);

            _animalService.Update(id, AnimalDTO);
            return Ok();
        }

        [HttpDelete("animales/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _animalService.Delete(id);
            return Ok();
        }
    }
}
