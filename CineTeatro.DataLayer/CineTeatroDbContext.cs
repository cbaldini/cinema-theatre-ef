using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer
{
    public class CineTeatroDbContext : DbContext
    {

        public CineTeatroDbContext() : base("MiConexion")
        {
            Database.CommandTimeout = 45; //Establezco eltiempo de espera de respuesta de la BD
            Configuration.UseDatabaseNullSemantics = true; //Acelera el tiempo de respuesta de las queries
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CineTeatroDbContext>(null);//no  u s a r m i g r a c iones
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // e v i t a el borrado en cascada
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly()); //le digo que toma las configuraciones del assembly actual        }

        }
        public DbSet<Butaca> Butacas { get; set; }
        public DbSet<ButacaFuncion> ButacasFunciones { get; set; }
        public DbSet<ButacaSector> ButacasSectores { get; set; }
        public DbSet<Clasificacion> Clasificaciones { get; set; }
        public DbSet<FormaDePago> FormasDePago { get; set; }
        public DbSet<FormaDeVenta> FormasDeVenta { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<ItemVenta> ItemsVentas { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<TipoDeTitulo> TiposDeTitulos { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<TituloSector> TitulosSectores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
