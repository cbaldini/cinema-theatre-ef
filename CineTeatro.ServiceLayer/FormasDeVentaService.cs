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
    public class FormasDeVentaService : IFormasDeVentaService
    {
        private readonly CineTeatroDbContext dbContext;
        private IFormasDeVentaRepositorio repositorioFormasDeVenta;

        public FormasDeVentaService(IFormasDeVentaRepositorio repositorioFormasDeVenta, CineTeatroDbContext dbContext)
        {
            this.repositorioFormasDeVenta = repositorioFormasDeVenta;
        }

        public void Borrar(FormaDeVenta formadeventa)
        {
            repositorioFormasDeVenta.Borrar(formadeventa);
        }

        public void Editar(FormaDeVenta formadeventa)
        {
            repositorioFormasDeVenta.Editar(formadeventa);
        }

        public bool EsUnico(string descripcion)
        {
            return repositorioFormasDeVenta.EsUnico(descripcion);
        }

        public List<FormaDeVenta> GetLista(int? id)
        {
            return repositorioFormasDeVenta.GetLista(id);
        }

        public FormaDeVenta GetObjeto(int id)
        {
            return repositorioFormasDeVenta.GetObjeto(id);
        }

        public void Guardar(FormaDeVenta formadeventa)
        {
            repositorioFormasDeVenta.Guardar(formadeventa);
        }
    }
}
