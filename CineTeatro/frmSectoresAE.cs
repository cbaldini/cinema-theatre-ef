using CineTeatro.Common.Entities;
using CineTeatro.ServiceLayer.Facades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineTeatro.Windows
{
    public partial class frmSectoresAE : Form
    {
        private ISectoresService servicio;

        public frmSectoresAE(ISectoresService servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);



            if (sector != null)
            {
                txtDescripcion.Text = sector.Descripcion;
            }
        }

        private Sector sector;

        public Sector GetSector()
        {
            return sector;
        }

        public void SetSector(Sector sector)
        {
            this.sector = sector;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (sector == null)
                {
                    sector = new Sector();
                }

                sector.Descripcion = txtDescripcion.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();


            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Debe ingresar una descripcion");
            }

            return valido;
        }

        private void frmSectoresAE_Load(object sender, EventArgs e)
        {

        }
    }
}
