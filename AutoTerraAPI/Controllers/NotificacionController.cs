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
    public class NotificacionController : Controller
    {
        private readonly INotificacionService _notificacionService;
        private readonly IMapper _mapper;

        public NotificacionController(INotificacionService notificacionService, IMapper mapper)
        {
            _notificacionService = notificacionService;
            _mapper = mapper;
        }

        [HttpGet("notificacions")]
        public async Task<IActionResult> GetAll()
        {
            ICollection<NotificacionDTO> userDTOs = await _notificacionService.GetAll();
            ICollection<NotificacionVM> userVMs = _mapper.Map<ICollection<NotificacionVM>>(userDTOs);

            return Ok(userVMs);
        }

        [HttpGet("notificacions/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            NotificacionDTO NotificacionDTO = await _notificacionService.GetById(id);
            NotificacionVM NotificacionVM = _mapper.Map<NotificacionVM>(NotificacionDTO);

            return Ok(NotificacionVM);
        }

        [HttpGet("notificaciones/usuario/{id}")]
        public async Task<IActionResult> GetAllByUserId(long id)
        {
            ICollection<NotificacionDTO> notificacionDTOs = await _notificacionService.GetAllByUserId(id);
            ICollection<NotificacionVM> notificacionVMs = _mapper.Map<ICollection<NotificacionVM>>(notificacionDTOs);

            return Ok(notificacionVMs);
        }

        [HttpGet("notificaciones/pendientes/{id}")]
        public async Task<IActionResult> GetPendingNotifications(long id)
        {
            bool pendingNotifications = await _notificacionService.PendingNotifications(id);
            return Ok(pendingNotifications);
        }

        [HttpPost("notificacions")]
        public async Task<IActionResult> Create(NotificacionVM NotificacionVM)
        {
            NotificacionDTO NotificacionDTO = _mapper.Map<NotificacionDTO>(NotificacionVM);

            _notificacionService.Create(NotificacionDTO);
            return Ok();
        }

        [HttpPut("notificacions/{id}")]
        public async Task<IActionResult> Update(int id, NotificacionVM NotificacionVM)
        {
            NotificacionDTO NotificacionDTO = _mapper.Map<NotificacionDTO>(NotificacionVM);

            _notificacionService.Update(id, NotificacionDTO);
            return Ok();
        }

        [HttpDelete("notificacions/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _notificacionService.Delete(id);
            return Ok();
        }
    }
}
