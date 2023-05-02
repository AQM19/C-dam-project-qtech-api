using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region CRUD
        public async void Create(UsuarioDTO UsuarioDTO)
        {
            Usuario Usuario = _mapper.Map<Usuario>(UsuarioDTO);

            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();
        }
        public async Task<ICollection<UsuarioDTO>> GetAll()
        {
            ICollection<Usuario> Usuarios = _context.Usuarios.Where(x => x.Borrado == 0).ToList();
            ICollection<UsuarioDTO> alertaDTOs = _mapper.Map<ICollection<UsuarioDTO>>(Usuarios);

            return alertaDTOs;
        }
        public async Task<UsuarioDTO> GetById(long id)
        {
            Usuario Usuario = _context.Usuarios.FirstOrDefault(a => a.Id == id && a.Borrado == 0);
            UsuarioDTO UsuarioDTO = _mapper.Map<UsuarioDTO>(Usuario);

            return UsuarioDTO;
        }
        public async void Update(long id, UsuarioDTO UsuarioDTO)
        {
            Usuario Usuario = _context.Usuarios.FirstOrDefault(a => a.Id == id && a.Borrado == 0);

            Usuario.Id = UsuarioDTO.Id;
            Usuario.Nombre = UsuarioDTO.Nombre;
            Usuario.NombreUsuario = UsuarioDTO.NombreUsuario;
            Usuario.Contrasena = UsuarioDTO.Contrasena;
            Usuario.Apellido1 = UsuarioDTO.Apellido1;
            Usuario.Apellido2 = UsuarioDTO.Apellido2;
            Usuario.FechaNacimiento = UsuarioDTO.FechaNacimiento;
            Usuario.Email = UsuarioDTO.Email;
            Usuario.Telefono = UsuarioDTO.Telefono;
            Usuario.FotoPerfil = UsuarioDTO.FotoPerfil;
            Usuario.Salt = UsuarioDTO.Salt;
            Usuario.Perfil = UsuarioDTO.Perfil;

            _context.SaveChanges();
        }
        public async void Delete(long id)
        {
            Usuario Usuario = _context.Usuarios.FirstOrDefault(a => a.Id == id && a.Borrado == 0);
            Usuario.Borrado = 1;

            _context.SaveChanges();
        }
        #endregion
        #region Custom
        public async Task<ICollection<UsuarioDTO>> GetSocial(long id) //op
        {
            ICollection<Usuario> social = _context.Usuarios.Where(x => x.Id != id && x.Borrado == 0 && !x.Contactos.Any(c => c.Idusuario == id)).ToList();
            ICollection<UsuarioDTO> socialDTO = _mapper.Map<ICollection<UsuarioDTO>>(social);

            return socialDTO;
        }
        public async Task<UsuarioDTO> GetByLogin(string param, string password)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(x => (x.NombreUsuario == param || x.Email == param) && x.Borrado == 0);

            if (usuario == null) return null;

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] inputBytes = passwordBytes.Concat(usuario.Salt).ToArray();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passHash = sha256.ComputeHash(inputBytes);
                string hash = Convert.ToBase64String(passHash);

                if (usuario.Contrasena == hash)
                {
                    UsuarioDTO usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
                    return usuarioDTO;
                }
            }

            return null;
        }
        public async Task<bool> CheckUser(string param)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(x => (x.NombreUsuario == param || x.Email == param) && x.Borrado == 0);

            return usuario == null ? true : false;
        }
        public async Task<ICollection<UsuarioDTO>> SearchUser(string param)
        {
            ICollection<Usuario> usuarios = _context.Usuarios.Where(x => x.NombreUsuario.Contains(param)).ToList();
            ICollection<UsuarioDTO> usuarioDTOs = _mapper.Map<ICollection<UsuarioDTO>>(usuarios);

            return usuarioDTOs;
        }
        #endregion
    }
}