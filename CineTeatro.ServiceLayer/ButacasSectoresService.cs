using CineTeatro.Common.Entities;
using CineTeatro.DataLayer;
using CineTeatro.DataLayer.Repositories.Facades;
using CineTeatro.ServiceLayer.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.ServiceLayer
{
    public class ButacasSectoresService : IButacasSectoresService
    {
        private IButacasSectoresRepositorio repositorioButacasSectores;
        private readonly CineTeatroDbContext dbContext;

        public ButacasSectoresService(IButacasSectoresRepositorio repositorioButacasSectores, CineTeatroDbContext dbContext)
        {
            this.repositorioButacasSectores = repositorioButacasSectores;
        }

        public void Borrar(ButacaSector butacasector)
        {
            repositorioButacasSectores.Borrar(butacasector);
        }

        public void Editar(ButacaSector butacasector)
        {
            repositorioButacasSectores.Editar(butacasector);
        }

        public bool EsUnico(Butaca butaca, Sector sector)
        {
            return repositorioButacasSectores.EsUnico(butaca, sector);
        }

        public List<ButacaSector> GetLista(int? id)
        {
            return repositorioButacasSectores.GetLista(id);
        }

        public ButacaSector GetObjeto(int id)
        {
            return repositorioButacasSectores.GetObjeto(id);
        }

        public ButacaSector GetSectorXButaca(int id)
        {
            return repositorioButacasSectores.GetSectorXButaca(id);
        }

        public void Guardar(ButacaSector butacasector)
        {
            repositorioButacasSectores.Guardar(butacasector);
        }
    }
}
