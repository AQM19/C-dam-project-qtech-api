using Business.DTOs;

namespace Business.Interfaces
{
    public interface IVisitaService
    {
        Task<ICollection<VisitaDTO>> GetAll();
        Task<VisitaDTO> GetById(long idTerrario, long idUsuario);
        void Create(VisitaDTO visitaDTO);
        void Update(int id, VisitaDTO visitaDTO);
        void Delete(int id);

        Task<ICollection<VisitaDTO>> GetVisitasTerrario(long id);
    }
}
