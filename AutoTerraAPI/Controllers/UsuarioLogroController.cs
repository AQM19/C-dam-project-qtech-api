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
    public class UsuarioLogroController : Controller
    {
        private readonly IUsuarioLogroService _usuarioLogroService;
        private readonly IMapper _mapper;

        public UsuarioLogroController(IUsuarioLogroService usuarioLogroService, IMapper mapper)
        {
            _usuarioLogroService = usuarioLogroService;
            _mapper = mapper;
        }

        [HttpGet("usuarioLogros")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<UsuarioLogroDTO> userDTOs = await _usuarioLogroService.GetAll();
            ICollection<UsuarioLogroVM> userVMs = _mapper.Map<ICollection<UsuarioLogroVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("usuarioLogros/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            ICollection<UsuarioLogroDTO> UsuarioLogroDTO = await _usuarioLogroService.GetById(id);
            ICollection<UsuarioLogroVM> UsuarioLogroVM = _mapper.Map<ICollection<UsuarioLogroVM>>(UsuarioLogroDTO);

            return Ok(UsuarioLogroVM);
        }

        [HttpPost("usuarioLogros")]
        public async Task<IActionResult> Create(UsuarioLogroVM UsuarioLogroVM)
        {
            UsuarioLogroDTO UsuarioLogroDTO = _mapper.Map<UsuarioLogroDTO>(UsuarioLogroVM);

            _usuarioLogroService.Create(UsuarioLogroDTO);
            return Ok();
        }

        [HttpPut("usuarioLogros/{id}")]
        public async Task<IActionResult> Update(long id, UsuarioLogroVM UsuarioLogroVM)
        {
            UsuarioLogroDTO UsuarioLogroDTO = _mapper.Map<UsuarioLogroDTO>(UsuarioLogroVM);

            _usuarioLogroService.Update(id, UsuarioLogroDTO);
            return Ok();
        }

        [HttpDelete("usuarioLogros/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _usuarioLogroService.Delete(id);
            return Ok();
        }
    }
}
