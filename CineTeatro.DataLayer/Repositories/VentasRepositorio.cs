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
    public class VentasRepositorio : IVentasRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public VentasRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(Venta venta)
        {
            try
            {
                dbContext.Ventas.Remove(venta);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(Venta venta)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Venta venta)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico()
        {
            try
            {
                throw new NotImplementedException();

                //return !dbContext.Ventas.Any(b => b.DetalleDeVenta = detalleDeVenta );
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<Venta> GetLista(int? id)
        {
            try
            {
                return dbContext
                    .Ventas
                    .Include(v => v.FormaDePago)
                    .Include(v => v.FormaDeVenta)
                    .OrderBy(v => v.FechaDeVenta)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public Venta GetObjeto(int id)
        {
            try
            {
                return dbContext
                    .Ventas
                    .Include(v => v.FormaDePago)
                    .Include(v => v.FormaDeVenta)
                    .SingleOrDefault(v => v.VentaId == id);
            }
            catch (Exception)
            {

                throw;
            }        }

        public void Guardar(Venta venta)
        {
            try
            {
                if (venta.VentaId > 0)
                {
                    dbContext.Entry(venta).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Ventas.Add(venta);
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
