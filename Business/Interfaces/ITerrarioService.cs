using Business.DTOs;

namespace Business.Interfaces
{
    public interface ITerrarioService
    {
        Task<ICollection<TerrarioDTO>> GetAll();
        Task<TerrarioDTO> GetById(int id);
        void Create(TerrarioDTO terrarioDTO);
        void Update(int id, TerrarioDTO terrarioDTO);
        void Delete(int id);
    }
}
