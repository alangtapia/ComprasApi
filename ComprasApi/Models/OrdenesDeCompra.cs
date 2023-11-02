using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ComprasApi.Models;

public partial class OrdenesDeCompra
{
    public int Id { get; set; }

    public DateTime? FechaDeOrden { get; set; }

    public string? Estado { get; set; }

    public int? Articulo { get; set; }

    public int? Cantidad { get; set; }

    public int? UnidadDeMedida { get; set; }

    public decimal? CostoUnitario { get; set; }
  
    public virtual Articulo? oArticulo { get; set; }
    [JsonIgnore]
    public virtual UnidadesDeMedidum? oUnidad { get; set; }
}
