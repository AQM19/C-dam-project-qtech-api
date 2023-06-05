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
    public class LecturaController : Controller
    {
        private readonly ILecturaService _datoService;
        private readonly IMapper _mapper;

        public LecturaController(ILecturaService datoService, IMapper mapper)
        {
            _datoService = datoService;
            _mapper = mapper;
        }

        [HttpGet("datos")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<LecturaDTO> userDTOs = await _datoService.GetAll();
            ICollection<LecturaVM> userVMs = _mapper.Map<ICollection<LecturaVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("lecturas/terrario/{id}")]
        public async Task<IActionResult> GetLecturaActual(long id)
        {
            LecturaDTO lecturaDTO = await _datoService.GetLecturaActual(id);
            LecturaVM lecturaVM = _mapper.Map<LecturaVM>(lecturaDTO);

            return Ok(lecturaVM);
        }

        [HttpGet("datos/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            LecturaDTO DatoDTO = await _datoService.GetById(id);
            LecturaVM DatoVM = _mapper.Map<LecturaVM>(DatoDTO);

            return Ok(DatoVM);
        }

        [HttpGet("lecturas/terrario/lista/{id}")]
        public async Task<IActionResult> GetListaLecturasTerrario(long id)
        {
            ICollection<LecturaDTO> lecturaDTOs = await _datoService.GetListaLecturasTerrario(id);
            ICollection<LecturaVM> lecturaVMs = _mapper.Map<ICollection<LecturaVM>>(lecturaDTOs);
            
            return Ok(lecturaVMs);
        }

        [HttpPost("datos")]
        public async Task<IActionResult> Create(LecturaVM DatoVM)
        {
            LecturaDTO DatoDTO = _mapper.Map<LecturaDTO>(DatoVM);

            _datoService.Create(DatoDTO);
            return Ok();
        }

        [HttpPut("datos/{id}")]
        public async Task<IActionResult> Update(int id, LecturaVM DatoVM)
        {
            LecturaDTO DatoDTO = _mapper.Map<LecturaDTO>(DatoVM);

            _datoService.Update(id, DatoDTO);
            return Ok();
        }

        [HttpDelete("datos/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _datoService.Delete(id);
            return Ok();
        }
    }
}
