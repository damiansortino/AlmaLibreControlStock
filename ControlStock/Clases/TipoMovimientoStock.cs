using System;

namespace ControlStock.Clases
{
    public class TipoMovimientoStock
    {
        public int TipoMovimientoStockId { get; set; }
        public string NombreTipoMovimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

    }
}
