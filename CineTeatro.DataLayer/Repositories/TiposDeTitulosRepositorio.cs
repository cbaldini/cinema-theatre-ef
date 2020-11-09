using CineTeatro.Common.Entities;
using CineTeatro.DataLayer.Repositories.Facades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories
{
    public class TiposDeTitulosRepositorio : ITiposDeTitulosRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public TiposDeTitulosRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(TipoDeTitulo tipodetitulo)
        {
            try
            {
                dbContext.TiposDeTitulos.Remove(tipodetitulo);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(TipoDeTitulo tipodetitulo)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(TipoDeTitulo tipodetitulo)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(string descripcion)
        {
            try
            {
                return !dbContext.TiposDeTitulos.Any(b => b.Descripcion == descripcion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<TipoDeTitulo> GetLista(int? id)
        {
            try
            {
                return dbContext.TiposDeTitulos.AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public TipoDeTitulo GetObjeto(int id)
        {
            try
            {
                return dbContext.TiposDeTitulos.SingleOrDefault(tt => tt.TipoDeTituloId == id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeTitulo tipodetitulo)
        {
            try
            {
                if (tipodetitulo.TipoDeTituloId > 0)
                {
                    dbContext.Entry(tipodetitulo).State = EntityState.Modified;
                }
                else
                {
                    dbContext.TiposDeTitulos.Add(tipodetitulo);
                }
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
