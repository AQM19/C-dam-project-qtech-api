using AutoMapper;
using AutoTerraApi.VMs;
using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;

namespace AutoTerraAPI.Controllers
{
    [ApiController]
    [Route("autoterra/v1")]
    public class ObservacionController : Controller
    {
        private readonly IObservacionService _observacionService;
        private readonly IMapper _mapper;

        public ObservacionController(IObservacionService observacionService, IMapper mapper)
        {
            _observacionService = observacionService;
            _mapper = mapper;
        }

        [HttpGet("observaciones")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<ObservacionDTO> userDTOs = await _observacionService.GetAll();
            ICollection<ObservacionVM> userVMs = _mapper.Map<ICollection<ObservacionVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("observaviones/terrario/{id}")]
        public async Task<IActionResult> GetAllByTerra(long id)
        {
            ICollection<ObservacionDTO> observacionDTO = await _observacionService.GetAllByTerra(id);
            ICollection<ObservacionVM> observacionVMs = _mapper.Map<ICollection<ObservacionVM>>(observacionDTO);

            return Ok(observacionVMs);
        }

        [HttpGet("observaciones/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ObservacionDTO ObservacionDTO = await _observacionService.GetById(id);
            ObservacionVM ObservacionVM = _mapper.Map<ObservacionVM>(ObservacionDTO);

            return Ok(ObservacionVM);
        }

        [HttpPost("observaciones")]
        public async Task<IActionResult> Create(ObservacionVM ObservacionVM)
        {
            ObservacionDTO ObservacionDTO = _mapper.Map<ObservacionDTO>(ObservacionVM);

            _observacionService.Create(ObservacionDTO);
            return Ok();
        }

        [HttpPut("observaciones/{id}")]
        public async Task<IActionResult> Update(int id, ObservacionVM ObservacionVM)
        {
            ObservacionDTO ObservacionDTO = _mapper.Map<ObservacionDTO>(ObservacionVM);

            _observacionService.Update(id, ObservacionDTO);
            return Ok();
        }

        [HttpDelete("observaciones/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _observacionService.Delete(id);
            return Ok();
        }
    }
}
