using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface IVentasRepositorio
    {
        List<Venta> GetLista(int? id);
        Venta GetObjeto(int id);
        void Guardar(Venta venta);
        void Editar(Venta venta);
        void Borrar(Venta venta);
        bool EsUnico();
    }
}
