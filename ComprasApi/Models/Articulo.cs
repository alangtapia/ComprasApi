using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ComprasApi.Models;

public partial class Articulo
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public int? UnidadDeMedida { get; set; }

    public int? Existencia { get; set; }

    public string? Estado { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrdenesDeCompra> OrdenesDeCompras { get; set; } = new List<OrdenesDeCompra>();

    public virtual UnidadesDeMedidum? oUnidad{ get; set; }
}
