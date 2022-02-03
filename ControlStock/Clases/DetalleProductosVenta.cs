namespace ControlStock.Clases
{
    public class DetalleProductosVenta
    {
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public string NombreProducto { get; set; }
        public double Precio { get; set; }
        public double Subtotal { get; set; }
        public double Bonificacion { get; set; }
        public string Marca { get; set; }
        public string Talle { get; set; }
        public string Color { get; set; }
    }
}
