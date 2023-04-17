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
    public class PlantaService : IPlantaService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public PlantaService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(PlantaDTO PlantaDTO)
        {
            Planta Planta = _mapper.Map<Planta>(PlantaDTO);

            _context.Plantas.Add(Planta);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Planta Planta = _context.Plantas.FirstOrDefault(a => a.Id == id);

            _context.Remove(Planta);
            _context.SaveChanges();
        }

        public async Task<ICollection<PlantaDTO>> GetAll()
        {
            List<Planta> Plantas = _context.Plantas.ToList();
            ICollection<PlantaDTO> alertaDTOs = _mapper.Map<ICollection<PlantaDTO>>(Plantas);

            return alertaDTOs;
        }

        public async Task<PlantaDTO> GetById(int id)
        {
            Planta Planta = _context.Plantas.FirstOrDefault(a => a.Id == id);
            PlantaDTO PlantaDTO = _mapper.Map<PlantaDTO>(Planta);

            return PlantaDTO;
        }

        public async void Update(int id, PlantaDTO PlantaDTO)
        {
            Planta Planta = _context.Plantas.FirstOrDefault(a => a.Id == id);

            Planta.Id = PlantaDTO.Id;
            Planta.Idespecie = PlantaDTO.Idespecie;
            Planta.TipoPlanta = PlantaDTO.TipoPlanta;
            Planta.Altura = PlantaDTO.Altura;
            Planta.Ancho = PlantaDTO.Ancho;
            Planta.Floracion = PlantaDTO.Floracion;
            Planta.Fructificacion = PlantaDTO.Fructificacion;
            Planta.Propagacion = PlantaDTO.Propagacion;
            Planta.Suelo = PlantaDTO.Suelo;

            _context.SaveChanges();
        }
    }
}
