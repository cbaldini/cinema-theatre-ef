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
    public partial class frmFormasDeVentaAE : Form
    {
        private IFormasDeVentaService servicio;

        public frmFormasDeVentaAE(IFormasDeVentaService servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);



            if (formadeventa != null)
            {
                txtDescripcion.Text = formadeventa.Descripcion;
            }
        }

        private FormaDeVenta formadeventa;

        public FormaDeVenta GetFormaDeVenta()
        {
            return formadeventa;
        }

        public void SetFormaDeVenta(FormaDeVenta formadeventa)
        {
            this.formadeventa = formadeventa;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (formadeventa == null)
                {
                    formadeventa = new FormaDeVenta();
                }

                formadeventa.Descripcion = txtDescripcion.Text;
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

        private void frmFormasDeVentaAE_Load(object sender, EventArgs e)
        {

        }
    }
}
