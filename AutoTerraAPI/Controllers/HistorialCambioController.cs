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
    public class HistorialCambioController : Controller
    {
        private readonly IHistoriaCambioService _historialCambioService;
        private readonly IMapper _mapper;

        public HistorialCambioController(IHistoriaCambioService historialCambioService, IMapper mapper)
        {
            _historialCambioService = historialCambioService;
            _mapper = mapper;
        }

        [HttpGet("historial-cambios")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<HistorialCambioDTO> userDTOs = await _historialCambioService.GetAll();
            ICollection<HistorialCambioVM> userVMs = _mapper.Map<ICollection<HistorialCambioVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("historial-cambios/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            HistorialCambioDTO HistorialCambioDTO = await _historialCambioService.GetById(id);
            HistorialCambioVM HistorialCambioVM = _mapper.Map<HistorialCambioVM>(HistorialCambioDTO);

            return Ok(HistorialCambioVM);
        }

        [HttpPost("historial-cambios")]
        public async Task<IActionResult> Create(HistorialCambioVM HistorialCambioVM)
        {
            HistorialCambioDTO HistorialCambioDTO = _mapper.Map<HistorialCambioDTO>(HistorialCambioVM);

            _historialCambioService.Create(HistorialCambioDTO);
            return Ok();
        }

        [HttpPut("historial-cambios/{id}")]
        public async Task<IActionResult> Update(int id, HistorialCambioVM HistorialCambioVM)
        {
            HistorialCambioDTO HistorialCambioDTO = _mapper.Map<HistorialCambioDTO>(HistorialCambioVM);

            _historialCambioService.Update(id, HistorialCambioDTO);
            return Ok();
        }

        [HttpDelete("historial-cambios/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _historialCambioService.Delete(id);
            return Ok();
        }
    }
}
