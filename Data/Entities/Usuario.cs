using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Usuario
{
    public long Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? Nombre { get; set; } = null!;

    public string? Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? FotoPerfil { get; set; }

    public byte[] Salt { get; set; } = null!;

    public sbyte Borrado { get; set; }

    public string Perfil { get; set; } = null!;

    public virtual ICollection<ConfiguracionUsuario> ConfiguracionUsuarios { get; } = new List<ConfiguracionUsuario>();

    public virtual ICollection<Estadistica> Estadisticas { get; } = new List<Estadistica>();

    public virtual ICollection<Terrario> Terrarios { get; } = new List<Terrario>();

    public virtual ICollection<UsuarioLogro> UsuarioLogros { get; } = new List<UsuarioLogro>();

    public virtual ICollection<UsuarioUsuario> UsuarioUsuarioIdcontactoNavigations { get; } = new List<UsuarioUsuario>();

    public virtual ICollection<UsuarioUsuario> UsuarioUsuarioIdusuarioNavigations { get; } = new List<UsuarioUsuario>();

    public virtual ICollection<Visita> Visita { get; } = new List<Visita>();
}
