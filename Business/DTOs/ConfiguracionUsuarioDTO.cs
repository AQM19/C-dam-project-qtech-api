using System;
using System.Collections.Generic;

namespace Business.DTOs;

public partial class ConfiguracionUsuarioDTO
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public string Idioma { get; set; } = null!;

    public sbyte Oscuro { get; set; }
}
