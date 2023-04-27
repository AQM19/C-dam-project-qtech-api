using Business.DTOs;

namespace Business.Interfaces
{
    public interface IUsuarioLogroService
    {
        Task<ICollection<UsuarioLogroDTO>> GetAll();
        Task<ICollection<UsuarioLogroDTO>> GetById(long id);
        void Create(UsuarioLogroDTO usuarioLogroDTO);
        void Update(long id, UsuarioLogroDTO usuarioLogroDTO);
        void Delete(long id);
    }
}
