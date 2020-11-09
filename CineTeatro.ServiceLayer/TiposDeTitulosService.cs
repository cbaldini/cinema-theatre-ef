using CineTeatro.ServiceLayer.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineTeatro.Common.Entities;
using System.Data.SqlClient;
using CineTeatro.DataLayer.Repositories.Facades;

namespace CineTeatro.ServiceLayer
{
    public class TiposDeTitulosService : ITiposDeTitulosService
    {
        private ITiposDeTitulosRepositorio repositorioTiposDeTitulo;

        public TiposDeTitulosService(ITiposDeTitulosRepositorio repositorioTiposDeTitulo)
        {
            this.repositorioTiposDeTitulo = repositorioTiposDeTitulo;
        }

        public void Borrar(TipoDeTitulo tipodetitulo)
        {
            repositorioTiposDeTitulo.Borrar(tipodetitulo);
        }

        public void Editar(TipoDeTitulo tipodetitulo)
        {
            repositorioTiposDeTitulo.Editar(tipodetitulo);
        }

        public bool EsUnico(string descripcion)
        {
            return repositorioTiposDeTitulo.EsUnico(descripcion);
        }

        public List<TipoDeTitulo> GetLista(int? id)
        {
            return repositorioTiposDeTitulo.GetLista(id);
        }

        public TipoDeTitulo GetObjeto(int id)
        {
            return repositorioTiposDeTitulo.GetObjeto(id);
        }

        public void Guardar(TipoDeTitulo tipodetitulo)
        {
            repositorioTiposDeTitulo.Guardar(tipodetitulo);
        }
    }
}
