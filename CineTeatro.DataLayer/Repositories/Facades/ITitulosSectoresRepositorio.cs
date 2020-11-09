using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface ITitulosSectoresRepositorio
    {
        List<TituloSector> GetLista(int? id);
        TituloSector GetObjeto(int id);
        TituloSector GetObjetoXTitulo(int idtitulo, int idsector);
        void Guardar(TituloSector butaca);
        void Editar(TituloSector titulosector);
        void Borrar(TituloSector titulosector);
        bool EsUnico(Titulo titulo, Sector sector);
    }
}
