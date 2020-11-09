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
    public class TitulosService : ITitulosService
    {
        private ITitulosRepositorio repositorioTitulos;
        private readonly CineTeatroDbContext dbContext;
        public TitulosService(ITitulosRepositorio repositorioTitulos, CineTeatroDbContext dbContext)
        {
            this.repositorioTitulos = repositorioTitulos;
        }

        public void Borrar(Titulo titulo)
        {
            repositorioTitulos.Borrar(titulo);
        }

        public void Editar(Titulo titulo)
        {
            repositorioTitulos.Editar(titulo);
        }

        public bool EsUnico(string descripcion)
        {
            return repositorioTitulos.EsUnico(descripcion);
        }

        public List<Titulo> GetLista(int? id)
        {
            return repositorioTitulos.GetLista(id);
        }

        public Titulo GetObjeto(int id)
        {
            return repositorioTitulos.GetObjeto(id);
        }

        public void Guardar(Titulo titulo)
        {
            repositorioTitulos.Guardar(titulo);
        }
    }
}
