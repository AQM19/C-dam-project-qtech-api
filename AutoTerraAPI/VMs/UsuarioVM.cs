using System;
using System.Collections.Generic;

namespace AutoTerraApi.VMs;
public partial class UsuarioVM
{
    public long Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? FotoPerfil { get; set; }

    public byte[] Salt { get; set; } = null!;

    public string Perfil { get; set; } = null!;
}
