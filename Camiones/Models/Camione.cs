using System;
using System.Collections.Generic;

namespace Camiones.Models;

public partial class Camione
{
    public int? IdCamionero { get; set; }

    public string? Marca { get; set; }

    public string Patente { get; set; } = null!;

    public string? TipoCamion { get; set; }

    public int? PesoCamion { get; set; }

    public int? PesoCarga { get; set; }

    public string? GpsCc { get; set; }
}
