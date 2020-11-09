using CineTeatro.Common.Entities;
using CineTeatro.DataLayer.Repositories.Facades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CineTeatro.DataLayer.Repositories
{
    public class TitulosRepositorio : ITitulosRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public TitulosRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(Titulo titulo)
        {
            try
            {
                dbContext.Titulos.Remove(titulo);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Editar(Titulo titulo)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Titulo titulo)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(string descripcion)
        {
            try
            {
                return !dbContext.Titulos.Any(b => b.Descripcion == descripcion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<Titulo> GetLista(int? id)
        {
            try
            {
                return dbContext.Titulos
                    .Include(t => t.TipoDeTitulo)
                    .Include(t => t.Clasificacion)
                    .OrderBy(t => t.Descripcion)
                    .AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Titulo GetObjeto(int id)
        {
            try
            {
                return dbContext.Titulos
                    .Include(t => t.TipoDeTitulo)
                    .Include(t => t.Clasificacion)
                    .SingleOrDefault(t => t.TituloId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Titulo titulo)
        {
            try
            {
                if (titulo.TituloId > 0)
                {
                    dbContext.Entry(titulo).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Titulos.Add(titulo);
                }
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);
                throw new Exception(String.Concat(e.StackTrace, e.Message));
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner Exception");
                    Console.WriteLine(String.Concat(e.InnerException.StackTrace, e.InnerException.Message));
                }
            }

        }
    }
}
