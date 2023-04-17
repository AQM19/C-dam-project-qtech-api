using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Logro
{
    public long Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Icono { get; set; } = null!;

    public sbyte Disponible { get; set; }

    public virtual ICollection<UsuarioLogro> UsuarioLogros { get; } = new List<UsuarioLogro>();
}
