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
    public class ButacasService : IButacasService
    {
        private IButacasRepositorio repositorioButacas;
        CineTeatroDbContext dbContext;

        public ButacasService(IButacasRepositorio repositorioButacas, CineTeatroDbContext dbContext)
        {
            this.repositorioButacas = repositorioButacas;
        }

        public void Borrar(Butaca butaca)
        {
            repositorioButacas.Borrar(butaca);
        }

        public void Editar(Butaca butaca)
        {
            repositorioButacas.Editar(butaca);
        }

        public bool EsUnico(int numero)
        {
            return repositorioButacas.EsUnico(numero);
        }

        public List<Butaca> GetLista(int? id)
        {
            return repositorioButacas.GetLista(id);
        }

        public Butaca GetObjeto(int id)
        {
            return repositorioButacas.GetObjeto(id);
        }

        public void Guardar(Butaca butaca)
        {
            repositorioButacas.Guardar(butaca);
        }
    }
}
