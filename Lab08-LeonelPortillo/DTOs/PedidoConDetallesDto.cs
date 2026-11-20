using System;
using System.Collections.Generic;

namespace Lab08_LeonelPortillo.DTOs;

public class PedidoConDetallesDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<DetalleProductoDto> Detalles { get; set; } = new();
}