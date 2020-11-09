using CineTeatro.ServiceLayer.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineTeatro.Common.Entities;
using System.Data.SqlClient;
using CineTeatro.DataLayer.Repositories.Facades;

namespace CineTeatro.ServiceLayer
{
    public class VentasService : IVentasService
    {
        private IVentasRepositorio repositorioVentas;

        public VentasService(IVentasRepositorio repositorioVentas)
        {
            this.repositorioVentas = repositorioVentas;
        }

        public void Borrar(Venta venta)
        {
            repositorioVentas.Borrar(venta);
        }

        public void Editar(Venta venta)
        {
            repositorioVentas.Editar(venta);
        }

        public bool EsUnico()
        {
            throw new NotImplementedException();
            //return repositorioVentas.EsUnico();
        }

        public List<Venta> GetLista(int? id)
        {
            return repositorioVentas.GetLista(id);
        }

        public Venta GetObjeto(int id)
        {
            return repositorioVentas.GetObjeto(id);
        }

        public void Guardar(Venta venta)
        {
            repositorioVentas.Guardar(venta);
        }
    }
}
