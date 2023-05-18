using Business.DTOs;

namespace Business.Interfaces
{
    public interface ILecturaService
    {
        Task<ICollection<LecturaDTO>> GetAll();
        Task<LecturaDTO> GetById(int id);
        void Create(LecturaDTO datoDTO);
        void Update(int id, LecturaDTO datoDTO);
        void Delete(int id);

        Task<LecturaDTO> GetLecturaActual(long id);
    }
}
