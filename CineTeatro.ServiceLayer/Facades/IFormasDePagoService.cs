using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.ServiceLayer.Facades
{
    public interface IFormasDePagoService
    {
        List<FormaDePago> GetLista(int? id);
        FormaDePago GetObjeto(int id);
        void Guardar(FormaDePago formadepago);
        void Editar(FormaDePago formadepago);
        void Borrar(FormaDePago formadepago);
        bool EsUnico(string descripcion);
    }
}
