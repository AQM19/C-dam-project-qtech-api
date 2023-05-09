using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class EspecieTerrario
{
    public long Idterrario { get; set; }

    public long Idespecie { get; set; }

    public DateTime? FechaInsercion { get; set; }

    public virtual Especie Especie { get; set; } = null!;

    public virtual Terrario Terrario { get; set; } = null!;
}
