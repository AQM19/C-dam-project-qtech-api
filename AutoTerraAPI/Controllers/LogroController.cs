using AutoMapper;
using AutoTerraApi.VMs;
using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AutoTerraAPI.Controllers
{
    [ApiController]
    [Route("autoterra/v1")]
    public class LogroController : Controller
    {
        private readonly ILogroService _logroService;
        private readonly IMapper _mapper;

        public LogroController(ILogroService logroService, IMapper mapper)
        {
            _logroService = logroService;
            _mapper = mapper;
        }

        [HttpGet("logros")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<LogroDTO> userDTOs = await _logroService.GetAll();
            ICollection<LogroVM> userVMs = _mapper.Map<ICollection<LogroVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("logros/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            LogroDTO LogroDTO = await _logroService.GetById(id);
            LogroVM LogroVM = _mapper.Map<LogroVM>(LogroDTO);

            return Ok(LogroVM);
        }

        [HttpGet("logros-usuario/{id}")]
        public async Task<IActionResult> GetLogrosUsuario(long id)
        {
            ICollection<LogroDTO> logroDTOs = await _logroService.GetLogrosUsuario(id);
            ICollection<LogroVM> logroVMs = _mapper.Map<ICollection<LogroVM>>(logroDTOs);
            return Ok(logroVMs);
        }

        [HttpPost("logros")]
        public async Task<IActionResult> Create(LogroVM LogroVM)
        {
            LogroDTO LogroDTO = _mapper.Map<LogroDTO>(LogroVM);

            _logroService.Create(LogroDTO);
            return Ok();
        }

        [HttpPut("logros/{id}")]
        public async Task<IActionResult> Update(int id, LogroVM LogroVM)
        {
            LogroDTO LogroDTO = _mapper.Map<LogroDTO>(LogroVM);

            _logroService.Update(id, LogroDTO);
            return Ok();
        }

        [HttpDelete("logros/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logroService.Delete(id);
            return Ok();
        }
    }
}
