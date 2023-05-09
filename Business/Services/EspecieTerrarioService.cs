using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EspecieTerrarioService : IEspecieTerrarioService
    {

        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public EspecieTerrarioService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(EspecieTerrarioDTO EspecieTerrarioDTO)
        {
            EspecieTerrario EspecieTerrario = _mapper.Map<EspecieTerrario>(EspecieTerrarioDTO);

            _context.EspecieTerrarios.Add(EspecieTerrario);
            _context.SaveChanges();
        }
        public async void Delete(int idterrario, int idespecie)
        {
            EspecieTerrario EspecieTerrario = _context.EspecieTerrarios.FirstOrDefault(a => a.Idterrario == idterrario && a.Idespecie == idespecie);

            _context.Remove(EspecieTerrario);
            _context.SaveChanges();
        }
        public async Task<ICollection<EspecieTerrarioDTO>> GetAll()
        {
            List<EspecieTerrario> EspecieTerrarios = _context.EspecieTerrarios.ToList();
            ICollection<EspecieTerrarioDTO> alertaDTOs = _mapper.Map<ICollection<EspecieTerrarioDTO>>(EspecieTerrarios);

            return alertaDTOs;
        }
        public async Task<EspecieTerrarioDTO> GetById(int idterrario, int idespecie)
        {
            EspecieTerrario EspecieTerrario = _context.EspecieTerrarios.FirstOrDefault(a => a.Idterrario == idterrario && a.Idespecie == idespecie);
            EspecieTerrarioDTO EspecieTerrarioDTO = _mapper.Map<EspecieTerrarioDTO>(EspecieTerrario);

            return EspecieTerrarioDTO;
        }
        public async void Update(int idterrario, int idespecie, EspecieTerrarioDTO EspecieTerrarioDTO)
        {
            EspecieTerrario EspecieTerrario = _context.EspecieTerrarios.FirstOrDefault(a => a.Idterrario == idterrario && a.Idespecie == idespecie);

            EspecieTerrario.Idterrario = EspecieTerrarioDTO.Idterrario;
            EspecieTerrario.Idespecie = EspecieTerrarioDTO.Idespecie;
            EspecieTerrario.FechaInsercion = EspecieTerrarioDTO.FechaInsercion;

            _context.SaveChanges();
        }

        public async Task UpdateOfTerrario(long id, List<EspecieTerrarioDTO> list)
        {
            try
            {
                List<EspecieTerrario> especieTerrarios = _mapper.Map<List<EspecieTerrario>>(list);
                List<EspecieTerrario> especiesDatabase = _context.EspecieTerrarios.Where(x => x.Idterrario == id).ToList();

                foreach(EspecieTerrario it in especieTerrarios)
                {
                    EspecieTerrario et = _context.EspecieTerrarios.FirstOrDefault(x => x.Idespecie == it.Idespecie);

                    if(et == null) // bd no, lista si : crear
                    {
                        _context.EspecieTerrarios.Add(it);
                    }
                }

                foreach(EspecieTerrario et in especiesDatabase)
                {
                    EspecieTerrario esp = especieTerrarios.FirstOrDefault(x => x.Idespecie == et.Idespecie);

                    if(esp == null)// bd si, lista no : borrar bd
                    {
                        _context.EspecieTerrarios.Remove(et);
                    }
                }

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
