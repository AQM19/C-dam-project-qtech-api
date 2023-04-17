using System;
using System.Collections.Generic;

namespace Business.DTOs;
public partial class HistorialCambioDTO
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public string NombreTabla { get; set; } = null!;

    public string Accion { get; set; } = null!;

    public string? Detalles { get; set; }

    public string? Observaciones { get; set; }
}
