using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface IButacasFuncionesRepositorio
    {
        List<ButacaFuncion> GetLista(int? id);
        ButacaFuncion GetObjeto(int id);
        ButacaFuncion GetObjetoButacaFuncion(int idbutaca, int idfuncion);
        void Guardar(ButacaFuncion butacafuncion);
        void Borrar(ButacaFuncion butacafuncion);
        bool EsUnico(int butacaid, int idfuncionid);
    }
}
