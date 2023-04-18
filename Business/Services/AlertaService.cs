using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;

namespace Business.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public AlertaService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(AlertaDTO alertaDTO)
        {
            Alerta alerta = _mapper.Map<Alerta>(alertaDTO);

            _context.Alertas.Add(alerta);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Alerta alerta = _context.Alertas.FirstOrDefault(a => a.Id == id);

            _context.Remove(alerta);
            _context.SaveChanges();
        }

        public async Task<ICollection<AlertaDTO>> GetAll()
        {
            List<Alerta> alertas = _context.Alertas.ToList();
            ICollection<AlertaDTO> alertaDTOs = _mapper.Map<ICollection<AlertaDTO>>(alertas);

            return alertaDTOs;
        }

        public async Task<AlertaDTO> GetById(int id)
        {
            Alerta alerta = _context.Alertas.FirstOrDefault(a => a.Id == id);
            AlertaDTO alertaDTO = _mapper.Map<AlertaDTO>(alerta);

            return alertaDTO;
        }

        public async void Update(int id, AlertaDTO alertaDTO)
        {
            Alerta alerta = _context.Alertas.FirstOrDefault(a => a.Id == id);

            alerta.Id = alertaDTO.Id;
            alerta.Idusuario = alertaDTO.Idusuario;
            alerta.Idterrario = alertaDTO.Idterrario;
            alerta.Fecha = alertaDTO.Fecha;
            alerta.TipoAlerta = alertaDTO.TipoAlerta;
            alerta.Descripcion = alertaDTO.Descripcion;
            alerta.Estado = alertaDTO.Estado;
            alerta.FechaResolucion = alertaDTO.FechaResolucion;
            alerta.Gravedad = alertaDTO.Gravedad;

            _context.SaveChanges();
        }
    }
}
