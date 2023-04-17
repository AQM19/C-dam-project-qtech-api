using Business.DTOs;

namespace Business.Interfaces
{
    public interface IUsuarioService
    {
        Task<ICollection<UsuarioDTO>> GetAll();
        Task<UsuarioDTO> GetById(int id);
        void Create(UsuarioDTO usuarioDTO);
        void Update(int id, UsuarioDTO usuarioDTO);
        void Delete(int id);
    }
}
