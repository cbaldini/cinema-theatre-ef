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
    public class FormasDeVentaRepositorio : IFormasDeVentaRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public FormasDeVentaRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(FormaDeVenta formadepago)
        {
            try
            {
                dbContext.FormasDeVenta.Remove(formadepago);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(FormaDeVenta formadepago)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(FormaDeVenta formadepago)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(string descripcion)
        {
            try
            {
                return !dbContext.FormasDeVenta.Any(b => b.Descripcion == descripcion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<FormaDeVenta> GetLista(int? id)
        {
            try
            {
                return dbContext.FormasDeVenta.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public FormaDeVenta GetObjeto(int id)
        {
            try
            {
                return dbContext.FormasDeVenta
                    .SingleOrDefault(fv => fv.FormaDeVentaId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(FormaDeVenta formadepago)
        {
            try
            {
                if (formadepago.FormaDeVentaId > 0)
                {
                    dbContext.Entry(formadepago).State = EntityState.Modified;
                }
                else
                {
                    dbContext.FormasDeVenta.Add(formadepago);
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
