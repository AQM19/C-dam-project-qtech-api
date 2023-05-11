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
                ICollection<Especie> especiesPosibles = _context.Especies
                    .Where(x =>
                    //x.EspecieTerrarios.Any(y => !especies.Contains(y.Especie)) &&
                    x.TemperaturaMaxima <= especies.Min(y => y.TemperaturaMaxima) &&
                    x.TemperaturaMaxima >= especies.Min(y => y.TemperaturaMinima) &&
                    x.TemperaturaMinima >= especies.Max(y => y.TemperaturaMinima) &&
                    x.TemperaturaMinima <= especies.Max(y => y.TemperaturaMaxima) &&
                    x.HumedadMaxima <= especies.Min(y => y.HumedadMaxima) &&
                    x.HumedadMinima >= especies.Max(y => y.HumedadMinima) &&
                    x.HorasLuz <= especies.Min(y => y.HorasLuz) &&
                    x.TemperaturaHibMaxima <= especies.Min(y => y.TemperaturaHibMaxima) &&
                    x.TemperaturaHibMaxima >= especies.Min(y => y.TemperaturaHibMinima) &&
                    x.TemperaturaHibMinima >= especies.Max(y => y.TemperaturaHibMinima) &&
                    x.TemperaturaHibMinima <= especies.Max(y => y.TemperaturaHibMaxima) &&
                    x.HorasLuzHib <= especies.Min(y => y.HorasLuzHib)
                    ).ToList();
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
