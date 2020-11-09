using CineTeatro.Common.Entities;
using CineTeatro.DataLayer.Repositories.Facades;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CineTeatro.DataLayer.Repositories
{
    public class ButacasFuncionesRepositorio : IButacasFuncionesRepositorio
    {
        private readonly CineTeatroDbContext dbContext;


        public ButacasFuncionesRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public void Borrar(ButacaFuncion butacafuncion)
        {
            try
            {
                dbContext.ButacasFunciones.Remove(butacafuncion);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EsUnico(int butacaid, int funcionid)
        {
            try
            {
                return !dbContext.ButacasFunciones.Any(bf => bf.ButacaId == butacaid && bf.FuncionId == funcionid);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<ButacaFuncion> GetLista(int? id)
        {
            return dbContext.ButacasFunciones
                .Include(bf => bf.Butaca)
                .Include(bf => bf.Funcion)
                .AsNoTracking().ToList();
            //try
            //{
            //    IQueryable<ButacaFuncion> query = dbContext.ButacasFunciones.Include(bf => bf.Butaca).Include(bf => bf.Funcion);
            //    if (id != null)
            //    {
            //        query = query.Where(bf => bf.ButacaId == id && bf.FuncionId == id);
            //    }

            //    return query.ToList();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        public ButacaFuncion GetObjeto(int id)
        {
            return dbContext.ButacasFunciones
                .Include(bf => bf.Butaca)
                .Include(bf => bf.Funcion)
                .SingleOrDefault(bf => bf.ButacaFuncionId == id);
        }

        public ButacaFuncion GetObjetoButacaFuncion(int idbutaca, int idfuncion)
        {
            return dbContext.ButacasFunciones
            .Include(bf => bf.Butaca)
            .Include(bf => bf.Funcion)
            .Where(bf => bf.Butaca.ButacaId == idbutaca && bf.Funcion.FuncionId == idfuncion)
            .SingleOrDefault();
            ;

        }

        public void Guardar(ButacaFuncion butacafuncion)
        {
            try
            {
                if (butacafuncion.ButacaFuncionId > 0)
                {
                    dbContext.Entry(butacafuncion).State = EntityState.Modified;
                }
                else
                {
                    dbContext.ButacasFunciones.Add(butacafuncion);
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


