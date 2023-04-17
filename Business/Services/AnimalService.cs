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
    public class AnimalService : IAnimalService
    {

        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public AnimalService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(AnimalDTO animalDTO)
        {
            Animal Animal = _mapper.Map<Animal>(animalDTO);

            _context.Animales.Add(Animal);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Animal animal = _context.Animales.FirstOrDefault(a => a.Id == id);

            _context.Remove(animal);
            _context.SaveChanges();
        }

        public async Task<ICollection<AnimalDTO>> GetAll()
        {
            List<Animal> animales = _context.Animales.ToList();
            ICollection<AnimalDTO> alertaDTOs = _mapper.Map<ICollection<AnimalDTO>>(animales);

            return alertaDTOs;
        }

        public async Task<AnimalDTO> GetById(int id)
        {
            Animal animal = _context.Animales.FirstOrDefault(a => a.Id == id);
            AnimalDTO animalDTO = _mapper.Map<AnimalDTO>(animal);

            return animalDTO;
        }

        public async void Update(int id, AnimalDTO animalDTO)
        {
            Animal animal = _context.Animales.FirstOrDefault(a => a.Id == id);

            animal.Id = animalDTO.Id;
            animal.Idespecie = animalDTO.Idespecie;
            animal.Proveniencia = animalDTO.Proveniencia;
            animal.Reproduccion = animalDTO.Reproduccion;
            animal.Comportamiento = animalDTO.Comportamiento;
            animal.Alimentacion = animalDTO.Alimentacion;           

            _context.SaveChanges();
        }
    }
}
