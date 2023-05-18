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
            try
            {
                Lectura Dato = _mapper.Map<Lectura>(DatoDTO);

                _context.Lecturas.Add(Dato);
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
                Lectura Dato = _context.Lecturas.FirstOrDefault(a => a.Id == id);

                _context.Remove(Dato);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<LecturaDTO>> GetAll()
        {
            try
            {
                List<Lectura> Datos = _context.Lecturas.ToList();
                ICollection<LecturaDTO> alertaDTOs = _mapper.Map<ICollection<LecturaDTO>>(Datos);

                return alertaDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LecturaDTO> GetById(int id)
        {
            try
            {
                Lectura Dato = _context.Lecturas.FirstOrDefault(a => a.Id == id);
                LecturaDTO DatoDTO = _mapper.Map<LecturaDTO>(Dato);

                return DatoDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LecturaDTO> GetLecturaActual(long id)
        {
            try
            {
                Lectura data = _context.Lecturas.OrderByDescending(x => x.Fecha).FirstOrDefault(x => x.Idterrario == id);
                return _mapper.Map<LecturaDTO>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Update(int id, LecturaDTO DatoDTO)
        {
            try
            {
                Lectura Dato = _context.Lecturas.FirstOrDefault(a => a.Id == id);

                Dato.Id = DatoDTO.Id;
                Dato.Idterrario = DatoDTO.Idterrario;
                Dato.Fecha = DatoDTO.Fecha;
                Dato.Temperatura = DatoDTO.Temperatura;
                Dato.Humedad = DatoDTO.Humedad;
                Dato.Luz = DatoDTO.Luz;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
