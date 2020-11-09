using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface IButacasRepositorio
    {
        List<Butaca> GetLista(int? id);
        Butaca GetObjeto(int id);
        void Guardar(Butaca butaca);
        void Editar(Butaca butaca);
        void Borrar(Butaca butaca);
        bool EsUnico(int numero);
    }
}
