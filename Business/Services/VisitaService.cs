using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;

namespace Business.Services
{
    public class VisitaService : IVisitaService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public VisitaService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        #region CRUD
        public async Task<VisitaDTO> Create(VisitaDTO VisitaDTO)
        {
            try
            {
                Visita Visita = _mapper.Map<Visita>(VisitaDTO);

                _context.Visitas.Add(Visita);
                await _context.SaveChangesAsync();
                return _mapper.Map<VisitaDTO>(Visita);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ICollection<VisitaDTO>> GetAll()
        {
            try
            {
                List<Visita> Visitas = _context.Visitas.ToList();
                ICollection<VisitaDTO> alertaDTOs = _mapper.Map<ICollection<VisitaDTO>>(Visitas);

                return alertaDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<VisitaDTO> GetById(long idTerrario, long idUsuario)
        {
            try
            {
                Visita Visita = _context.Visitas.FirstOrDefault(a => a.Idterrario == idTerrario && a.Idusuario == idUsuario);
                VisitaDTO VisitaDTO = _mapper.Map<VisitaDTO>(Visita);

                return VisitaDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Update(int id, VisitaDTO VisitaDTO)
        {
            try
            {
                Visita Visita = _context.Visitas.FirstOrDefault(a => a.Id == id);

                Visita.Id = VisitaDTO.Id;
                Visita.Idusuario = VisitaDTO.Idusuario;
                Visita.Idterrario = VisitaDTO.Idterrario;
                Visita.Fecha = VisitaDTO.Fecha;
                Visita.Comentario = VisitaDTO.Comentario;
                Visita.Puntuacion = VisitaDTO.Puntuacion;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Delete(int id)
        {
            try
            {
                Visita Visita = _context.Visitas.FirstOrDefault(a => a.Id == id);

                _context.Remove(Visita);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region CUSTOM
        public async Task<ICollection<VisitaDTO>> GetVisitasTerrario(long id)
        {
            try
            {
                ICollection<Visita> visitas = _context.Visitas.Where(x => x.Idterrario == id).ToList();
                ICollection<VisitaDTO> visitaDTOs = _mapper.Map<ICollection<VisitaDTO>>(visitas);

                return visitaDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
