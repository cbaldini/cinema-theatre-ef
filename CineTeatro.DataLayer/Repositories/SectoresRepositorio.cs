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
    public class SectoresRepositorio : ISectoresRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public SectoresRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(Sector sector)
        {
            try
            {
                dbContext.Sectores.Remove(sector);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("updating the entries"))
                {
                    throw new Exception("Registro relacionado con otras tablas - Baja denegada");
                }
                throw new Exception(e.Message);
            }
        }

        public void Editar(Sector sector)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Sector sector)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(string descripcion)
        {
            try
            {
                return !dbContext.Sectores.Any(b => b.Descripcion == descripcion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<Sector> GetLista(int? id)
        {
            try
            {
                return dbContext.Sectores.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public Sector GetObjeto(int id)
        {
            try
            {
                return dbContext.Sectores
                    .SingleOrDefault(s => s.SectorId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Sector sector)
        {
            try
            {
                if (sector.SectorId > 0)
                {
                    dbContext.Entry(sector).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Sectores.Add(sector);
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
