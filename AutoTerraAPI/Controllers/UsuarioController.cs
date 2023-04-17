using AutoMapper;
using AutoTerraApi.VMs;
using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AutoTerraAPI.Controllers
{
    [ApiController]
    [Route("autoterra/v1")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet("usuarios")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<UsuarioDTO> userDTOs = await _usuarioService.GetAll();
            ICollection<UsuarioVM> userVMs = _mapper.Map<ICollection<UsuarioVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("usuarios/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            UsuarioDTO UsuarioDTO = await _usuarioService.GetById(id);
            UsuarioVM UsuarioVM = _mapper.Map<UsuarioVM>(UsuarioDTO);

            return Ok(UsuarioVM);
        }

        [HttpPost("usuarios")]
        public async Task<IActionResult> Create(UsuarioVM UsuarioVM)
        {
            UsuarioDTO UsuarioDTO = _mapper.Map<UsuarioDTO>(UsuarioVM);

            _usuarioService.Create(UsuarioDTO);
            return Ok();
        }

        [HttpPut("usuarios/{id}")]
        public async Task<IActionResult> Update(int id, UsuarioVM UsuarioVM)
        {
            UsuarioDTO UsuarioDTO = _mapper.Map<UsuarioDTO>(UsuarioVM);

            _usuarioService.Update(id, UsuarioDTO);
            return Ok();
        }

        [HttpDelete("usuarios/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _usuarioService.Delete(id);
            return Ok();
        }
    }
}
