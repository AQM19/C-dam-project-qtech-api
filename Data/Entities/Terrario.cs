using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Terrario
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public string? Nombre { get; set; }

    public sbyte Privado { get; set; }

    public string? Contrasena { get; set; }

    public sbyte Hibernacion { get; set; }

    public string? Sustrato { get; set; }

    public string? Descripcion { get; set; }

    public float? Tamano { get; set; }

    public string? Ecosistema { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaUltimaModificacion { get; set; }

    public string? Foto { get; set; }

    public float? PuntuacionMedia { get; set; }

    public float? TemperaturaMinima { get; set; }

    public float? TemperaturaMaxima { get; set; }

    public float? TemperaturaMedia { get; set; }

    public float? TemperaturaMinimaHiber { get; set; }

    public float? TemperaturaMaximaHiber { get; set; }

    public float? TemperaturaMediaHiber { get; set; }

    public float? HumedadMinima { get; set; }

    public float? HumedadMedia { get; set; }

    public float? HumedadMaxima { get; set; }

    public int? HorasLuz { get; set; }

    public int? HorasLuzHiber { get; set; }

    public virtual ICollection<Alerta> Alerta { get; } = new List<Alerta>();

    public virtual ICollection<Dato> Datos { get; } = new List<Dato>();

    public virtual ICollection<EspecieTerrario> EspecieTerrarios { get; } = new List<EspecieTerrario>();

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;

    public virtual ICollection<Notificacion> Notificacions { get; } = new List<Notificacion>();

    public virtual ICollection<Observacion> Observaciones { get; } = new List<Observacion>();

    public virtual ICollection<Tarea> Tareas { get; } = new List<Tarea>();

    public virtual ICollection<Visita> Visita { get; } = new List<Visita>();
}
