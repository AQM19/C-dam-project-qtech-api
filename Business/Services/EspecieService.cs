using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EspecieService : IEspecieService
    {

        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public EspecieService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(EspecieDTO EspecieDTO)
        {

            try
            {
                Especie Especie = _mapper.Map<Especie>(EspecieDTO);

                _context.Especies.Add(Especie);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Delete(long id)
        {

            try
            {
                Especie Especie = _context.Especies.FirstOrDefault(a => a.Id == id);

                _context.Remove(Especie);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ICollection<EspecieDTO>> GetAll()
        {

            try
            {
                List<Especie> Especies = _context.Especies.ToList();
                ICollection<EspecieDTO> alertaDTOs = _mapper.Map<ICollection<EspecieDTO>>(Especies);

                return alertaDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<EspecieDTO> GetById(long id)
        {

            try
            {
                Especie Especie = _context.Especies.FirstOrDefault(a => a.Id == id);
                EspecieDTO EspecieDTO = _mapper.Map<EspecieDTO>(Especie);

                return EspecieDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Update(long id, EspecieDTO EspecieDTO)
        {

            try
            {
                Especie Especie = _context.Especies.FirstOrDefault(a => a.Id == id);

                Especie.Id = EspecieDTO.Id;
                Especie.Genero = EspecieDTO.Genero;
                Especie.Sp = EspecieDTO.Sp;
                Especie.NombreComun = EspecieDTO.NombreComun;
                Especie.Descripcion = EspecieDTO.Descripcion;
                Especie.Imagen = EspecieDTO.Imagen;
                Especie.Ecosistema = EspecieDTO.Ecosistema;
                Especie.DuracionVida = EspecieDTO.DuracionVida;
                Especie.Hiberna = EspecieDTO.Hiberna;
                Especie.TemperaturaMinima = EspecieDTO.TemperaturaMinima;
                Especie.TemperaturaMaxima = EspecieDTO.TemperaturaMaxima;
                Especie.TemperaturaHibMinima = EspecieDTO.TemperaturaHibMinima;
                Especie.TemperaturaHibMaxima = EspecieDTO.TemperaturaHibMaxima;
                Especie.HumedadMinima = EspecieDTO.HumedadMinima;
                Especie.HumedadMaxima = EspecieDTO.HumedadMaxima;
                Especie.HorasLuz = EspecieDTO.HorasLuz;
                Especie.HorasLuzHib = EspecieDTO.HorasLuzHib;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<ICollection<EspecieDTO>> GetEspeciesTerrario(long idTerrario)
        {

            try
            {
                ICollection<Especie> especies = _context.Especies.Where(x => x.EspecieTerrarios.Any(c => c.Idterrario == idTerrario)).ToList();
                ICollection<EspecieDTO> especieDTOs = _mapper.Map<ICollection<EspecieDTO>>(especies);

                return especieDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<EspecieDTO>> GetEspeciesPosibles(ICollection<EspecieDTO> especieDTOs)
        {
            try
            {
                ICollection<Especie> especies = _mapper.Map<ICollection<Especie>>(especieDTOs);

                float tempMax = especies.Min(y => y.TemperaturaMaxima);
                float tempMin = especies.Min(y => y.TemperaturaMinima);
                float? tempHibMax = especies.Min(y => y.TemperaturaHibMaxima);
                float? tempHibMin = especies.Min(y => y.TemperaturaHibMinima);
                float humMax = especies.Min(y => y.HumedadMaxima);
                float humMin = especies.Min(y => y.HumedadMinima);
                int luz = especies.Min(y => y.HorasLuz);
                int? luzHib = especies.Min(y => y.HorasLuzHib);

                ICollection<long> especiesIds = especies.Select(e => e.Id).ToList();

                ICollection<Especie> especiesPosibles = _context.Especies
                    .Where(x =>
                        !especiesIds.Contains(x.Id) &&
                        x.TemperaturaMaxima <= tempMax &&
                        x.TemperaturaMaxima >= tempMin &&
                        x.TemperaturaMinima <= tempMax &&
                        x.TemperaturaMinima >= tempMin &&
                        x.HumedadMaxima <= humMax &&
                        x.HumedadMinima >= humMin &&
                        x.HorasLuz <= luz &&
                        x.TemperaturaHibMaxima <= tempHibMax &&
                        x.TemperaturaHibMaxima >= tempHibMin &&
                        x.TemperaturaHibMinima <= tempHibMax &&
                        x.TemperaturaHibMinima >= tempHibMin &&
                        (!luzHib.HasValue || x.HorasLuzHib <= luzHib)
                    )
                    .ToList();

                ICollection<EspecieDTO> result = _mapper.Map<ICollection<EspecieDTO>>(especiesPosibles);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
