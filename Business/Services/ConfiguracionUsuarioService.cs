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
    public class ConfiguracionUsuarioService : IConfiguracionUsuarioService
    {

        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public ConfiguracionUsuarioService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(ConfiguracionUsuarioDTO ConfiguracionUsuarioDTO)
        {
            ConfiguracionUsuario ConfiguracionUsuario = _mapper.Map<ConfiguracionUsuario>(ConfiguracionUsuarioDTO);

            _context.ConfiguracionUsuarios.Add(ConfiguracionUsuario);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            ConfiguracionUsuario ConfiguracionUsuario = _context.ConfiguracionUsuarios.FirstOrDefault(a => a.Id == id);

            _context.Remove(ConfiguracionUsuario);
            _context.SaveChanges();
        }

        public async Task<ICollection<ConfiguracionUsuarioDTO>> GetAll()
        {
            List<ConfiguracionUsuario> ConfiguracionUsuarios = _context.ConfiguracionUsuarios.ToList();
            ICollection<ConfiguracionUsuarioDTO> alertaDTOs = _mapper.Map<ICollection<ConfiguracionUsuarioDTO>>(ConfiguracionUsuarios);

            return alertaDTOs;
        }

        public async Task<ConfiguracionUsuarioDTO> GetById(int id)
        {
            ConfiguracionUsuario ConfiguracionUsuario = _context.ConfiguracionUsuarios.FirstOrDefault(a => a.Id == id);
            ConfiguracionUsuarioDTO ConfiguracionUsuarioDTO = _mapper.Map<ConfiguracionUsuarioDTO>(ConfiguracionUsuario);

            return ConfiguracionUsuarioDTO;
        }

        public async void Update(int id, ConfiguracionUsuarioDTO ConfiguracionUsuarioDTO)
        {
            ConfiguracionUsuario ConfiguracionUsuario = _context.ConfiguracionUsuarios.FirstOrDefault(a => a.Id == id);

            ConfiguracionUsuario.Id = ConfiguracionUsuarioDTO.Id;
            ConfiguracionUsuario.Idusuario = ConfiguracionUsuarioDTO.Idusuario;
            ConfiguracionUsuario.Idioma = ConfiguracionUsuarioDTO.Idioma;
            ConfiguracionUsuario.Oscuro = ConfiguracionUsuarioDTO.Oscuro;

            _context.SaveChanges();
        }
    }
}
