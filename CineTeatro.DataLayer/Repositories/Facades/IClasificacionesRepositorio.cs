using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface IClasificacionesRepositorio
    {
        List<Clasificacion> GetLista(int? id);
        Clasificacion GetObjeto(int id);
        void Guardar(Clasificacion clasificacion);
        void Editar(Clasificacion clasificacion);
        void Borrar(Clasificacion clasificacion);
        bool EsUnico(string descripcion);
    }
}
