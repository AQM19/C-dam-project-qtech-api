using System;
using System.Collections.Generic;

namespace AutoTerraApi.VMs;
public partial class VisitaVM
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public long Idterrario { get; set; }

    public DateTime Fecha { get; set; }

    public string? Comentario { get; set; }

    public float Puntuacion { get; set; }
}
