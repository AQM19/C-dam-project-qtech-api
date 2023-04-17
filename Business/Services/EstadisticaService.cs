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
    public class EstadisticaService : IEstadisticaService
    {

        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public EstadisticaService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(EstadisticaDTO EstadisticaDTO)
        {
            Estadistica Estadistica = _mapper.Map<Estadistica>(EstadisticaDTO);

            _context.Estadisticas.Add(Estadistica);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Estadistica Estadistica = _context.Estadisticas.FirstOrDefault(a => a.Id == id);

            _context.Remove(Estadistica);
            _context.SaveChanges();
        }

        public async Task<ICollection<EstadisticaDTO>> GetAll()
        {
            List<Estadistica> Estadisticas = _context.Estadisticas.ToList();
            ICollection<EstadisticaDTO> alertaDTOs = _mapper.Map<ICollection<EstadisticaDTO>>(Estadisticas);

            return alertaDTOs;
        }

        public async Task<EstadisticaDTO> GetById(int id)
        {
            Estadistica Estadistica = _context.Estadisticas.FirstOrDefault(a => a.Id == id);
            EstadisticaDTO EstadisticaDTO = _mapper.Map<EstadisticaDTO>(Estadistica);

            return EstadisticaDTO;
        }

        public async void Update(int id, EstadisticaDTO EstadisticaDTO)
        {
            Estadistica Estadistica = _context.Estadisticas.FirstOrDefault(a => a.Id == id);

            Estadistica.Id = EstadisticaDTO.Id;
            Estadistica.Idusuario = EstadisticaDTO.Idusuario;
            Estadistica.NumeroTerrarios = EstadisticaDTO.NumeroTerrarios;
            Estadistica.PuntuacionMediaTerrarios = EstadisticaDTO.PuntuacionMediaTerrarios;
            Estadistica.NumeroIniciosSesion = EstadisticaDTO.NumeroIniciosSesion;
            Estadistica.NumeroEspecies = EstadisticaDTO.NumeroEspecies;
            Estadistica.NumeroAnimales = EstadisticaDTO.NumeroAnimales;
            Estadistica.NumeroPlantas = EstadisticaDTO.NumeroPlantas;
            Estadistica.NumeroAmigos = EstadisticaDTO.NumeroAmigos;
            Estadistica.NumeroLogros = EstadisticaDTO.NumeroLogros;

            _context.SaveChanges();
        }
    }
}
