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
    public partial class frmFuncionesAE : Form
    {
        private IFuncionesService servicio;
        private ITitulosService servicioTitulo;

        public frmFuncionesAE(IFuncionesService servicio, ITitulosService servicioTitulo)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioTitulo = servicioTitulo;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var listaTitulos = servicioTitulo.GetLista(null);
            var defaultTipoDeTitulo = new Titulo
            {
                Descripcion = "<Seleccione titulo>"
            };
            listaTitulos.Insert(0, defaultTipoDeTitulo);
            cboTitulo.DataSource = listaTitulos;
            cboTitulo.DisplayMember = "Descripcion";
            cboTitulo.ValueMember = "TituloId";
            cboTitulo.SelectedIndex = 0;
            if (funcion != null)
            {
                txtDescripcion.Text = funcion.Descripcion;
                cboTitulo.SelectedValue = funcion.Titulo.TituloId;
                dtpFecha.Value = DateTime.Parse(funcion.Fecha);
                dtpHora.Value = DateTime.Parse(funcion.Hora);
                if (funcion.Suspendido == true)
                {
                    chkSuspendido.Checked = true;
                }
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (funcion == null)
                {
                    funcion = new Funcion();
                }
                dtpFecha.Format = DateTimePickerFormat.Short;
                dtpHora.Format = DateTimePickerFormat.Time;
                funcion.Descripcion = txtDescripcion.Text;
                funcion.TituloId = titulo.TituloId;
                funcion.Fecha = dtpFecha.Value.ToShortDateString();
                funcion.Hora = dtpHora.Value.ToShortTimeString();
                if (chkSuspendido.Checked)
                {
                    funcion.Suspendido = true;

                }
                else
                {
                    funcion.Suspendido = false;
                }
                this.DialogResult = DialogResult.OK;
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
            if (!dtpFecha.Checked)
            {
                valido = false;
                errorProvider1.SetError(dtpFecha, "Debe seleccionar una fecha");
            }


            //else if (descripcionModificada)
            //{
            //    if (!servicio.EsUnico(txtDescripcion.Text))
            //    {
            //        valido = false;
            //        errorProvider1.SetError(txtDescripcion, "Titulo repetido");
            //    }
            //}

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private Funcion funcion;

        public Funcion GetFuncion()
        {
            return funcion;
        }

        public void SetFuncion(Funcion funcion)
        {
            this.funcion = funcion;
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

        private void frmFuncionesAE_Load(object sender, EventArgs e)
        {

        }

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmFuncionesAE_Load_1(object sender, EventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
