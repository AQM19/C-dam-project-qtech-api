using Business.DTOs;

namespace Business.Interfaces
{
    public interface IAnimalService
    {
        Task<ICollection<AnimalDTO>> GetAll();
        Task<AnimalDTO> GetById(int id);
        void Create(AnimalDTO animalDTO);
        void Update(int id, AnimalDTO animalDTO);
        void Delete(int id);
    }
}
