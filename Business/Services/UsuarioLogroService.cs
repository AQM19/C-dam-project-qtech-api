using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;

namespace Business.Services
{
    public class UsuarioLogroService : IUsuarioLogroService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public UsuarioLogroService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(UsuarioLogroDTO UsuarioLogroDTO)
        {
            try
            {
                UsuarioLogro UsuarioLogro = _mapper.Map<UsuarioLogro>(UsuarioLogroDTO);

                _context.UsuarioLogros.Add(UsuarioLogro);
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
                UsuarioLogro UsuarioLogro = _context.UsuarioLogros.FirstOrDefault(a => a.Idusuario == id);

                _context.Remove(UsuarioLogro);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<UsuarioLogroDTO>> GetAll()
        {
            try
            {
                List<UsuarioLogro> UsuarioLogros = _context.UsuarioLogros.ToList();
                ICollection<UsuarioLogroDTO> alertaDTOs = _mapper.Map<ICollection<UsuarioLogroDTO>>(UsuarioLogros);

                return alertaDTOs;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<UsuarioLogroDTO>> GetById(long id)
        {
            try
            {
                List<UsuarioLogro> UsuarioLogro = _context.UsuarioLogros.Where(x => x.Idusuario == id).ToList();
                ICollection<UsuarioLogroDTO> UsuarioLogroDTO = _mapper.Map<ICollection<UsuarioLogroDTO>>(UsuarioLogro);

                return UsuarioLogroDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Update(long id, UsuarioLogroDTO UsuarioLogroDTO)
        {
            try
            {
                UsuarioLogro UsuarioLogro = _context.UsuarioLogros.FirstOrDefault(a => a.Idusuario == id);

                UsuarioLogro.Idusuario = UsuarioLogroDTO.Idusuario;
                UsuarioLogro.Idlogro = UsuarioLogroDTO.Idlogro;
                UsuarioLogro.FechaAdquisicion = UsuarioLogroDTO.FechaAdquisicion;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
