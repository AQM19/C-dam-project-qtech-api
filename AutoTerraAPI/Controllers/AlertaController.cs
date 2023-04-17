using AutoMapper;
using AutoTerraAPI.VMs;
using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AutoTerraAPI.Controllers
{
    [ApiController]
    [Route("autoterra/v1")]
    public class AlertaController : Controller
    {
        private readonly IAlertaService _alertaService;
        private readonly IMapper _mapper;

        public AlertaController(IAlertaService alertaService, IMapper mapper)
        {
            _alertaService = alertaService;
            _mapper = mapper;
        }

        [HttpGet("alertas")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<AlertaDTO> userDTOs = await _alertaService.GetAll();
            ICollection<AlertaVM> userVMs = _mapper.Map<ICollection<AlertaVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("alertas/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AlertaDTO AlertaDTO = await _alertaService.GetById(id);
            AlertaVM AlertaVM = _mapper.Map<AlertaVM>(AlertaDTO);

            return Ok(AlertaVM);
        }

        [HttpPost("alertas")]
        public async Task<IActionResult> Create(AlertaVM AlertaVM)
        {
            AlertaDTO AlertaDTO = _mapper.Map<AlertaDTO>(AlertaVM);

            _alertaService.Create(AlertaDTO);
            return Ok();
        }

        [HttpPut("alertas/{id}")]
        public async Task<IActionResult> Update(int id, AlertaVM AlertaVM)
        {
            AlertaDTO AlertaDTO = _mapper.Map<AlertaDTO>(AlertaVM);

            _alertaService.Update(id, AlertaDTO);
            return Ok();
        }

        [HttpDelete("alertas/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _alertaService.Delete(id);
            return Ok();
        }
    }
}
