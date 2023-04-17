using Business.DTOs;

namespace Business.Interfaces
{
    public interface IAlertaService
    {
        Task<ICollection<AlertaDTO>> GetAll();
        Task<AlertaDTO> GetById(int id);
        void Create(AlertaDTO alertaDTO);
        void Update(int id, AlertaDTO alertaDTO);
        void Delete(int id);
    }
}
