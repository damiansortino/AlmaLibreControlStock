using System;

namespace ControlStock.Clases
{
    public class Cliente
    {
        public int PersonaJuridicaId { get; set; }
        public string RazonSocial { get; set; }
        public string ClienteId { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

    }
}
