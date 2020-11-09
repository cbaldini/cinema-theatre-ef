using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.ServiceLayer.Facades
{
    public interface ITitulosService
    {
        List<Titulo> GetLista(int? id);
        Titulo GetObjeto(int id);
        void Guardar(Titulo titulo);
        void Editar(Titulo titulo);
        void Borrar(Titulo titulo);
        bool EsUnico(string descripcion);
    }
}
