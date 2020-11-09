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
    public partial class frmFormasDePagoAE : Form
    {
        private IFormasDePagoService servicio;

        public frmFormasDePagoAE(IFormasDePagoService servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);



            if (formadepago != null)
            {
                txtDescripcion.Text = formadepago.Descripcion;
            }
        }

        private FormaDePago formadepago;

        public FormaDePago GetFormaDePago()
        {
            return formadepago;
        }

        public void SetFormaDePago(FormaDePago formadepago)
        {
            this.formadepago = formadepago;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (formadepago == null)
                {
                    formadepago = new FormaDePago();
                }

                formadepago.Descripcion = txtDescripcion.Text;
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

        private void frmFormasDePagoAE_Load(object sender, EventArgs e)
        {

        }
    }
}
