using Business.DTOs;

namespace Business.Interfaces
{
    public interface ILogroService
    {
        Task<ICollection<LogroDTO>> GetAll();
        Task<LogroDTO> GetById(int id);
        void Create(LogroDTO logroDTO);
        void Update(int id, LogroDTO logroDTO);
        void Delete(int id);
    }
}
