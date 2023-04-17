using Business.DTOs;

namespace Business.Interfaces
{
    public interface IDatoService
    {
        Task<ICollection<DatoDTO>> GetAll();
        Task<DatoDTO> GetById(int id);
        void Create(DatoDTO datoDTO);
        void Update(int id, DatoDTO datoDTO);
        void Delete(int id);
    }
}
