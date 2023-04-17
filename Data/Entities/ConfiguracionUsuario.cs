using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class ConfiguracionUsuario
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public string Idioma { get; set; } = null!;

    public sbyte Oscuro { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
