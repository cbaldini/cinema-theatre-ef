using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface IButacasSectoresRepositorio
    {
        List<ButacaSector> GetLista(int? id);
        ButacaSector GetObjeto(int id);
        ButacaSector GetSectorXButaca(int id);
        void Guardar(ButacaSector butacasector);
        void Editar(ButacaSector butacasector);
        void Borrar(ButacaSector butacasector);
        bool EsUnico(Butaca butaca, Sector sector);
    }
}
