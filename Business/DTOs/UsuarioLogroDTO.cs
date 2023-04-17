using System;
using System.Collections.Generic;

namespace Business.DTOs;
public partial class UsuarioLogroDTO
{
    public long Idusuario { get; set; }

    public long Idlogro { get; set; }

    public DateTime FechaAdquisicion { get; set; }
}
