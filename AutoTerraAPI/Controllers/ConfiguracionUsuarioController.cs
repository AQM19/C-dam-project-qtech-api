using AutoMapper;
using AutoTerraApi.VMs;
using AutoTerraAPI.VMs;
using Business.DTOs;
using Business.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;


namespace AutoTerraAPI.Controllers
{
    [ApiController]
    [Route("autoterra/v1")]
    public class ConfiguracionUsuarioController : Controller
    {
        private readonly IConfiguracionUsuarioService _configuracionUsuarioService;
        private readonly IMapper _mapper;

        public ConfiguracionUsuarioController(IConfiguracionUsuarioService configuracionUsuarioService, IMapper mapper)
        {
            _configuracionUsuarioService = configuracionUsuarioService;
            _mapper = mapper;
        }

        [HttpGet("configuracion-usuario")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<ConfiguracionUsuarioDTO> userDTOs = await _configuracionUsuarioService.GetAll();
            ICollection<ConfiguracionUsuarioVM> userVMs = _mapper.Map<ICollection<ConfiguracionUsuarioVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("configuracion-usuario/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ConfiguracionUsuarioDTO ConfiguracionUsuarioDTO = await _configuracionUsuarioService.GetById(id);
            ConfiguracionUsuarioVM ConfiguracionUsuarioVM = _mapper.Map<ConfiguracionUsuarioVM>(ConfiguracionUsuarioDTO);

            return Ok(ConfiguracionUsuarioVM);
        }

        [HttpPost("configuracion-usuario")]
        public async Task<IActionResult> Create(ConfiguracionUsuarioVM ConfiguracionUsuarioVM)
        {
            ConfiguracionUsuarioDTO ConfiguracionUsuarioDTO = _mapper.Map<ConfiguracionUsuarioDTO>(ConfiguracionUsuarioVM);

            _configuracionUsuarioService.Create(ConfiguracionUsuarioDTO);
            return Ok();
        }

        [HttpPut("configuracion-usuario/{id}")]
        public async Task<IActionResult> Update(int id, ConfiguracionUsuarioVM ConfiguracionUsuarioVM)
        {
            ConfiguracionUsuarioDTO ConfiguracionUsuarioDTO = _mapper.Map<ConfiguracionUsuarioDTO>(ConfiguracionUsuarioVM);

            _configuracionUsuarioService.Update(id, ConfiguracionUsuarioDTO);
            return Ok();
        }

        [HttpDelete("configuracion-usuario/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _configuracionUsuarioService.Delete(id);
            return Ok();
        }
    }
}
