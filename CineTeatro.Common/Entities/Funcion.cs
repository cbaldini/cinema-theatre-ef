using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.Common.Entities
{
    public class Funcion : ICloneable
    {
        //string fechahora;
        public int FuncionId { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public Titulo Titulo { get; set; }
        public int TituloId { get; set; }
        public string FechaHora
        {
            get
            {
                return Fecha + " " + Hora;
            }
            //set { fechahora = value; }
        }
        public bool Suspendido { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
