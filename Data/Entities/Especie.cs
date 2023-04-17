using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Especie
{
    public long Id { get; set; }

    public string Genero { get; set; } = null!;

    public string Sp { get; set; } = null!;

    public string? NombreComun { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public string? Ecosistema { get; set; }

    public int? DuracionVida { get; set; }

    public sbyte Hiberna { get; set; }

    public float TemperaturaMinima { get; set; }

    public float TemperaturaMaxima { get; set; }

    public float? TemperaturaHibMinima { get; set; }

    public float? TemperaturaHibMaxima { get; set; }

    public float HumedadMinima { get; set; }

    public float HumedadMaxima { get; set; }

    public int HorasLuz { get; set; }

    public int? HorasLuzHib { get; set; }

    public virtual ICollection<Animal> Animales { get; } = new List<Animal>();

    public virtual ICollection<EspecieTerrario> EspecieTerrarios { get; } = new List<EspecieTerrario>();

    public virtual ICollection<Planta> Planta { get; } = new List<Planta>();
}
