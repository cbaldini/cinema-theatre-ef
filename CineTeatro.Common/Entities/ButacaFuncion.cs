using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.Common.Entities
{
    public class ButacaFuncion : ICloneable
    {
        public int ButacaFuncionId { get; set; }
        public Funcion Funcion { get; set; }
        public int FuncionId { get; set; }
        public Butaca Butaca { get; set; }
        public int ButacaId { get; set; }
        public bool Libre { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
