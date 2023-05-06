using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Notificacion
{
    public long Id { get; set; }

    public long Idterrario { get; set; }

    public DateTime Fecha { get; set; }

    public string Texto { get; set; } = null!;

    public sbyte Vista { get; set; }

    public virtual Terrario Terrario { get; set; } = null!;
}
