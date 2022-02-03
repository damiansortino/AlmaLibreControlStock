using System;

namespace ControlStock.Clases
{
    public class MovimientoStock
    {
        public int MovimientoStockId { get; set; }
        public int Cantidad { get; set; }
        public bool Entra { get; set; }
        public bool Sale { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string Descripcion { get; set; }
        public int StockId { get; set; }
        public int? ComprobanteId { get; set; }
        public int TipoMovimientoStockId { get; set; }
    }
}
