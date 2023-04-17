using Business.DTOs;

namespace Business.Interfaces
{
    public interface IHistoriaCambioService
    {
        Task<ICollection<HistorialCambioDTO>> GetAll();
        Task<HistorialCambioDTO> GetById(int id);
        void Create(HistorialCambioDTO historialCambioDTO);
        void Update(int id, HistorialCambioDTO historialCambioDTO);
        void Delete(int id);
    }
}
