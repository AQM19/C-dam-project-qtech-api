using Business.DTOs;

namespace Business.Interfaces
{
    public interface IPlantaService
    {
        Task<ICollection<PlantaDTO>> GetAll();
        Task<PlantaDTO> GetById(int id);
        void Create(PlantaDTO plantaDTO);
        void Update(int id, PlantaDTO plantaDTO);
        void Delete(int id);
    }
}
