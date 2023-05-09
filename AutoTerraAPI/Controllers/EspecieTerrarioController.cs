using AutoMapper;
using AutoTerraApi.VMs;
using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AutoTerraAPI.Controllers
{
    [ApiController]
    [Route("autoterra/v1")]
    public class EspecieTerrarioController : Controller
    {
        private readonly IEspecieTerrarioService _especieTerrario;
        private readonly IMapper _mapper;

        public EspecieTerrarioController(IEspecieTerrarioService especieTerrario, IMapper mapper)
        {
            _especieTerrario = especieTerrario;
            _mapper = mapper;
        }

        [HttpGet("especie-terrario")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<EspecieTerrarioDTO> userDTOs = await _especieTerrario.GetAll();
            ICollection<EspecieTerrarioVM> userVMs = _mapper.Map<ICollection<EspecieTerrarioVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("especie-terrario/{id}")]
        public async Task<IActionResult> GetById(int id, int id2)
        {
            EspecieTerrarioDTO EspecieTerrarioDTO = await _especieTerrario.GetById(id, id2);
            EspecieTerrarioVM EspecieTerrarioVM = _mapper.Map<EspecieTerrarioVM>(EspecieTerrarioDTO);

            return Ok(EspecieTerrarioVM);
        }

        [HttpPost("especie-terrario")]
        public async Task<IActionResult> Create(EspecieTerrarioVM EspecieTerrarioVM)
        {
            EspecieTerrarioDTO EspecieTerrarioDTO = _mapper.Map<EspecieTerrarioDTO>(EspecieTerrarioVM);

            _especieTerrario.Create(EspecieTerrarioDTO);
            return Ok();
        }

        [HttpPut("especie-terrario/{id}")]
        public async Task<IActionResult> Update(int id, int id2, EspecieTerrarioVM EspecieTerrarioVM)
        {
            EspecieTerrarioDTO EspecieTerrarioDTO = _mapper.Map<EspecieTerrarioDTO>(EspecieTerrarioVM);

            _especieTerrario.Update(id, id2, EspecieTerrarioDTO);
            return Ok();
        }

        [HttpPut("especie-terrario/list/{id}")]
        public async Task<IActionResult> UpdateOfTerrario(long id, [FromBody] List<EspecieTerrarioVM> list)
        {
            List<EspecieTerrarioDTO> EspecieTerrarioDTO = _mapper.Map<List<EspecieTerrarioDTO>>(list);
            await _especieTerrario.UpdateOfTerrario(id, EspecieTerrarioDTO);
            return Ok();
        }

        [HttpDelete("especie-terrario/{id}")]
        public async Task<IActionResult> Delete(int id, int id2)
        {
            _especieTerrario.Delete(id, id2);
            return Ok();
        }
    }
}
