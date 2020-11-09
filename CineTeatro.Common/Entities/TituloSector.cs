using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.Common.Entities
{
    public class TituloSector : ICloneable
    {
        public int TituloSectorId { get; set; }
        public Titulo Titulo { get; set; }
        public int TituloId { get; set; }
        public Sector Sector { get; set; }
        public int SectorId { get; set; }
        public decimal Importe { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
