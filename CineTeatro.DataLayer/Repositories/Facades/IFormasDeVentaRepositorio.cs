using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface IFormasDeVentaRepositorio
    {
        List<FormaDeVenta> GetLista(int? id);
        FormaDeVenta GetObjeto(int id);
        void Guardar(FormaDeVenta formadeventa);
        void Editar(FormaDeVenta formadeventa);
        void Borrar(FormaDeVenta formadeventa);
        bool EsUnico(string descripcion);
    }
}
