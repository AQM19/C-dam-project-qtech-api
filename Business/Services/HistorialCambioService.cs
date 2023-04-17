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
    public class HistorialCambioService : IHistoriaCambioService
    {

        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public HistorialCambioService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(HistorialCambioDTO HistorialCambioDTO)
        {
            HistorialCambio HistorialCambio = _mapper.Map<HistorialCambio>(HistorialCambioDTO);

            _context.HistorialCambios.Add(HistorialCambio);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            HistorialCambio HistorialCambio = _context.HistorialCambios.FirstOrDefault(a => a.Id == id);

            _context.Remove(HistorialCambio);
            _context.SaveChanges();
        }

        public async Task<ICollection<HistorialCambioDTO>> GetAll()
        {
            List<HistorialCambio> HistorialCambios = _context.HistorialCambios.ToList();
            ICollection<HistorialCambioDTO> alertaDTOs = _mapper.Map<ICollection<HistorialCambioDTO>>(HistorialCambios);

            return alertaDTOs;
        }

        public async Task<HistorialCambioDTO> GetById(int id)
        {
            HistorialCambio HistorialCambio = _context.HistorialCambios.FirstOrDefault(a => a.Id == id);
            HistorialCambioDTO HistorialCambioDTO = _mapper.Map<HistorialCambioDTO>(HistorialCambio);

            return HistorialCambioDTO;
        }

        public async void Update(int id, HistorialCambioDTO HistorialCambioDTO)
        {
            HistorialCambio HistorialCambio = _context.HistorialCambios.FirstOrDefault(a => a.Id == id);

            HistorialCambio.Id = HistorialCambioDTO.Id;
            HistorialCambio.Idusuario = HistorialCambioDTO.Idusuario;
            HistorialCambio.NombreTabla = HistorialCambioDTO.NombreTabla;
            HistorialCambio.Accion = HistorialCambioDTO.Accion;
            HistorialCambio.Detalles = HistorialCambioDTO.Detalles;
            HistorialCambio.Observaciones = HistorialCambioDTO.Observaciones;

            _context.SaveChanges();
        }
    }
}
