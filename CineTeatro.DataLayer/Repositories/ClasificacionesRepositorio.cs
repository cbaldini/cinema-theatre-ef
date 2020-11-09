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
    public class ClasificacionesRepositorio : IClasificacionesRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public ClasificacionesRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(Clasificacion clasificacion)
        {
            try
            {
                dbContext.Clasificaciones.Remove(clasificacion);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(Clasificacion clasificacion)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Clasificacion clasificacion)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(string descripcion)
        {
            try
            {
                return !dbContext.Clasificaciones.Any(b => b.Descripcion == descripcion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<Clasificacion> GetLista(int? id)
        {
            try
            {
                return dbContext.Clasificaciones.AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public Clasificacion GetObjeto(int id)
        {
            try
            {
                return dbContext.Clasificaciones.SingleOrDefault(c => c.ClasificacionId == id);
            }
            catch (Exception e)
            {

                throw new Exception (e.Message);
            }
        }

        public void Guardar(Clasificacion clasificacion)
        {
            try
            {
                if (clasificacion.ClasificacionId > 0)
                {
                    dbContext.Entry(clasificacion).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Clasificaciones.Add(clasificacion);
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
