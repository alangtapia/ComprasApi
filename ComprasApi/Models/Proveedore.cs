using System;
using System.Collections.Generic;

namespace ComprasApi.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string? CedulaRnc { get; set; }

    public string? NombreComercial { get; set; }

    public string? Estado { get; set; }
}
