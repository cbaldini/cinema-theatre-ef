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
    public class TitulosSectoresRepositorio : ITitulosSectoresRepositorio
    {

        private readonly CineTeatroDbContext dbContext;

        public TitulosSectoresRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(TituloSector titulosector)
        {
            try
            {
                dbContext.TitulosSectores.Remove(titulosector);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(TituloSector butaca)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(TituloSector butaca)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(Titulo titulo, Sector sector)
        {
            try
            {
                return !dbContext.TitulosSectores.Any(b => b.Titulo == titulo && b.Sector == sector);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<TituloSector> GetLista(int? id)
        {
            try
            {
                return dbContext.TitulosSectores
                    .Include(ts => ts.Titulo)
                    .Include(ts => ts.Sector)
                    .OrderBy(ts => ts.Titulo.Descripcion)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public TituloSector GetObjeto(int id)
        {
            return dbContext.TitulosSectores
                                .Include(ts => ts.Titulo)
                                .Include(ts => ts.Sector)
                                .SingleOrDefault(ts => ts.TituloSectorId == id);
                                }

        public TituloSector GetObjetoXTitulo(int idtitulo, int idsector)
        {
            return dbContext.TitulosSectores
            .Include(ts => ts.Titulo)
            .Include(ts => ts.Sector)
            .Where(bf => bf.Titulo.TituloId == idtitulo && bf.Sector.SectorId == idsector)
            .SingleOrDefault();
        }

        public void Guardar(TituloSector titulosector)
        {
            try
            {
                if (titulosector.TituloSectorId > 0)
                {
                    dbContext.Entry(titulosector).State = EntityState.Modified;
                }
                else
                {
                    dbContext.TitulosSectores.Add(titulosector);
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
