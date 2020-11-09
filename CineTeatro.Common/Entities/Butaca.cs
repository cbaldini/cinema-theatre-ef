using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.Common.Entities
{
    public class Butaca : ICloneable
    {
        public int ButacaId { get; set; }
        public int Numero { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
