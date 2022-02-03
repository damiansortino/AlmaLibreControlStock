using System;

namespace ControlStock.Clases
{
    public class Comprobante
    {
        public int ComprobanteId { get; set; }
        public string codigo { get; set; }
        public double Importe { get; set; }
        public double Bonificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int PersonaJuridicaId { get; set; }
        public int TipoComprobanteId { get; set; }
        public int SucursalId { get; set; }
        public double Efectivo { get; set; }
        public double Tarjeta { get; set; }
        public double Tarjeta1 { get; set; }
        public double Tarjeta2 { get; set; }
        public double TarjDebito { get; set; }
        public double Transferencia { get; set; }
        public double GedNet { get; set; }
        public double MercadoPago { get; set; }
        public string UserName { get; set; }

        public Comprobante(int idcomprobante)
        {
            ComprobanteId = idcomprobante;
        }
        public Comprobante(Comprobante comp)
        {
            this.ComprobanteId = comp.ComprobanteId;
        }
        public Comprobante()
        {

        }
    }
}