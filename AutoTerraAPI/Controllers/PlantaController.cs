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
    public class PlantaController : Controller
    {
        private readonly IPlantaService _plantaService;
        private readonly IMapper _mapper;

        public PlantaController(IPlantaService plantaService, IMapper mapper)
        {
            _plantaService = plantaService;
            _mapper = mapper;
        }

        [HttpGet("plantas")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<PlantaDTO> userDTOs = await _plantaService.GetAll();
            ICollection<PlantaVM> userVMs = _mapper.Map<ICollection<PlantaVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("plantas/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            PlantaDTO PlantaDTO = await _plantaService.GetById(id);
            PlantaVM PlantaVM = _mapper.Map<PlantaVM>(PlantaDTO);

            return Ok(PlantaVM);
        }

        [HttpPost("plantas")]
        public async Task<IActionResult> Create(PlantaVM PlantaVM)
        {
            PlantaDTO PlantaDTO = _mapper.Map<PlantaDTO>(PlantaVM);

            _plantaService.Create(PlantaDTO);
            return Ok();
        }

        [HttpPut("plantas/{id}")]
        public async Task<IActionResult> Update(int id, PlantaVM PlantaVM)
        {
            PlantaDTO PlantaDTO = _mapper.Map<PlantaDTO>(PlantaVM);

            _plantaService.Update(id, PlantaDTO);
            return Ok();
        }

        [HttpDelete("plantas/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _plantaService.Delete(id);
            return Ok();
        }
    }
}
