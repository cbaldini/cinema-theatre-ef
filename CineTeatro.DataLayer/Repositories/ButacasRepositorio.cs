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
    public class ButacasRepositorio : IButacasRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public ButacasRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(Butaca butaca)
        {
            try
            {
                dbContext.Butacas.Remove(butaca);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(Butaca butaca)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Butaca butaca)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(int numero)
        {
            try
            {
                return !dbContext.Butacas.Any(b => b.Numero == numero);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<Butaca> GetLista(int? id)
        {
            try
            {
                return dbContext.Butacas.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public Butaca GetObjeto(int id)
        {
            return dbContext.Butacas.SingleOrDefault(b => b.ButacaId == id);
        }

        public void Guardar(Butaca butaca)
        {
            try
            {
                if (butaca.ButacaId > 0)
                {
                    dbContext.Entry(butaca).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Butacas.Add(butaca);
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
