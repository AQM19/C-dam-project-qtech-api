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
    public class UsuarioUsuarioController : Controller
    {
        private readonly IUsuarioUsuarioService _usuarioUsuarioService;
        private readonly IMapper _mapper;

        public UsuarioUsuarioController(IUsuarioUsuarioService usuarioUsuarioService, IMapper mapper)
        {
            _usuarioUsuarioService = usuarioUsuarioService;
            _mapper = mapper;
        }

        [HttpGet("usuarioUsuarios")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<UsuarioUsuarioDTO> userDTOs = await _usuarioUsuarioService.GetAll();
            ICollection<UsuarioUsuarioVM> userVMs = _mapper.Map<ICollection<UsuarioUsuarioVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("usuarioUsuarios/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            UsuarioUsuarioDTO UsuarioUsuarioDTO = await _usuarioUsuarioService.GetById(id);
            UsuarioUsuarioVM UsuarioUsuarioVM = _mapper.Map<UsuarioUsuarioVM>(UsuarioUsuarioDTO);

            return Ok(UsuarioUsuarioVM);
        }

        [HttpPost("usuarioUsuarios/follow")]
        public async Task<IActionResult> Create(UsuarioUsuarioVM UsuarioUsuarioVM)
        {
            UsuarioUsuarioDTO UsuarioUsuarioDTO = _mapper.Map<UsuarioUsuarioDTO>(UsuarioUsuarioVM);

            _usuarioUsuarioService.Create(UsuarioUsuarioDTO);
            return Ok();
        }

        [HttpPut("usuarioUsuarios/{id}")]
        public async Task<IActionResult> Update(int id, UsuarioUsuarioVM UsuarioUsuarioVM)
        {
            UsuarioUsuarioDTO UsuarioUsuarioDTO = _mapper.Map<UsuarioUsuarioDTO>(UsuarioUsuarioVM);

            _usuarioUsuarioService.Update(id, UsuarioUsuarioDTO);
            return Ok();
        }

        [HttpDelete("usuarioUsuarios/unfollow/usuario/{idUsuario}/contacto/{idContacto}")]
        public async Task<IActionResult> Delete(long idUsuario, long idContacto)
        {
            _usuarioUsuarioService.Delete(idUsuario, idContacto);
            return Ok();
        }
    }
}
