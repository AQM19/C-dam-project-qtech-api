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
    public class EstadisticaController : Controller
    {
        private readonly IEstadisticaService _estadisticaService;
        private readonly IMapper _mapper;

        public EstadisticaController(IEstadisticaService estadisticaService, IMapper mapper)
        {
            _estadisticaService = estadisticaService;
            _mapper = mapper;
        }

        [HttpGet("estadisticas")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<EstadisticaDTO> userDTOs = await _estadisticaService.GetAll();
            ICollection<EstadisticaVM> userVMs = _mapper.Map<ICollection<EstadisticaVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("estadisticas/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            EstadisticaDTO EstadisticaDTO = await _estadisticaService.GetById(id);
            EstadisticaVM EstadisticaVM = _mapper.Map<EstadisticaVM>(EstadisticaDTO);

            return Ok(EstadisticaVM);
        }

        [HttpPost("estadisticas")]
        public async Task<IActionResult> Create(EstadisticaVM EstadisticaVM)
        {
            EstadisticaDTO EstadisticaDTO = _mapper.Map<EstadisticaDTO>(EstadisticaVM);

            _estadisticaService.Create(EstadisticaDTO);
            return Ok();
        }

        [HttpPut("estadisticas/{id}")]
        public async Task<IActionResult> Update(int id, EstadisticaVM EstadisticaVM)
        {
            EstadisticaDTO EstadisticaDTO = _mapper.Map<EstadisticaDTO>(EstadisticaVM);

            _estadisticaService.Update(id, EstadisticaDTO);
            return Ok();
        }

        [HttpDelete("estadisticas/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _estadisticaService.Delete(id);
            return Ok();
        }
    }
}
