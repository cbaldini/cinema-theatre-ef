using CineTeatro.DataLayer.Repositories.Facades;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;


namespace CineTeatro.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextTransaction tran;
        private CineTeatroDbContext context;

        public UnitOfWork(CineTeatroDbContext context)
        {
            this.context = context;
        }

        public DbContextTransaction BeginTransaction()
        {
            if (tran == null)
            {
                tran = context.Database.BeginTransaction();
            }
            return tran;
        }

        public void CommitTransaction()
        {
            if (tran != null)
            {

                tran.Commit();

            }
        }

        public void TransactionRollBack()
        {
            tran.Rollback();
        }
    }
}
