using Business.DTOs;

namespace Business.Interfaces
{
    public interface IConfiguracionUsuarioService
    {
        Task<ICollection<ConfiguracionUsuarioDTO>> GetAll();
        Task<ConfiguracionUsuarioDTO> GetById(int id);
        void Create(ConfiguracionUsuarioDTO configuracionUsuarioDTO);
        void Update(int id, ConfiguracionUsuarioDTO configuracionUsuarioDTO);
        void Delete(int id);
    }
}
