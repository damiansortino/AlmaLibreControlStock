using System;

namespace ControlStock.Clases
{
    public class Caja
    {
        public int CajaId { get; set; }
        public DateTime FechaCaja { get; set; }
        public DateTime? FechaCierreCaja { get; set; }
        public double MontoCaja { get; set; }
        public int SucursalId { get; set; }

    }
}
