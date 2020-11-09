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
    public class ButacasSectoresRepositorio : IButacasSectoresRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public ButacasSectoresRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Borrar(ButacaSector butacasector)
        {
            try
            {
                dbContext.ButacasSectores.Remove(butacasector);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(ButacaSector butacasector)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(int numero)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(Butaca butaca, Sector sector)
        {
            throw new NotImplementedException();
        }

        public List<ButacaSector> GetLista(int? id)
        {
            try
            {
                return dbContext.ButacasSectores
                     .Include(bs => bs.Butaca)
                        .Include(bs => bs.Sector)
                         .OrderBy(bs => bs.Sector.Descripcion)
                          .AsNoTracking()
                           .ToList();
            }
            catch (Exception)
            {

                throw;
            }        }

        public ButacaSector GetObjeto(int id)
        {
            return dbContext.ButacasSectores
                 .Include(bs => bs.Butaca)
                 .Include(bs => bs.Sector)
                 .SingleOrDefault(ts => ts.ButacaSectorId == id);

        }

        public ButacaSector GetObjetoButacaSector(int idbutaca, int idsector)
        {
            throw new NotImplementedException();
        }

        public ButacaSector GetSectorXButaca(int id)
        {
            return dbContext.ButacasSectores
            .Include(bs => bs.Butaca)
            .Include(bs => bs.Sector)
            .Where(bs => bs.Butaca.ButacaId == id)
            .SingleOrDefault();
            ;
        }

        public void Guardar(ButacaSector butacasector)
        {
            try
            {
                if (butacasector.ButacaId > 0)
                {
                    dbContext.Entry(butacasector).State = EntityState.Modified;
                }
                else
                {
                    dbContext.ButacasSectores.Add(butacasector);
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
