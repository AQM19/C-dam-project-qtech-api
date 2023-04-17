using System;
using System.Collections.Generic;

namespace AutoTerraApi.VMs;
public partial class TareaVM
{
    public long Id { get; set; }

    public long Idterrario { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaResolucion { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Estado { get; set; } = null!;
}
