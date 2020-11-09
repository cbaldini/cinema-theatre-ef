using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface ISectoresRepositorio
    {
        List<Sector> GetLista(int? id);
        Sector GetObjeto(int id);
        void Guardar(Sector sector);
        void Editar(Sector sector);
        void Borrar(Sector sector);
        bool EsUnico(string descripcion);
    }
}
