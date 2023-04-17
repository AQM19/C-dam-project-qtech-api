using Business.DTOs;

namespace Business.Interfaces
{
    public interface IObservacionService
    {
        Task<ICollection<ObservacionDTO>> GetAll();
        Task<ObservacionDTO> GetById(int id);
        void Create(ObservacionDTO observacionDTO);
        void Update(int id, ObservacionDTO observacionDTO);
        void Delete(int id);
    }
}
