using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;

namespace Business.Services
{
    public class UsuarioUsuarioService : IUsuarioUsuarioService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public UsuarioUsuarioService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(UsuarioUsuarioDTO UsuarioUsuarioDTO)
        {
            UsuarioUsuario UsuarioUsuario = _mapper.Map<UsuarioUsuario>(UsuarioUsuarioDTO);

            _context.UsuarioUsuarios.Add(UsuarioUsuario);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            UsuarioUsuario UsuarioUsuario = _context.UsuarioUsuarios.FirstOrDefault(a => a.Idusuario == id);

            _context.Remove(UsuarioUsuario);
            _context.SaveChanges();
        }

        public async Task<ICollection<UsuarioUsuarioDTO>> GetAll()
        {
            List<UsuarioUsuario> UsuarioUsuarios = _context.UsuarioUsuarios.ToList();
            ICollection<UsuarioUsuarioDTO> alertaDTOs = _mapper.Map<ICollection<UsuarioUsuarioDTO>>(UsuarioUsuarios);

            return alertaDTOs;
        }

        public async Task<UsuarioUsuarioDTO> GetById(int id)
        {
            UsuarioUsuario UsuarioUsuario = _context.UsuarioUsuarios.FirstOrDefault(a => a.Idusuario == id);
            UsuarioUsuarioDTO UsuarioUsuarioDTO = _mapper.Map<UsuarioUsuarioDTO>(UsuarioUsuario);

            return UsuarioUsuarioDTO;
        }

        public async void Update(int id, UsuarioUsuarioDTO UsuarioUsuarioDTO)
        {
            UsuarioUsuario UsuarioUsuario = _context.UsuarioUsuarios.FirstOrDefault(a => a.Idusuario == id);

            UsuarioUsuario.Idusuario = UsuarioUsuarioDTO.Idusuario;
            UsuarioUsuario.Idcontacto = UsuarioUsuarioDTO.Idcontacto;
            UsuarioUsuario.FechaContacto = UsuarioUsuarioDTO.FechaContacto;

            _context.SaveChanges();
        }
    }
}
