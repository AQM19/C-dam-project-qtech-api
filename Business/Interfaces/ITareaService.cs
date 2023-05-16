using Business.DTOs;

namespace Business.Interfaces
{
    public interface ITareaService
    {
        Task<ICollection<TareaDTO>> GetAll();
        Task<TareaDTO> GetById(int id);
        void Create(TareaDTO tareaDTO);
        void Update(int id, TareaDTO tareaDTO);
        void Delete(int id);

        Task<ICollection<TareaDTO>> GetAllByTerra(long id); 
    }
}
