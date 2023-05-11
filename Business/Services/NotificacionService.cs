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
            try
            {
                Notificacion Notificacion = _mapper.Map<Notificacion>(NotificacionDTO);

                _context.Notificaciones.Add(Notificacion);
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
                Notificacion Notificacion = _context.Notificaciones.FirstOrDefault(a => a.Id == id);

                _context.Remove(Notificacion);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<NotificacionDTO>> GetAll()
        {
            try
            {
                List<Notificacion> Notificaciones = _context.Notificaciones.ToList();
                ICollection<NotificacionDTO> alertaDTOs = _mapper.Map<ICollection<NotificacionDTO>>(Notificaciones);

                return alertaDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<NotificacionDTO>> GetAllByUserId(long userId)
        {
            try
            {
                ICollection<Notificacion> notificaciones = _context.Notificaciones.Where(x => x.Terrario.Idusuario == userId && x.Vista == 0).ToList();
                ICollection<NotificacionDTO> notificacionDTOs = _mapper.Map<ICollection<NotificacionDTO>>(notificaciones);

                return notificacionDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<NotificacionDTO> GetById(int id)
        {
            try
            {
                Notificacion Notificacion = _context.Notificaciones.FirstOrDefault(a => a.Id == id);
                NotificacionDTO NotificacionDTO = _mapper.Map<NotificacionDTO>(Notificacion);

                return NotificacionDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Update(int id, NotificacionDTO NotificacionDTO)
        {
            try
            {
                Notificacion Notificacion = _context.Notificaciones.FirstOrDefault(a => a.Id == id);

                Notificacion.Id = NotificacionDTO.Id;
                Notificacion.Idterrario = NotificacionDTO.Idterrario;
                Notificacion.Fecha = NotificacionDTO.Fecha;
                Notificacion.Texto = NotificacionDTO.Texto;
                Notificacion.Vista = NotificacionDTO.Vista;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
