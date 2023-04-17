using System;
using System.Collections.Generic;

namespace Business.DTOs;
public partial class EspecieTerrarioDTO
{
    public long Idterrario { get; set; }

    public long Idespecie { get; set; }

    public DateTime? FechaInsercion { get; set; }
}
