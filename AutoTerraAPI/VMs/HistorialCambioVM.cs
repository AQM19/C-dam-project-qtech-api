using System;
using System.Collections.Generic;

namespace AutoTerraApi.VMs;
public partial class HistorialCambioVM
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public string NombreTabla { get; set; } = null!;

    public string Accion { get; set; } = null!;

    public string? Detalles { get; set; }

    public string? Observaciones { get; set; }
}
