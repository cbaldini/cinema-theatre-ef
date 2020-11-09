using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.Common.Entities
{
    public class Titulo : ICloneable
    {
        public int TituloId { get; set; }
        public TipoDeTitulo TipoDeTitulo { get; set; }
        public int TipoDeTituloId { get; set; }
        public string Descripcion { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public int ClasificacionId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
