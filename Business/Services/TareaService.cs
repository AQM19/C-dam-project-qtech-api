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
    public class TareaService : ITareaService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public TareaService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(TareaDTO TareaDTO)
        {
            try
            {
                Tarea Tarea = _mapper.Map<Tarea>(TareaDTO);

                _context.Tareas.Add(Tarea);
                _context.SaveChangesAsync();

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
                Tarea Tarea = _context.Tareas.FirstOrDefault(a => a.Id == id);

                _context.Remove(Tarea);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<TareaDTO>> GetAll()
        {
            try
            {
                List<Tarea> Tareas = _context.Tareas.ToList();
                ICollection<TareaDTO> alertaDTOs = _mapper.Map<ICollection<TareaDTO>>(Tareas);

                return alertaDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<TareaDTO>> GetAllByTerra(long id)
        {
            try
            {
                List<Tarea> tareas = _context.Tareas.Where(x => x.Idterrario == id).ToList();
                ICollection<TareaDTO> tareaDTOs = _mapper.Map<ICollection<TareaDTO>>(tareas);

                return tareaDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TareaDTO> GetById(int id)
        {
            try
            {
                Tarea Tarea = _context.Tareas.FirstOrDefault(a => a.Id == id);
                TareaDTO TareaDTO = _mapper.Map<TareaDTO>(Tarea);

                return TareaDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Update(int id, TareaDTO TareaDTO)
        {
            try
            {
                Tarea Tarea = _context.Tareas.FirstOrDefault(a => a.Id == id);

                Tarea.Id = TareaDTO.Id;
                Tarea.Idterrario = TareaDTO.Idterrario;
                Tarea.FechaCreacion = TareaDTO.FechaCreacion;
                Tarea.FechaResolucion = TareaDTO.FechaResolucion;
                Tarea.Titulo = TareaDTO.Titulo;
                Tarea.Descripcion = TareaDTO.Descripcion;
                Tarea.Estado = TareaDTO.Estado;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
