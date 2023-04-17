using System;
using System.Collections.Generic;

namespace AutoTerraApi.VMs;
public partial class ObservacionVM
{
    public long Id { get; set; }

    public long Idterrario { get; set; }

    public DateTime Fecha { get; set; }

    public string Texto { get; set; } = null!;
}
