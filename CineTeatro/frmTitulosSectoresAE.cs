using CineTeatro.Common.Entities;
using CineTeatro.DataLayer;
using CineTeatro.ServiceLayer.Facades;
using System;
using System.Windows.Forms;

namespace CineTeatro.Windows
{
    public partial class frmTitulosSectoresAE : Form
    {
        protected readonly CineTeatroDbContext dbContext;
        private ITitulosSectoresService servicio;
        private ITitulosService servicioTitulo;
        private ISectoresService servicioSector;


        public frmTitulosSectoresAE(ITitulosSectoresService servicio, ITitulosService servicioTitulo, ISectoresService servicioSector, CineTeatroDbContext dbContext)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioTitulo = servicioTitulo;
            this.servicioSector = servicioSector;
            this.dbContext = dbContext;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var listaTitulos = servicioTitulo.GetLista(null);
            var defaultTitulo = new Titulo
            {
                Descripcion = "<Seleccione titulo>"
            };
            listaTitulos.Insert(0, defaultTitulo);
            cboTitulo.DataSource = listaTitulos;
            cboTitulo.DisplayMember = "Descripcion";
            cboTitulo.ValueMember = "TituloId";
            cboTitulo.SelectedIndex = 0;

            var listaSectores = servicioSector.GetLista(null);
            var defaultSector = new Sector
            {
                Descripcion = "<Seleccione sector>"
            };
            listaSectores.Insert(0, defaultSector);
            cboSector.DataSource = listaSectores;
            cboSector.DisplayMember = "Descripcion";
            cboSector.ValueMember = "SectorId";
            cboSector.SelectedIndex = 0;
            if (titulosector != null)
            {
                txtImporte.Text = titulosector.Importe.ToString();
                cboSector.SelectedValue = titulosector.Sector.SectorId;
                cboTitulo.SelectedValue = titulosector.Titulo.TituloId;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (titulosector == null)
                {
                    titulosector = new TituloSector();
                }

                try
                {
                    titulosector.TituloId = titulo.TituloId;
                    titulosector.SectorId = sector.SectorId;
                    titulosector.Importe = decimal.Parse(txtImporte.Text);

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboTitulo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTitulo, "Debe seleccionar un titulo");
            }
            if (cboSector.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboSector, "Debe seleccionar un sector");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private TituloSector titulosector;

        public TituloSector GetTituloSector()
        {
            return titulosector;
        }

        public void SetTituloSector(TituloSector titulosector)
        {
            this.titulosector = titulosector;
        }

        private Titulo titulo;


        private void cboTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTitulo.SelectedIndex > 0)
            {
                titulo = (Titulo)cboTitulo.SelectedItem;
            }
            else
            {
                titulo = null;
            }
        }

        private void frmTitulosSectoresAE_Load(object sender, EventArgs e)
        {
            
        }

        private Sector sector;
        private ITitulosSectoresService servicioTitulosSectores;
        private ITitulosService servicioTitulos;
        private ISectoresService servicioSectores;

        private void cboSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSector.SelectedIndex > 0)
            {
                sector = (Sector)cboSector.SelectedItem;
            }
            else
            {
                sector = null;
            }
        }
    }
}
