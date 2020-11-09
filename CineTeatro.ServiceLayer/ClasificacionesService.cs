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
    public class ClasificacionesService : IClasificacionesService
    {
        private IClasificacionesRepositorio repositorioClasificaciones;
        private readonly CineTeatroDbContext dbContext;


        public ClasificacionesService(IClasificacionesRepositorio repositorioClasificaciones, CineTeatroDbContext dbContext)
        {
            this.repositorioClasificaciones = repositorioClasificaciones;
            this.dbContext = dbContext;
        }

        public void Borrar(Clasificacion clasificacion)
        {
            repositorioClasificaciones.Borrar(clasificacion);
        }

        public void Editar(Clasificacion clasificacion)
        {
            repositorioClasificaciones.Editar(clasificacion);
        }

        public bool EsUnico(string descripcion)
        {
            return repositorioClasificaciones.EsUnico(descripcion);
        }

        public List<Clasificacion> GetLista(int? id)
        {
            return repositorioClasificaciones.GetLista(id);
        }

        public Clasificacion GetObjeto(int id)
        {
            return repositorioClasificaciones.GetObjeto(id);
        }

        public void Guardar(Clasificacion clasificacion)
        {
            repositorioClasificaciones.Guardar(clasificacion);
        }
    }
}
