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

        #region CRUD
        public async void Create(UsuarioUsuarioDTO UsuarioUsuarioDTO)
        {
            try
            {
                UsuarioUsuario UsuarioUsuario = _mapper.Map<UsuarioUsuario>(UsuarioUsuarioDTO);

                _context.UsuarioUsuarios.Add(UsuarioUsuario);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ICollection<UsuarioUsuarioDTO>> GetAll()
        {
            try
            {
                List<UsuarioUsuario> UsuarioUsuarios = _context.UsuarioUsuarios.ToList();
                ICollection<UsuarioUsuarioDTO> alertaDTOs = _mapper.Map<ICollection<UsuarioUsuarioDTO>>(UsuarioUsuarios);

                return alertaDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<UsuarioUsuarioDTO> GetById(int id)
        {
            try
            {
                UsuarioUsuario UsuarioUsuario = _context.UsuarioUsuarios.FirstOrDefault(a => a.Idusuario == id);
                UsuarioUsuarioDTO UsuarioUsuarioDTO = _mapper.Map<UsuarioUsuarioDTO>(UsuarioUsuario);

                return UsuarioUsuarioDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Update(int id, UsuarioUsuarioDTO UsuarioUsuarioDTO)
        {
            try
            {
                UsuarioUsuario UsuarioUsuario = _context.UsuarioUsuarios.FirstOrDefault(a => a.Idusuario == id);

                UsuarioUsuario.Idusuario = UsuarioUsuarioDTO.Idusuario;
                UsuarioUsuario.Idcontacto = UsuarioUsuarioDTO.Idcontacto;
                UsuarioUsuario.FechaContacto = UsuarioUsuarioDTO.FechaContacto;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Delete(long idUsuario, long idContacto)
        {
            try
            {
                UsuarioUsuario UsuarioUsuario = _context.UsuarioUsuarios.FirstOrDefault(a => a.Idusuario == idUsuario && a.Idcontacto == idContacto);

                _context.Remove(UsuarioUsuario);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ComprobarSeguimiento(long idUsuario, long idContacto)
        {
            try
            {
                UsuarioUsuario result = _context.UsuarioUsuarios.FirstOrDefault(a => a.Idusuario == idUsuario && a.Idcontacto == idContacto);
                return result == null ? false : true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


    }
}
