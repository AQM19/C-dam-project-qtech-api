using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class UsuarioLogro
{
    public long Idusuario { get; set; }

    public long Idlogro { get; set; }

    public DateTime FechaAdquisicion { get; set; }

    public virtual Logro IdlogroNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
