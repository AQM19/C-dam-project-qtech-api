using System;
using System.Collections.Generic;

namespace AutoTerraAPI.VMs;

public partial class AlertaVM
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public long Idterrario { get; set; }

    public DateTime Fecha { get; set; }

    public string? Comentario { get; set; }

    public float? Puntuacion { get; set; }
}
