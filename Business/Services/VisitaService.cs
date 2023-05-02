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
        public async void Create(VisitaDTO VisitaDTO)
        {
            Visita Visita = _mapper.Map<Visita>(VisitaDTO);

            _context.Visitas.Add(Visita);
            _context.SaveChanges();
        }
        public async Task<ICollection<VisitaDTO>> GetAll()
        {
            List<Visita> Visitas = _context.Visitas.ToList();
            ICollection<VisitaDTO> alertaDTOs = _mapper.Map<ICollection<VisitaDTO>>(Visitas);

            return alertaDTOs;
        }
        public async Task<VisitaDTO> GetById(int id)
        {
            Visita Visita = _context.Visitas.FirstOrDefault(a => a.Id == id);
            VisitaDTO VisitaDTO = _mapper.Map<VisitaDTO>(Visita);

            return VisitaDTO;
        }
        public async void Update(int id, VisitaDTO VisitaDTO)
        {
            Visita Visita = _context.Visitas.FirstOrDefault(a => a.Id == id);

            Visita.Id = VisitaDTO.Id;
            Visita.Idusuario = VisitaDTO.Idusuario;
            Visita.Idterrario = VisitaDTO.Idterrario;
            Visita.Fecha = VisitaDTO.Fecha;
            Visita.Comentario = VisitaDTO.Comentario;
            Visita.Puntuacion = VisitaDTO.Puntuacion;

            _context.SaveChanges();
        }
        public async void Delete(int id)
        {
            Visita Visita = _context.Visitas.FirstOrDefault(a => a.Id == id);

            _context.Remove(Visita);
            _context.SaveChanges();
        }
        #endregion

        #region CUSTOM
        public async Task<ICollection<VisitaDTO>> GetVisitasTerrario(long id)
        {
            ICollection<Visita> visitas = _context.Visitas.Where(x => x.Idterrario == id).ToList();
            ICollection<VisitaDTO> visitaDTOs = _mapper.Map<ICollection<VisitaDTO>>(visitas);

            return visitaDTOs;
        }
        #endregion
    }
}
