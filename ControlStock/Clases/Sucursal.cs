using System;

namespace ControlStock.Clases
{
    public class Sucursal
    {
        public int SucursalId { get; set; }
        public string NombreSucursal { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

    }
}
