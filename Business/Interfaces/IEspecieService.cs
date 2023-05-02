using Business.DTOs;

namespace Business.Interfaces
{
    public interface IEspecieService
    {
        Task<ICollection<EspecieDTO>> GetAll();
        Task<EspecieDTO> GetById(int id);
        void Create(EspecieDTO especieDTO);
        void Update(int id, EspecieDTO especieDTO);
        void Delete(int id);

        #region Custom
        Task<ICollection<EspecieDTO>> GetEspeciesTerrario(long idTerrario);
        #endregion
    }
}
