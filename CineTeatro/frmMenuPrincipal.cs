using CineTeatro.DataLayer;
using CineTeatro.DataLayer.Repositories;
using CineTeatro.DataLayer.Repositories.Facades;
using CineTeatro.ServiceLayer;
using CineTeatro.ServiceLayer.Facades;
using CineTeatro.Windows;
using System;
using System.Windows.Forms;

namespace CineTeatro
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CineTeatroDbContext dbContext = new CineTeatroDbContext();
            ITiposDeTitulosRepositorio repositorioTiposDeTitulos = new TiposDeTitulosRepositorio(dbContext);

            IClasificacionesRepositorio repositorioClasificaciones = new ClasificacionesRepositorio(dbContext);

            ITitulosRepositorio repositorioTitulos = new TitulosRepositorio(dbContext);
            ITitulosService servicioTitulos = new TitulosService(repositorioTitulos, dbContext);

            IFuncionesRepositorio repositorioFunciones = new FuncionesRepositorio(dbContext);
            IFuncionesService servicioFunciones = new FuncionesService(repositorioFunciones, dbContext);

            IFormasDePagoRepositorio repositorioFormasDePago = new FormasDePagoRepositorio(dbContext);
            IFormasDePagoService servicioFormasDePago = new FormasDePagoService(repositorioFormasDePago, dbContext);

            IFormasDeVentaRepositorio repositorioFormasDeVenta = new FormasDeVentaRepositorio(dbContext);
            IFormasDeVentaService servicioFormasDeVenta = new FormasDeVentaService(repositorioFormasDeVenta, dbContext);

            IButacasRepositorio repositorioButacas = new ButacasRepositorio(dbContext);
            IButacasService servicioButaca = new ButacasService(repositorioButacas, dbContext);

            IButacasFuncionesRepositorio repositorioButacasFunciones = new ButacasFuncionesRepositorio(dbContext);
            IButacasFuncionesService servicioButacasFunciones = new ButacasFuncionesService(repositorioButacasFunciones, dbContext);

            ISectoresRepositorio repositorioSectores = new SectoresRepositorio(dbContext);

            ITitulosSectoresRepositorio repositorioTitulosSectores = new TitulosSectoresRepositorio(dbContext);
            ITitulosSectoresService servicioTitulosSectores = new TitulosSectoresService(repositorioTitulosSectores);

            IItemsVentasRepositorio repositorioItemsVentas = new ItemsVentasRepositorio(dbContext);

            IVentasRepositorio repositorioVentas = new VentasRepositorio(dbContext);
            IVentasService servicioVentas = new VentasService(repositorioVentas);
            IItemsVentasService servicioItemsVentas = new ItemsVentasService(repositorioItemsVentas, dbContext);

            IButacasSectoresRepositorio repositorioButacasSectores = new ButacasSectoresRepositorio(dbContext);
            IButacasSectoresService servicioButacaSector = new ButacasSectoresService(repositorioButacasSectores, dbContext);

            frmVentas frm = frmVentas.GetInstancia(servicioFunciones, servicioTitulos, servicioButacasFunciones, servicioVentas, servicioItemsVentas, servicioFormasDeVenta, servicioFormasDePago, servicioButaca, servicioButacaSector, servicioTitulosSectores);
            frm.MdiParent = this;
            frm.Show();
        }

        private void titulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CineTeatroDbContext dbContext = new CineTeatroDbContext();
            ITiposDeTitulosRepositorio repositorioTiposDeTitulos = new TiposDeTitulosRepositorio(dbContext);
            IClasificacionesRepositorio repositorioClasificaciones = new ClasificacionesRepositorio(dbContext);
            ITitulosRepositorio repositorioTitulos = new TitulosRepositorio(dbContext);


            ITitulosService servicioTitulos = new TitulosService(repositorioTitulos, dbContext);
            ITiposDeTitulosService servicioTiposDeTitulos = new TiposDeTitulosService(repositorioTiposDeTitulos);
            IClasificacionesService servicioClasificaciones = new ClasificacionesService(repositorioClasificaciones, dbContext);

            frmTitulos frm = frmTitulos.GetInstancia(servicioTitulos, servicioTiposDeTitulos, servicioClasificaciones);
            frm.MdiParent = this;
            frm.Show();
        }

        private void funcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CineTeatroDbContext dbContext = new CineTeatroDbContext();
            ITiposDeTitulosRepositorio repositorioTiposDeTitulos = new TiposDeTitulosRepositorio(dbContext);
            IClasificacionesRepositorio repositorioClasificaciones = new ClasificacionesRepositorio(dbContext);
            ITitulosRepositorio repositorioTitulos = new TitulosRepositorio(dbContext);

            ITitulosService servicioTitulos = new TitulosService(repositorioTitulos, dbContext);
            ITiposDeTitulosService servicioTiposDeTitulos = new TiposDeTitulosService(repositorioTiposDeTitulos);
            IClasificacionesService servicioClasificaciones = new ClasificacionesService(repositorioClasificaciones, dbContext);

            IFuncionesRepositorio repositorioFunciones = new FuncionesRepositorio(dbContext);
            IFuncionesService servicioFunciones = new FuncionesService(repositorioFunciones, dbContext);

            frmFunciones frm = frmFunciones.GetInstancia(servicioFunciones, servicioTitulos);
            frm.MdiParent = this;
            frm.Show();
        }

        private void sectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CineTeatroDbContext dbContext = new CineTeatroDbContext();
            ISectoresRepositorio repositorioSectores = new SectoresRepositorio(dbContext);
            ISectoresService servicioSectores = new SectoresService(repositorioSectores);

            frmSectores frm = frmSectores.GetInstancia(servicioSectores);
            frm.MdiParent = this;
            frm.Show();
        }

        private void títulosYSectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CineTeatroDbContext dbContext = new CineTeatroDbContext();

            ISectoresRepositorio repositorioSectores = new SectoresRepositorio(dbContext);
            ISectoresService servicioSectores = new SectoresService(repositorioSectores);

            ITiposDeTitulosRepositorio repositorioTiposDeTitulos = new TiposDeTitulosRepositorio(dbContext);
            IClasificacionesRepositorio repositorioClasificaciones = new ClasificacionesRepositorio(dbContext);

            ITitulosRepositorio repositorioTitulos = new TitulosRepositorio(dbContext);
            ITitulosService servicioTitulos = new TitulosService(repositorioTitulos, dbContext);

            ITiposDeTitulosService servicioTiposDeTitulos = new TiposDeTitulosService(repositorioTiposDeTitulos);
            IClasificacionesService servicioClasificaciones = new ClasificacionesService(repositorioClasificaciones, dbContext);

            ITitulosSectoresRepositorio repositorioTitulosSectores = new TitulosSectoresRepositorio(dbContext);
            ITitulosSectoresService servicioTitulosSectores = new TitulosSectoresService(repositorioTitulosSectores);

            frmTitulosSectores frm = frmTitulosSectores.GetInstancia(servicioTitulosSectores, servicioTitulos, servicioSectores, dbContext);
            frm.MdiParent = this;
            frm.Show();
        }

        private void butacasSectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CineTeatroDbContext dbContext = new CineTeatroDbContext();

            IButacasRepositorio repositorioButacas = new ButacasRepositorio(dbContext);
            IButacasService servicioButacas = new ButacasService(repositorioButacas, dbContext);

            ISectoresRepositorio repositorioSectores = new SectoresRepositorio(dbContext);
            ISectoresService servicioSectores = new SectoresService(repositorioSectores);

            IButacasSectoresRepositorio repositorioButacasSectores = new ButacasSectoresRepositorio(dbContext);
            IButacasSectoresService servicioButacasSectores = new ButacasSectoresService(repositorioButacasSectores, dbContext);

            frmButacasSectores frm = frmButacasSectores.GetInstancia(servicioButacasSectores, servicioButacas, servicioSectores);
            frm.MdiParent = this;
            frm.Show();
        }

        private void formasDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CineTeatroDbContext dbContext = new CineTeatroDbContext();
            IFormasDeVentaRepositorio repositorioFormasDeVenta = new FormasDeVentaRepositorio(dbContext);
            IFormasDeVentaService servicioFormasDeVenta = new FormasDeVentaService(repositorioFormasDeVenta, dbContext);
            frmFormasDeVenta frm = frmFormasDeVenta.GetInstancia(servicioFormasDeVenta);
            frm.MdiParent = this;
            frm.Show();
        }

        private void formasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CineTeatroDbContext dbContext = new CineTeatroDbContext();
            IFormasDePagoRepositorio repositorioFormasDePago = new FormasDePagoRepositorio(dbContext);
            IFormasDePagoService servicioFormasDePago = new FormasDePagoService(repositorioFormasDePago, dbContext);
            frmFormasDePago frm = frmFormasDePago.GetInstancia(servicioFormasDePago);
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
