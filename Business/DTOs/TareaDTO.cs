using System;
using System.Collections.Generic;

namespace Business.DTOs;
public partial class TareaDTO
{
    public long Id { get; set; }

    public long Idterrario { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaResolucion { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Estado { get; set; } = null!;
}
