using System;
using System.Collections.Generic;

namespace AutoTerraApi.VMs;
public partial class NotificacionVM
{
    public long Id { get; set; }

    public long Idterrario { get; set; }

    public DateTime Fecha { get; set; }

    public string Texto { get; set; } = null!;

    public sbyte Vista { get; set; }

    public string Gravedad { get; set; }
}
