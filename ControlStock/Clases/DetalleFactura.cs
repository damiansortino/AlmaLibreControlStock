using System;

namespace ControlStock.Clases
{
    public class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Bonificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int ProductoId { get; set; }
        public string CadenaBusquedaProducto { get; set; }
        public int ComprobanteId { get; set; }

    }
}
