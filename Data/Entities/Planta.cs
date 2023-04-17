using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Planta
{
    public long Id { get; set; }

    public long Idespecie { get; set; }

    public string? TipoPlanta { get; set; }

    public float? Altura { get; set; }

    public float? Ancho { get; set; }

    public string? Floracion { get; set; }

    public string? Fructificacion { get; set; }

    public string? Propagacion { get; set; }

    public string? Suelo { get; set; }

    public virtual Especie IdespecieNavigation { get; set; } = null!;
}
