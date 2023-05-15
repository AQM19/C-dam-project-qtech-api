using System;
using System.Collections.Generic;

namespace Business.DTOs;
public partial class LogroDTO
{
    public long Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Icono { get; set; } = null!;

    public DateTime? Fechadesde { get; set; } = null;

    public DateTime? Fechahasta { get; set; } = null;
}
