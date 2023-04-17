using Business.DTOs;

namespace Business.Interfaces
{
    public interface INotificacionService
    {
        Task<ICollection<NotificacionDTO>> GetAll();
        Task<NotificacionDTO> GetById(int id);
        void Create(NotificacionDTO notificacionDTO);
        void Update(int id, NotificacionDTO notificacionDTO);
        void Delete(int id);
    }
}
