using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class EspecieTerrario
{
    public long Idterrario { get; set; }

    public long Idespecie { get; set; }

    public DateTime? FechaInsercion { get; set; }

    public virtual Especie IdespecieNavigation { get; set; } = null!;

    public virtual Terrario IdterrarioNavigation { get; set; } = null!;
}
