using Business.DTOs;

namespace Business.Interfaces
{
    public interface IUsuarioService
    {
        Task<ICollection<UsuarioDTO>> GetAll();
        Task<UsuarioDTO> GetById(long id);
        void Create(UsuarioDTO usuarioDTO);
        void Update(long id, UsuarioDTO usuarioDTO);
        void Delete(long id);

        // Custom
        Task<UsuarioDTO> GetByLogin(string param, string password);
        Task<ICollection<UsuarioDTO>> GetSocial(long id);
        Task<bool> CheckUser(string patam);
    }
}
