using System;

namespace ControlStock.Clases
{
    public class MovimientoCaja
    {
        public int MovimientoCajaCajaId { get; set; }
        public bool Entra { get; set; }
        public bool Sale { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public double Importe { get; set; }
        public string Observaciones { get; set; }
        public int TipoMovimientoCaja { get; set; }
        public int CajaId { get; set; }
        public int ComprobanteId { get; set; }
    }
}
