using Business.DTOs;

namespace Business.Interfaces
{
    public interface IEspecieService
    {
        Task<ICollection<EspecieDTO>> GetAll();
        Task<EspecieDTO> GetById(long id);
        void Create(EspecieDTO especieDTO);
        void Update(long id, EspecieDTO especieDTO);
        void Delete(long id);

        #region Custom
        Task<ICollection<EspecieDTO>> GetEspeciesTerrario(long idTerrario);
        Task<ICollection<EspecieDTO>> GetEspeciesPosibles(ICollection<EspecieDTO> especieDTOs);
        #endregion
    }
}
