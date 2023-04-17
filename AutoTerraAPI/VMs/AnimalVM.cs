namespace AutoTerraApi.VMs;

public partial class AnimalVM
{
    public long Id { get; set; }

    public long Idespecie { get; set; }

    public string? Proveniencia { get; set; }

    public string? Reproduccion { get; set; }

    public string? Comportamiento { get; set; }

    public string? Alimentacion { get; set; }
}
