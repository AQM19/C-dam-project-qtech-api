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
            Especie Especie = _mapper.Map<Especie>(EspecieDTO);

            _context.Especies.Add(Especie);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Especie Especie = _context.Especies.FirstOrDefault(a => a.Id == id);

            _context.Remove(Especie);
            _context.SaveChanges();
        }

        public async Task<ICollection<EspecieDTO>> GetAll()
        {
            List<Especie> Especies = _context.Especies.ToList();
            ICollection<EspecieDTO> alertaDTOs = _mapper.Map<ICollection<EspecieDTO>>(Especies);

            return alertaDTOs;
        }

        public async Task<EspecieDTO> GetById(int id)
        {
            Especie Especie = _context.Especies.FirstOrDefault(a => a.Id == id);
            EspecieDTO EspecieDTO = _mapper.Map<EspecieDTO>(Especie);

            return EspecieDTO;
        }

        public async void Update(int id, EspecieDTO EspecieDTO)
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

            _context.SaveChanges();
        }
    }
}
