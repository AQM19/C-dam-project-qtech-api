using System;
using System.Collections.Generic;

namespace AutoTerraApi.VMs;

public partial class ConfiguracionUsuarioVM
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public string Idioma { get; set; } = null!;

    public sbyte Oscuro { get; set; }
}
