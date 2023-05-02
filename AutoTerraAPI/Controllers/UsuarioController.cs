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

        [HttpGet("usuarios/social/{id}")]
        public async Task<IActionResult> GetSocial(long id)
        {
            ICollection<UsuarioDTO> userDTOs = await _usuarioService.GetSocial(id);
            ICollection<UsuarioVM> userVMs = _mapper.Map<ICollection<UsuarioVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("usuarios/q={param}")]
        public async Task<IActionResult> SearchUser(string param)
        {
            ICollection<UsuarioDTO> usuarioDTOs = await _usuarioService.SearchUser(param);
            ICollection<UsuarioVM> usuarioVMs = _mapper.Map<ICollection<UsuarioVM>>(usuarioDTOs);
            return Ok(usuarioVMs);
        }

        [HttpGet("usuarios/c={param}")]
        public async Task<IActionResult> CheckUser(string param)
        {
            return Ok(await _usuarioService.CheckUser(param));
        }

        [HttpGet("usuarios/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            UsuarioDTO UsuarioDTO = await _usuarioService.GetById(id);
            UsuarioVM UsuarioVM = _mapper.Map<UsuarioVM>(UsuarioDTO);

            return Ok(UsuarioVM);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetByLogin([FromBody] Dictionary<string, string> credentials)
        {
            string param = credentials["param"];
            string password = credentials["password"];

            UsuarioDTO usuarioDTO = await _usuarioService.GetByLogin(param, password);
            UsuarioVM usuarioVM = _mapper.Map<UsuarioVM>(usuarioDTO);

            return Ok(usuarioVM);
        }


        [HttpPost("usuarios")]
        public async Task<IActionResult> Create([FromBody] UsuarioVM UsuarioVM)
        {
            UsuarioDTO UsuarioDTO = _mapper.Map<UsuarioDTO>(UsuarioVM);

            _usuarioService.Create(UsuarioDTO);
            return Ok();
        }

        [HttpPut("usuarios/{id}")]
        public async Task<IActionResult> Update(long id, UsuarioVM UsuarioVM)
        {
            UsuarioDTO UsuarioDTO = _mapper.Map<UsuarioDTO>(UsuarioVM);

            _usuarioService.Update(id, UsuarioDTO);
            return Ok();
        }

        [HttpDelete("usuarios/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _usuarioService.Delete(id);
            return Ok();
        }
    }
}
