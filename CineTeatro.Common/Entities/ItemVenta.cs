using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.Common.Entities
{
    public class ItemVenta : ICloneable
    {
        public int ItemVentaId { get; set; }
        public Venta Venta { get; set; }
        public int VentaId { get; set; }
        public ButacaFuncion ButacaFuncion { get; set; }
        public int ButacaFuncionId { get; set; }
        public TituloSector TituloSector { get; set; }
        public int TituloSectorId { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
