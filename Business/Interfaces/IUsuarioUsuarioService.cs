using Business.DTOs;

namespace Business.Interfaces
{
    public interface IUsuarioUsuarioService
    {
        Task<ICollection<UsuarioUsuarioDTO>> GetAll();
        Task<UsuarioUsuarioDTO> GetById(int id);
        void Create(UsuarioUsuarioDTO usuarioUsuarioDTO);
        void Update(int id, UsuarioUsuarioDTO usuarioUsuarioDTO);
        void Delete(long idUsuario, long idContacto);
        Task<bool> ComprobarSeguimiento(long idUsuario, long idContacto);
    }
}
