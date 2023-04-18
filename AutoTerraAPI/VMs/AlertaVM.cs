using System;
using System.Collections.Generic;

namespace AutoTerraAPI.VMs;

public partial class AlertaVM
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public long Idterrario { get; set; }

    public DateTime Fecha { get; set; }

    public string? TipoAlerta { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaResolucion { get; set; }

    public string? Gravedad { get; set; }
}
