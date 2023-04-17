using System;
using System.Collections.Generic;

namespace AutoTerraApi.VMs; 
public partial class EspecieTerrarioVM
{
    public long Idterrario { get; set; }

    public long Idespecie { get; set; }

    public DateTime? FechaInsercion { get; set; }
}
