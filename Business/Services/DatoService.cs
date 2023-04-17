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
    public class DatoService : IDatoService
    {

        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public DatoService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(DatoDTO DatoDTO)
        {
            Dato Dato = _mapper.Map<Dato>(DatoDTO);

            _context.Datos.Add(Dato);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Dato Dato = _context.Datos.FirstOrDefault(a => a.Id == id);

            _context.Remove(Dato);
            _context.SaveChanges();
        }

        public async Task<ICollection<DatoDTO>> GetAll()
        {
            List<Dato> Datos = _context.Datos.ToList();
            ICollection<DatoDTO> alertaDTOs = _mapper.Map<ICollection<DatoDTO>>(Datos);

            return alertaDTOs;
        }

        public async Task<DatoDTO> GetById(int id)
        {
            Dato Dato = _context.Datos.FirstOrDefault(a => a.Id == id);
            DatoDTO DatoDTO = _mapper.Map<DatoDTO>(Dato);

            return DatoDTO;
        }

        public async void Update(int id, DatoDTO DatoDTO)
        {
            Dato Dato = _context.Datos.FirstOrDefault(a => a.Id == id);

            Dato.Id = DatoDTO.Id;
            Dato.Idterrario = DatoDTO.Idterrario;
            Dato.Fecha = DatoDTO.Fecha;
            Dato.Temperatura = DatoDTO.Temperatura;
            Dato.Humedad = DatoDTO.Humedad;
            Dato.Luz = DatoDTO.Luz;

            _context.SaveChanges();
        }
    }
}
