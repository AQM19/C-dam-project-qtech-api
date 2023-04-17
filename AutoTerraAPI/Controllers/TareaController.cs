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
    public class TareaController : Controller
    {
        private readonly ITareaService _tareaService;
        private readonly IMapper _mapper;

        public TareaController(ITareaService tareaService, IMapper mapper)
        {
            _tareaService = tareaService;
            _mapper = mapper;
        }

        [HttpGet("tareas")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<TareaDTO> userDTOs = await _tareaService.GetAll();
            ICollection<TareaVM> userVMs = _mapper.Map<ICollection<TareaVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("tareas/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TareaDTO TareaDTO = await _tareaService.GetById(id);
            TareaVM TareaVM = _mapper.Map<TareaVM>(TareaDTO);

            return Ok(TareaVM);
        }

        [HttpPost("tareas")]
        public async Task<IActionResult> Create(TareaVM TareaVM)
        {
            TareaDTO TareaDTO = _mapper.Map<TareaDTO>(TareaVM);

            _tareaService.Create(TareaDTO);
            return Ok();
        }

        [HttpPut("tareas/{id}")]
        public async Task<IActionResult> Update(int id, TareaVM TareaVM)
        {
            TareaDTO TareaDTO = _mapper.Map<TareaDTO>(TareaVM);

            _tareaService.Update(id, TareaDTO);
            return Ok();
        }

        [HttpDelete("tareas/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _tareaService.Delete(id);
            return Ok();
        }
    }
}
