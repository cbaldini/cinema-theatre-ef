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
    public class FormasDePagoRepositorio : IFormasDePagoRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public FormasDePagoRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(FormaDePago formadepago)
        {
            try
            {
                dbContext.FormasDePago.Remove(formadepago);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(FormaDePago formadepago)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(FormaDePago formadepago)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(string descripcion)
        {
            try
            {
                return !dbContext.FormasDePago.Any(b => b.Descripcion == descripcion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<FormaDePago> GetLista(int? id)
        {
            try
            {
                return dbContext.FormasDePago.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public FormaDePago GetObjeto(int id)
        {
            try
            {
                return dbContext.FormasDePago
                    .SingleOrDefault(fp => fp.FormaDePagoId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(FormaDePago formadepago)
        {
            try
            {
                if (formadepago.FormaDePagoId > 0)
                {
                    dbContext.Entry(formadepago).State = EntityState.Modified;
                }
                else
                {
                    dbContext.FormasDePago.Add(formadepago);
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
