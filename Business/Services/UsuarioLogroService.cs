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
            UsuarioLogro UsuarioLogro = _mapper.Map<UsuarioLogro>(UsuarioLogroDTO);

            _context.UsuarioLogros.Add(UsuarioLogro);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            UsuarioLogro UsuarioLogro = _context.UsuarioLogros.FirstOrDefault(a => a.Idusuario == id);

            _context.Remove(UsuarioLogro);
            _context.SaveChanges();
        }

        public async Task<ICollection<UsuarioLogroDTO>> GetAll()
        {
            List<UsuarioLogro> UsuarioLogros = _context.UsuarioLogros.ToList();
            ICollection<UsuarioLogroDTO> alertaDTOs = _mapper.Map<ICollection<UsuarioLogroDTO>>(UsuarioLogros);

            return alertaDTOs;
        }

        public async Task<UsuarioLogroDTO> GetById(int id)
        {
            UsuarioLogro UsuarioLogro = _context.UsuarioLogros.FirstOrDefault(a => a.Idusuario == id);
            UsuarioLogroDTO UsuarioLogroDTO = _mapper.Map<UsuarioLogroDTO>(UsuarioLogro);

            return UsuarioLogroDTO;
        }

        public async void Update(int id, UsuarioLogroDTO UsuarioLogroDTO)
        {
            UsuarioLogro UsuarioLogro = _context.UsuarioLogros.FirstOrDefault(a => a.Idusuario == id);

            UsuarioLogro.Idusuario = UsuarioLogroDTO.Idusuario;
            UsuarioLogro.Idlogro = UsuarioLogroDTO.Idlogro;
            UsuarioLogro.FechaAdquisicion = UsuarioLogroDTO.FechaAdquisicion;

            _context.SaveChanges();
        }
    }
}
