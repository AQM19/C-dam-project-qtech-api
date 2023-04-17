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
    public class DatoController : Controller
    {
        private readonly IDatoService _datoService;
        private readonly IMapper _mapper;

        public DatoController(IDatoService datoService, IMapper mapper)
        {
            _datoService = datoService;
            _mapper = mapper;
        }

        [HttpGet("datos")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<DatoDTO> userDTOs = await _datoService.GetAll();
            ICollection<DatoVM> userVMs = _mapper.Map<ICollection<DatoVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("datos/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            DatoDTO DatoDTO = await _datoService.GetById(id);
            DatoVM DatoVM = _mapper.Map<DatoVM>(DatoDTO);

            return Ok(DatoVM);
        }

        [HttpPost("datos")]
        public async Task<IActionResult> Create(DatoVM DatoVM)
        {
            DatoDTO DatoDTO = _mapper.Map<DatoDTO>(DatoVM);

            _datoService.Create(DatoDTO);
            return Ok();
        }

        [HttpPut("datos/{id}")]
        public async Task<IActionResult> Update(int id, DatoVM DatoVM)
        {
            DatoDTO DatoDTO = _mapper.Map<DatoDTO>(DatoVM);

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
