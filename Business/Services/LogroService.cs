using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;

namespace Business.Services
{
    public class LogroService : ILogroService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public LogroService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(LogroDTO LogroDTO)
        {
            try
            {
                Logro Logro = _mapper.Map<Logro>(LogroDTO);

                _context.Logros.Add(Logro);
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
                Logro Logro = _context.Logros.FirstOrDefault(a => a.Id == id);

                _context.Remove(Logro);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<LogroDTO>> GetAll()
        {
            try
            {
                List<Logro> Logros = _context.Logros.ToList();
                ICollection<LogroDTO> alertaDTOs = _mapper.Map<ICollection<LogroDTO>>(Logros);

                return alertaDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LogroDTO> GetById(int id)
        {
            try
            {
                Logro Logro = _context.Logros.FirstOrDefault(a => a.Id == id);
                LogroDTO LogroDTO = _mapper.Map<LogroDTO>(Logro);

                return LogroDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<LogroDTO>> GetLogrosUsuario(long id)
        {
            try
            {
                ICollection<Logro> logros = _context.Logros.Where(x => x.UsuarioLogros.Any(c => c.Idusuario == id)).ToList();
                ICollection<LogroDTO> logroDTOs = _mapper.Map<ICollection<LogroDTO>>(logros);
                return logroDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Update(int id, LogroDTO LogroDTO)
        {
            try
            {
                Logro Logro = _context.Logros.FirstOrDefault(a => a.Id == id);

                Logro.Id = LogroDTO.Id;
                Logro.Titulo = LogroDTO.Titulo;
                Logro.Descripcion = LogroDTO.Descripcion;
                Logro.Icono = LogroDTO.Icono;
                Logro.Disponible = LogroDTO.Disponible;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
