using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.Common.Entities
{
    public class ButacaSector : ICloneable
    {
        public int ButacaSectorId { get; set; }
        public Butaca Butaca { get; set; }
        public int ButacaId { get; set; }
        public Sector Sector { get; set; }
        public int SectorId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
