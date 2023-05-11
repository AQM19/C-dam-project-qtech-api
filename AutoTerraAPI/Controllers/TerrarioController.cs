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
    public class TerrarioController : Controller
    {
        private readonly ITerrarioService _terrarioService;
        private readonly IMapper _mapper;

        public TerrarioController(ITerrarioService terrarioService, IMapper mapper)
        {
            _terrarioService = terrarioService;
            _mapper = mapper;
        }

        [HttpGet("terrarios")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<TerrarioDTO> userDTOs = await _terrarioService.GetAll();
            ICollection<TerrarioVM> userVMs = _mapper.Map<ICollection<TerrarioVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("terrarios/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TerrarioDTO TerrarioDTO = await _terrarioService.GetById(id);

            if (TerrarioDTO == null)
                return NotFound($"El terrario con el ID {id} no existe.");

            TerrarioVM TerrarioVM = _mapper.Map<TerrarioVM>(TerrarioDTO);

            return Ok(TerrarioVM);
        }

        [HttpGet("terrarios/{id}/puntuacion")]
        public async Task<IActionResult> GetPuntuacionTerrario(long id)
        {
            float result = await _terrarioService.GetPuntuacionTerrario(id);
            return Ok(result);
        }

        [HttpGet("terrarios-social/{id}")]
        public async Task<IActionResult> GetTerrariosSocial(long id)
        {
            ICollection<TerrarioDTO> terrarioDTOs = await _terrarioService.GetTerrariosSocial(id);
            ICollection<TerrarioVM> terrarioVMs = _mapper.Map<ICollection<TerrarioVM>>(terrarioDTOs); 
            return Ok(terrarioVMs);
        }

        [HttpPost("terrarios")]
        public async Task<IActionResult> Create(TerrarioVM TerrarioVM)
        {
            TerrarioDTO TerrarioDTO = _mapper.Map<TerrarioDTO>(TerrarioVM);

            _terrarioService.Create(TerrarioDTO);
            return Ok();
        }

        [HttpPut("terrarios/{id}")]
        public async Task<IActionResult> Update(int id, TerrarioVM TerrarioVM)
        {
            TerrarioDTO TerrarioDTO = _mapper.Map<TerrarioDTO>(TerrarioVM);

            _terrarioService.Update(id, TerrarioDTO);
            return Ok();
        }

        [HttpDelete("terrarios/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _terrarioService.Delete(id);
            return Ok();
        }
    }
}
