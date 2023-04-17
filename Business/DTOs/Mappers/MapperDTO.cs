using AutoMapper;
using Data.Entities;

namespace Business.DTOs.Mappers
{
    public class MapperDTO : Profile
    {
        public MapperDTO()
        {
            CreateMap<Alerta, AlertaDTO>().ReverseMap();
            CreateMap<Animal, AnimalDTO>().ReverseMap();
            CreateMap<ConfiguracionUsuario, ConfiguracionUsuarioDTO>().ReverseMap();
            CreateMap<Dato, DatoDTO>().ReverseMap();
            CreateMap<Especie, EspecieDTO>().ReverseMap();
            CreateMap<EspecieTerrario, EspecieTerrarioDTO>().ReverseMap();
            CreateMap<Estadistica, EstadisticaDTO>().ReverseMap();
            CreateMap<HistorialCambio, HistorialCambioDTO>().ReverseMap();
            CreateMap<Logro, LogroDTO>().ReverseMap();
            CreateMap<Notificacion, NotificacionDTO>().ReverseMap();
            CreateMap<Observacion, ObservacionDTO>().ReverseMap();
            CreateMap<Planta, PlantaDTO>().ReverseMap();
            CreateMap<Tarea, TareaDTO>().ReverseMap();
            CreateMap<Terrario, TerrarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioLogro, UsuarioLogroDTO>().ReverseMap();
            CreateMap<UsuarioUsuario, UsuarioUsuarioDTO>().ReverseMap();
            CreateMap<Visita, VisitaDTO>().ReverseMap();
        }
    }
}
