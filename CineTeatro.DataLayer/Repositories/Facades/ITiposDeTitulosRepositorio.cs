using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface ITiposDeTitulosRepositorio
    {
        List<TipoDeTitulo> GetLista(int? id);
        TipoDeTitulo GetObjeto(int id);
        void Guardar(TipoDeTitulo tipodetitulo);
        void Editar(TipoDeTitulo tipodetitulo);
        void Borrar(TipoDeTitulo tipodetitulo);
        bool EsUnico(string descripcion);
    }
}
