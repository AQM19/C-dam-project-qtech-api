using System;
using System.Collections.Generic;
namespace Business.DTOs;

public partial class AnimalDTO
{
    public long Id { get; set; }

    public long Idespecie { get; set; }

    public string? Proveniencia { get; set; }

    public string? Reproduccion { get; set; }

    public string? Comportamiento { get; set; }

    public string? Alimentacion { get; set; }
}
