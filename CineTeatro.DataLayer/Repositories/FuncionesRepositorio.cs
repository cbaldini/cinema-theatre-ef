using CineTeatro.Common.Entities;
using CineTeatro.DataLayer.Repositories.Facades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CineTeatro.DataLayer.Repositories
{
    public class FuncionesRepositorio : IFuncionesRepositorio
    {
        private readonly CineTeatroDbContext dbContext;

        public FuncionesRepositorio(CineTeatroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Borrar(Funcion funcion)
        {
            try
            {
                dbContext.Funciones.Remove(funcion);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("ObjectStateManager"))
                {
                    throw new Exception("Registro relacionado con otras tablas - Baja denegada");
                }
                throw new Exception(e.Message);
            }
        }

        public void Editar(Funcion funcion)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Funcion funcion)
        {
            throw new NotImplementedException();
        }

        public bool EsUnico(string descripcion)
        {
            try
            {
                return !dbContext.Funciones.Any(b => b.Descripcion == descripcion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public List<Funcion> GetFuncionXTitulo(int tituloid)
        {
            try
            {
                return dbContext.Funciones
                    //.Include(f => f.Titulo)
                    .Where(f => f.TituloId == tituloid)
                    .OrderBy(f => f.Descripcion)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Funcion> GetLista(int? id)
        {
            try
            {
                return dbContext.Funciones
                    //.Include(f => f.Titulo)
                    .OrderBy(f => f.Descripcion)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public Funcion GetObjeto(int id)
        {
            return dbContext.Funciones
                //.Include(f => f.Titulo)
                .SingleOrDefault(f => f.FuncionId == id);
        }

        public void Guardar(Funcion funcion)
        {
            try
            {
                if (funcion.FuncionId > 0)
                {
                    dbContext.Entry(funcion).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Funciones.Add(funcion);
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
