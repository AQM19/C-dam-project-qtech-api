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
            Logro Logro = _mapper.Map<Logro>(LogroDTO);

            _context.Logros.Add(Logro);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Logro Logro = _context.Logros.FirstOrDefault(a => a.Id == id);

            _context.Remove(Logro);
            _context.SaveChanges();
        }

        public async Task<ICollection<LogroDTO>> GetAll()
        {
            List<Logro> Logros = _context.Logros.ToList();
            ICollection<LogroDTO> alertaDTOs = _mapper.Map<ICollection<LogroDTO>>(Logros);

            return alertaDTOs;
        }

        public async Task<LogroDTO> GetById(int id)
        {
            Logro Logro = _context.Logros.FirstOrDefault(a => a.Id == id);
            LogroDTO LogroDTO = _mapper.Map<LogroDTO>(Logro);

            return LogroDTO;
        }

        public async Task<ICollection<LogroDTO>> GetLogrosUsuario(long id)
        {
            ICollection<Logro> logros = _context.Logros.Where(x => x.UsuarioLogros.Any(c => c.Idusuario == id)).ToList();
            ICollection<LogroDTO> logroDTOs = _mapper.Map<ICollection<LogroDTO>>(logros);
            return logroDTOs;
        }

        public async void Update(int id, LogroDTO LogroDTO)
        {
            Logro Logro = _context.Logros.FirstOrDefault(a => a.Id == id);

            Logro.Id = LogroDTO.Id;
            Logro.Titulo = LogroDTO.Titulo;
            Logro.Descripcion = LogroDTO.Descripcion;
            Logro.Icono = LogroDTO.Icono;
            Logro.Disponible = LogroDTO.Disponible;

            _context.SaveChanges();
        }
    }
}
