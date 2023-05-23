using AutoMapper;
using AutoTerraApi.VMs;
using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AutoTerraAPI.Controllers
{
    [ApiController]
    [Route("autoterra/v1")]
    public class EspecieController : Controller
    {
        private readonly IEspecieService _especieService;
        private readonly IMapper _mapper;

        public EspecieController(IEspecieService especieService, IMapper mapper)
        {
            _especieService = especieService;
            _mapper = mapper;
        }

        [HttpGet("especies")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<EspecieDTO> userDTOs = await _especieService.GetAll();
            ICollection<EspecieVM> userVMs = _mapper.Map<ICollection<EspecieVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("especies/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            EspecieDTO EspecieDTO = await _especieService.GetById(id);
            EspecieVM EspecieVM = _mapper.Map<EspecieVM>(EspecieDTO);

            return Ok(EspecieVM);
        }

        [HttpGet("especies/q={id}")]
        public async Task<IActionResult> GetEspeciesTerrario(long id)
        {
            ICollection<EspecieDTO> especieDTOs = await _especieService.GetEspeciesTerrario(id);
            ICollection<EspecieVM> especieVMs = _mapper.Map<ICollection<EspecieVM>>(especieDTOs);
            return Ok(especieVMs);
        }

        [HttpPost("especies/posibles")]
        public async Task<IActionResult> GetEspeciesPosibles([FromBody] ICollection<EspecieVM> lista)
        {
            ICollection<EspecieDTO> especieDTOs = await _especieService.GetEspeciesPosibles(_mapper.Map<ICollection<EspecieDTO>>(lista));
            return Ok(especieDTOs);
        }

        [HttpPost("especies")]
        public async Task<IActionResult> Create(EspecieVM EspecieVM)
        {
            EspecieDTO EspecieDTO = _mapper.Map<EspecieDTO>(EspecieVM);
            _especieService.Create(EspecieDTO);
            return Ok();
        }

        [HttpPut("especies/{id}")]
        public async Task<IActionResult> Update(long id, EspecieVM EspecieVM)
        {
            EspecieDTO EspecieDTO = _mapper.Map<EspecieDTO>(EspecieVM);
            _especieService.Update(id, EspecieDTO);
            return Ok();
        }

        [HttpDelete("especies/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _especieService.Delete(id);
            return Ok();
        }
    }
}
