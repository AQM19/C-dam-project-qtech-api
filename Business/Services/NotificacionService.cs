using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class NotificacionService : INotificacionService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public NotificacionService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(NotificacionDTO NotificacionDTO)
        {
            Notificacion Notificacion = _mapper.Map<Notificacion>(NotificacionDTO);

            _context.Notificaciones.Add(Notificacion);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Notificacion Notificacion = _context.Notificaciones.FirstOrDefault(a => a.Id == id);

            _context.Remove(Notificacion);
            _context.SaveChanges();
        }

        public async Task<ICollection<NotificacionDTO>> GetAll()
        {
            List<Notificacion> Notificaciones = _context.Notificaciones.ToList();
            ICollection<NotificacionDTO> alertaDTOs = _mapper.Map<ICollection<NotificacionDTO>>(Notificaciones);

            return alertaDTOs;
        }

        public async Task<ICollection<NotificacionDTO>> GetAllByUserId(long userId)
        {
            ICollection<Notificacion> notificaciones = _context.Notificaciones.Where(x => x.Terrario.Idusuario == userId && x.Vista == 0).ToList();
            ICollection<NotificacionDTO> notificacionDTOs = _mapper.Map<ICollection<NotificacionDTO>>(notificaciones);
            
            return notificacionDTOs;
        }

        public async Task<NotificacionDTO> GetById(int id)
        {
            Notificacion Notificacion = _context.Notificaciones.FirstOrDefault(a => a.Id == id);
            NotificacionDTO NotificacionDTO = _mapper.Map<NotificacionDTO>(Notificacion);

            return NotificacionDTO;
        }

        public async void Update(int id, NotificacionDTO NotificacionDTO)
        {
            Notificacion Notificacion = _context.Notificaciones.FirstOrDefault(a => a.Id == id);

            Notificacion.Id = NotificacionDTO.Id;
            Notificacion.Idterrario = NotificacionDTO.Idterrario;
            Notificacion.Fecha = NotificacionDTO.Fecha;
            Notificacion.Texto = NotificacionDTO.Texto;
            Notificacion.Vista = NotificacionDTO.Vista;

            _context.SaveChanges();
        }
    }
}
