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
    public class FormasDePagoService : IFormasDePagoService
    {
        private IFormasDePagoRepositorio repositorioFormasDePago;
        private readonly CineTeatroDbContext dbContext;

        public FormasDePagoService(IFormasDePagoRepositorio repositorioFormasDePago, CineTeatroDbContext dbContext)
        {
            this.repositorioFormasDePago = repositorioFormasDePago;
        }

        public void Borrar(FormaDePago formadepago)
        {
            repositorioFormasDePago.Borrar(formadepago);
        }

        public void Editar(FormaDePago formadepago)
        {
            repositorioFormasDePago.Editar(formadepago);
        }

        public bool EsUnico(string descripcion)
        {
            return repositorioFormasDePago.EsUnico(descripcion);
        }

        public List<FormaDePago> GetLista(int? id)
        {
            return repositorioFormasDePago.GetLista(id);
        }

        public FormaDePago GetObjeto(int id)
        {
            return repositorioFormasDePago.GetObjeto(id);
        }

        public void Guardar(FormaDePago formadepago)
        {
            repositorioFormasDePago.Guardar(formadepago);
        }
    }
}
