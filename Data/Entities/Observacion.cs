using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Observacion
{
    public long Id { get; set; }

    public long Idterrario { get; set; }

    public DateTime Fecha { get; set; }

    public string Texto { get; set; } = null!;

    public virtual Terrario IdterrarioNavigation { get; set; } = null!;
}
