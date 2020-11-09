using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface IFuncionesRepositorio
    {
        List<Funcion> GetLista(int? id);
        List<Funcion> GetFuncionXTitulo(int tituloid);
        Funcion GetObjeto(int id);
        void Guardar(Funcion funcion);
        void Editar(Funcion funcion);
        void Borrar(Funcion funcion);
        bool EsUnico(string descripcion);
    }
}
