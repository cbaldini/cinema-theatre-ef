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
    public class ButacasFuncionesService : IButacasFuncionesService
    {
        private IButacasFuncionesRepositorio repositorioButacasFunciones;
        private readonly CineTeatroDbContext dbContext;

        public ButacasFuncionesService(IButacasFuncionesRepositorio repositorioButacasFunciones, CineTeatroDbContext dbContext)
        {
            this.repositorioButacasFunciones = repositorioButacasFunciones;
        }
        public void Borrar(ButacaFuncion butacafuncion)
        {
            repositorioButacasFunciones.Borrar(butacafuncion);
        }

        public bool EsUnico(int butacaid, int funcionid)
        {
            return repositorioButacasFunciones.EsUnico(butacaid, funcionid);
        }

        public List<ButacaFuncion> GetLista(int? id)
        {
            return repositorioButacasFunciones.GetLista(id);
        }

        public ButacaFuncion GetObjeto(int id)
        {
            return repositorioButacasFunciones.GetObjeto(id);
        }

        public ButacaFuncion GetObjetoButacaFuncion(int idbutaca, int idfuncion)
        {
            return repositorioButacasFunciones.GetObjetoButacaFuncion(idbutaca, idfuncion);
        }

        public void Guardar(ButacaFuncion butacafuncion)
        {
            repositorioButacasFunciones.Guardar(butacafuncion);
        }
    }
}
