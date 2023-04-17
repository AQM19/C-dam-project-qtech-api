using Business.DTOs;

namespace Business.Interfaces
{
    public interface IUsuarioLogroService
    {
        Task<ICollection<UsuarioLogroDTO>> GetAll();
        Task<UsuarioLogroDTO> GetById(int id);
        void Create(UsuarioLogroDTO usuarioLogroDTO);
        void Update(int id, UsuarioLogroDTO usuarioLogroDTO);
        void Delete(int id);
    }
}
