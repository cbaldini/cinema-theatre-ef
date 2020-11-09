using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer.Repositories.Facades
{
    public interface IUnitOfWork
    {
        //SqlConnection CrearConexion();
        //void Open();
        void CommitTransaction();
        DbContextTransaction BeginTransaction();
        void TransactionRollBack();
    }
}
