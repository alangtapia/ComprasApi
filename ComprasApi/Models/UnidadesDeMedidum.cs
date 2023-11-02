using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ComprasApi.Models;

public partial class UnidadesDeMedidum
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }
    [JsonIgnore]
    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    [JsonIgnore]
    public virtual ICollection<OrdenesDeCompra> OrdenesDeCompras { get; set; } = new List<OrdenesDeCompra>();
}
