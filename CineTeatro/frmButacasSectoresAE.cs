using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineTeatro.Common.Entities;
using CineTeatro.ServiceLayer.Facades;

namespace CineTeatro.Windows
{
    public partial class frmButacasSectoresAE : Form
    {
        private IButacasSectoresService servicio;
        private IButacasService butacasServicio;
        private ISectoresService sectoresServicio;


        public frmButacasSectoresAE(IButacasSectoresService servicio, IButacasService butacasServicio, ISectoresService sectoresServicio)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.butacasServicio = butacasServicio;
            this.sectoresServicio = sectoresServicio;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var listaButacas = butacasServicio.GetLista(null);
            var defaultButaca = new Butaca
            {
                Numero = 1
            };
            listaButacas.Insert(0, defaultButaca);
            cboButaca.DataSource = listaButacas;
            cboButaca.DisplayMember = "Numero";
            cboButaca.ValueMember = "ButacaId";
            cboButaca.SelectedIndex = 0;

            var listaSectores = sectoresServicio.GetLista(null);
            var defaultSector = new Sector
            {
                Descripcion = "<Selecciona sector>"
            };
            listaSectores.Insert(0, defaultSector);
            cboSector.DataSource = listaSectores;
            cboSector.DisplayMember = "Descripcion";
            cboSector.ValueMember = "SectorId";
            cboSector.SelectedIndex = 0;


            if (butacasector != null)
            {
                cboButaca.SelectedValue = butacasector.Butaca.ButacaId;
                cboSector.SelectedValue = butacasector.Sector.SectorId;
                //descripcionModificada = false;
            }
        }

        private ButacaSector butacasector;

        public ButacaSector GetButacaSector()
        {
            return butacasector;
        }

        public void SetButacaSector(ButacaSector butacasector)
        {
            this.butacasector = butacasector;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (butacasector == null)
                {
                    butacasector = new ButacaSector();
                }

                butacasector.ButacaId = butaca.ButacaId;
                butacasector.SectorId = sector.SectorId;
                this.DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboButaca.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboButaca, "Debe seleccionar una butaca");
            }
            if (cboSector.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboSector, "Debe seleccionar un sector");
            }


            //else if (descripcionModificada)
            //{
            //    if (!servicio.EsUnico(txtDescripcion.Text))
            //    {
            //        valido = false;
            //        errorProvider1.SetError(txtDescripcion, "ButacaSector repetido");
            //    }
            //}

            return valido;
        }
        private Sector sector;

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


        private Butaca butaca;

        private void cboButaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboButaca.SelectedIndex > 0)
            {
                butaca = (Butaca)cboButaca.SelectedItem;
            }
            else
            {
                butaca = null;
            }
        }

        private void frmButacasSectoresAE_Load(object sender, EventArgs e)
        {

        }
    }
}
