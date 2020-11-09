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
    public class ItemsVentasRepositorio : IItemsVentasRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public ItemsVentasRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(ItemVenta itemventa)
        {
            try
            {
                dbContext.ItemsVentas.Remove(itemventa);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(ItemVenta itemventa)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(ItemVenta itemventa)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(int ventaid, int butacafuncionid)
        {
            try
            {
                return !dbContext.ItemsVentas.Any(b => b.Venta.VentaId == ventaid && b.ButacaFuncion.ButacaFuncionId == butacafuncionid);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<ItemVenta> GetLista(int? id)
        {
            try
            {
                return dbContext.ItemsVentas.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<ItemVenta> GetListaXVenta(int? id)
        {
            try
            {
                return dbContext.ItemsVentas.Where(v => v.Venta.VentaId == id).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ItemVenta GetObjeto(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(ItemVenta itemventa)
        {
            try
            {
                if (itemventa.ItemVentaId > 0)
                {
                    dbContext.Entry(itemventa).State = EntityState.Modified;
                }
                else
                {
                    dbContext.ItemsVentas.Add(itemventa);
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

