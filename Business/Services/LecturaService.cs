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
    public class LecturaService : ILecturaService
    {

        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public LecturaService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(LecturaDTO DatoDTO)
        {
            Lectura Dato = _mapper.Map<Lectura>(DatoDTO);

            _context.Datos.Add(Dato);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Lectura Dato = _context.Datos.FirstOrDefault(a => a.Id == id);

            _context.Remove(Dato);
            _context.SaveChanges();
        }

        public async Task<ICollection<LecturaDTO>> GetAll()
        {
            List<Lectura> Datos = _context.Datos.ToList();
            ICollection<LecturaDTO> alertaDTOs = _mapper.Map<ICollection<LecturaDTO>>(Datos);

            return alertaDTOs;
        }

        public async Task<LecturaDTO> GetById(int id)
        {
            Lectura Dato = _context.Datos.FirstOrDefault(a => a.Id == id);
            LecturaDTO DatoDTO = _mapper.Map<LecturaDTO>(Dato);

            return DatoDTO;
        }

        public async void Update(int id, LecturaDTO DatoDTO)
        {
            Lectura Dato = _context.Datos.FirstOrDefault(a => a.Id == id);

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
