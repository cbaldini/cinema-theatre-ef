using CineTeatro.ServiceLayer.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineTeatro.Common.Entities;
using System.Data.SqlClient;
using CineTeatro.DataLayer.Repositories.Facades;
using CineTeatro.DataLayer;

namespace CineTeatro.ServiceLayer
{
    public class ItemsVentasService : IItemsVentasService
    {
        private IItemsVentasRepositorio repositorioItemsVentas;
        private readonly CineTeatroDbContext dbContext;

        public ItemsVentasService(IItemsVentasRepositorio repositorioItemsVentas, CineTeatroDbContext dbContext)
        {
            this.repositorioItemsVentas = repositorioItemsVentas;
            this.dbContext = dbContext;
        }
        public void Borrar(ItemVenta itemVenta)
        {
            repositorioItemsVentas.Borrar(itemVenta);
        }

        public void Editar(ItemVenta itemventa)
        {
            repositorioItemsVentas.Editar(itemventa);
        }

        public bool EsUnico(int ventaid, int butacafuncionid)
        {
            return repositorioItemsVentas.EsUnico(ventaid, butacafuncionid);
        }

        public List<ItemVenta> GetLista(int? id)
        {
            return repositorioItemsVentas.GetLista(id);
        }

        public List<ItemVenta> GetListaXVenta(int? id)
        {
            return repositorioItemsVentas.GetListaXVenta(id);
        }

        public ItemVenta GetObjeto(int id)
        {
            return repositorioItemsVentas.GetObjeto(id);
        }

        public void Guardar(ItemVenta itemVenta)
        {
            repositorioItemsVentas.Guardar(itemVenta);
        }
    }
}
