using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class UsuarioUsuario
{
    public long Idusuario { get; set; }

    public long Idcontacto { get; set; }

    public DateTime FechaContacto { get; set; }

    public virtual Usuario IdcontactoNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
