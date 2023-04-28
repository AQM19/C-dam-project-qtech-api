using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;

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
            Terrario Terrario = _mapper.Map<Terrario>(TerrarioDTO);

            _context.Terrarios.Add(Terrario);
            _context.SaveChanges();
        }

        public async Task<ICollection<TerrarioDTO>> GetAll()
        {
            List<Terrario> Terrarios = _context.Terrarios.Where(a => a.Usuario.Borrado == 0).ToList();
            ICollection<TerrarioDTO> alertaDTOs = _mapper.Map<ICollection<TerrarioDTO>>(Terrarios);

            return alertaDTOs;
        }

        public async Task<TerrarioDTO> GetById(long id)
        {
            Terrario Terrario = _context.Terrarios.FirstOrDefault(a => a.Id == id && a.Usuario.Borrado == 0);
            TerrarioDTO TerrarioDTO = _mapper.Map<TerrarioDTO>(Terrario);

            return TerrarioDTO;
        }

        public async void Update(long id, TerrarioDTO TerrarioDTO)
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
            Terrario.PuntuacionMedia = TerrarioDTO.PuntuacionMedia;
            Terrario.TemperaturaMaxima = TerrarioDTO.TemperaturaMaxima;
            Terrario.TemperaturaMedia = TerrarioDTO.TemperaturaMedia;
            Terrario.TemperaturaMinima = TerrarioDTO.TemperaturaMinima;
            Terrario.TemperaturaMaximaHiber = TerrarioDTO.TemperaturaMaximaHiber;
            Terrario.TemperaturaMediaHiber = TerrarioDTO.TemperaturaMediaHiber;
            Terrario.TemperaturaMinimaHiber = TerrarioDTO.TemperaturaMinimaHiber;
            Terrario.HumedadMaxima = TerrarioDTO.HumedadMaxima;
            Terrario.HumedadMedia = TerrarioDTO.HumedadMedia;
            Terrario.HumedadMinima = TerrarioDTO.HumedadMinima;
            Terrario.HorasLuz = TerrarioDTO.HorasLuz;
            Terrario.HorasLuzHiber = TerrarioDTO.HorasLuzHiber;

            _context.SaveChanges();
        }

        public async void Delete(long id)
        {
            Terrario Terrario = _context.Terrarios.FirstOrDefault(a => a.Id == id);

            _context.Remove(Terrario);
            _context.SaveChanges();
        }
        #endregion

        #region Custom

        #endregion
    }
}
