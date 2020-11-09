using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.Common.Entities
{
    public class Venta : ICloneable
    {
        public int VentaId { get; set; }
        public DateTime FechaDeVenta { get; set; }
        public FormaDeVenta FormaDeVenta { get; set; }
        public int FormaDeVentaId { get; set; }
        public FormaDePago FormaDePago { get; set; }
        public int FormaDePagoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public List<ItemVenta> DetalleDeVenta { get; set; } = new List<ItemVenta>();


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
