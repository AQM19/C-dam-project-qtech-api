using Business.DTOs;

namespace Business.Interfaces
{
    public interface IEstadisticaService
    {
        Task<ICollection<EstadisticaDTO>> GetAll();
        Task<EstadisticaDTO> GetById(int id);
        void Create(EstadisticaDTO estadisticaDTO);
        void Update(int id, EstadisticaDTO estadisticaDTO);
        void Delete(int id);
    }
}
