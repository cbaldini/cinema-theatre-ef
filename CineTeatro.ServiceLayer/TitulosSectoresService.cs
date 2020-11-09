using CineTeatro.ServiceLayer.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineTeatro.Common.Entities;
using System.Data.SqlClient;
using CineTeatro.DataLayer.Repositories.Facades;

namespace CineTeatro.ServiceLayer
{
    public class TitulosSectoresService : ITitulosSectoresService
    {
        private ITitulosSectoresRepositorio repositorioTitulosSectores;

        public TitulosSectoresService(ITitulosSectoresRepositorio repositorioTitulosSectores)
        {
            this.repositorioTitulosSectores = repositorioTitulosSectores;
        }
        public void Borrar(TituloSector titulosector)
        {
            repositorioTitulosSectores.Borrar(titulosector);
        }

        public void Editar(TituloSector titulosector)
        {
            repositorioTitulosSectores.Editar(titulosector);
        }

        public bool EsUnico(Titulo titulo, Sector sector)
        {
            return repositorioTitulosSectores.EsUnico(titulo, sector);
        }

        public List<TituloSector> GetLista(int? id)
        {
            return repositorioTitulosSectores.GetLista(id);
        }

        public TituloSector GetObjeto(int id)
        {
            return repositorioTitulosSectores.GetObjeto(id);
        }

        public TituloSector GetObjetoXTitulo(int idtitulo, int idsector)
        {
            return repositorioTitulosSectores.GetObjetoXTitulo(idtitulo, idsector);
        }

        public void Guardar(TituloSector titulosector)
        {
            repositorioTitulosSectores.Guardar(titulosector);
        }
    }
}
