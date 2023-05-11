using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class TerrarioService : ITerrarioService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public TerrarioService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region CRUD
        public async void Create(TerrarioDTO TerrarioDTO)
        {
            try
            {
                if (TerrarioDTO == null) return;

                Terrario Terrario = _mapper.Map<Terrario>(TerrarioDTO);

                _context.Terrarios.Add(Terrario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<TerrarioDTO>> GetAll()
        {
            try
            {

                List<Terrario> Terrarios = _context.Terrarios.Where(a => a.Usuario.Borrado == 0).ToList();
                ICollection<TerrarioDTO> alertaDTOs = _mapper.Map<ICollection<TerrarioDTO>>(Terrarios);

                return alertaDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TerrarioDTO> GetById(long id)
        {
            try
            {
                Terrario Terrario = _context.Terrarios.FirstOrDefault(a => a.Id == id && a.Usuario.Borrado == 0);
                TerrarioDTO TerrarioDTO = _mapper.Map<TerrarioDTO>(Terrario);

                return TerrarioDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Update(long id, TerrarioDTO TerrarioDTO)
        {
            try
            {
                Terrario Terrario = _context.Terrarios.FirstOrDefault(a => a.Id == id);

                Terrario.Id = TerrarioDTO.Id;
                Terrario.Idusuario = TerrarioDTO.Idusuario;
                Terrario.Nombre = TerrarioDTO.Nombre;
                Terrario.Privado = TerrarioDTO.Privado;
                Terrario.Contrasena = TerrarioDTO.Contrasena;
                Terrario.Hibernacion = TerrarioDTO.Hibernacion;
                Terrario.Sustrato = TerrarioDTO.Sustrato;
                Terrario.Descripcion = TerrarioDTO.Descripcion;
                Terrario.Tamano = TerrarioDTO.Tamano;
                Terrario.Ecosistema = TerrarioDTO.Ecosistema;
                Terrario.FechaCreacion = TerrarioDTO.FechaCreacion;
                Terrario.FechaUltimaModificacion = TerrarioDTO.FechaUltimaModificacion;
                Terrario.Foto = TerrarioDTO.Foto;
                Terrario.TemperaturaMaxima = TerrarioDTO.TemperaturaMaxima;
                Terrario.TemperaturaMinima = TerrarioDTO.TemperaturaMinima;
                Terrario.TemperaturaMaximaHiber = TerrarioDTO.TemperaturaMaximaHiber;
                Terrario.TemperaturaMinimaHiber = TerrarioDTO.TemperaturaMinimaHiber;
                Terrario.HumedadMaxima = TerrarioDTO.HumedadMaxima;
                Terrario.HumedadMinima = TerrarioDTO.HumedadMinima;
                Terrario.HorasLuz = TerrarioDTO.HorasLuz;
                Terrario.HorasLuzHiber = TerrarioDTO.HorasLuzHiber;

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
                Terrario Terrario = _context.Terrarios.FirstOrDefault(a => a.Id == id);

                _context.Remove(Terrario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Custom
        public async Task<ICollection<TerrarioDTO>> GetTerrariosSocial(long id)
        {
            try
            {
                ICollection<Terrario> terrarios = _context.Terrarios.Where(x => x.Idusuario != id && x.Usuario.Borrado == 0).ToList();
                ICollection<TerrarioDTO> terrarioDTOs = _mapper.Map<ICollection<TerrarioDTO>>(terrarios);
                return terrarioDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<float> GetPuntuacionTerrario(long id)
        {
            try
            {
                float? puntuacion = await _context.Terrarios.Where(x => x.Id == id)
                                              .Select(x => x.Visitas.Any() ? x.Visitas.Average(y => y.Puntuacion) : (float?)null)
                                              .FirstOrDefaultAsync();
                return puntuacion ?? 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
