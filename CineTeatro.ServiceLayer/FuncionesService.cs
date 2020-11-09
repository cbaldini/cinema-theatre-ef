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
    public class FuncionesService : IFuncionesService
    {
        private IFuncionesRepositorio repositorioFunciones;
        private readonly CineTeatroDbContext dbContext;

        public FuncionesService(IFuncionesRepositorio repositorioFunciones, CineTeatroDbContext dbContext)
        {
            this.repositorioFunciones = repositorioFunciones;
            this.dbContext = dbContext;
        }
        public void Borrar(Funcion funcion)
        {
            repositorioFunciones.Borrar(funcion);
        }

        public void Editar(Funcion funcion)
        {
            repositorioFunciones.Editar(funcion);
        }

        public bool EsUnico(string descripcion)
        {
            return repositorioFunciones.EsUnico(descripcion);
        }

        public List<Funcion> GetFuncionXTitulo(int tituloid)
        {
            return repositorioFunciones.GetFuncionXTitulo(tituloid);
        }

        public List<Funcion> GetLista(int? id)
        {
            return repositorioFunciones.GetLista(id);
        }

        public Funcion GetObjeto(int id)
        {
            return repositorioFunciones.GetObjeto(id);
        }

        public void Guardar(Funcion funcion)
        {
            repositorioFunciones.Guardar(funcion);
        }
    }
}
