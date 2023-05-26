using Business.DTOs;

namespace Business.Interfaces
{
    public interface ITerrarioService
    {
        Task<ICollection<TerrarioDTO>> GetAll();
        Task<TerrarioDTO> GetById(long id);
        void Create(TerrarioDTO terrarioDTO);
        void Update(long id, TerrarioDTO terrarioDTO);
        void Delete(long id);

        Task<ICollection<TerrarioDTO>> GetTerrariosSocial(long id);
        Task<ICollection<TerrarioDTO>> GetTerrariosDeUsusario(long id);
    }
}
