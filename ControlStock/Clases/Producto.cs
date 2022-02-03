using System;

namespace ControlStock.Clases
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public double Rentabilidad { get; set; }
        public string Talle { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
    }
}
