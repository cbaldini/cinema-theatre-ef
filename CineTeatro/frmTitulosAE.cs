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
    public partial class frmTitulosAE : Form
    {
        private ITitulosService servicio;
        private ITiposDeTitulosService servicioTiposDeTitulos;
        private IClasificacionesService servicioClasificaciones;

        public frmTitulosAE(ITitulosService servicio, ITiposDeTitulosService servicioTiposDeTitulos, IClasificacionesService servicioClasificaciones)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioTiposDeTitulos = servicioTiposDeTitulos;
            this.servicioClasificaciones = servicioClasificaciones;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            toolTip1.SetToolTip(btnAgregarTipoDeTitulo, "Presione para agregar un tipo de titulo");
            var listaTiposDeTitulos = servicioTiposDeTitulos.GetLista(null);
            var defaultTipoDeTitulo = new TipoDeTitulo
            {
                Descripcion = "<Seleccione tipo de titulo>"
            };
            listaTiposDeTitulos.Insert(0, defaultTipoDeTitulo);
            cboTipoDeTitulo.DataSource = listaTiposDeTitulos;
            cboTipoDeTitulo.DisplayMember = "Descripcion";
            cboTipoDeTitulo.ValueMember = "TipoDeTituloId";
            cboTipoDeTitulo.SelectedIndex = 0;

            toolTip1.SetToolTip(btnAgregarClasificacion, "Presione para agregar una clasificacion");
            var listaClasificaciones = servicioClasificaciones.GetLista(null);
            var defaultClasificacion = new Clasificacion
            {
                Descripcion = "<Seleccione tipode titulo>"
            };
            listaClasificaciones.Insert(0, defaultClasificacion);
            cboClasificacion.DataSource = listaClasificaciones;
            cboClasificacion.DisplayMember = "Descripcion";
            cboClasificacion.ValueMember = "ClasificacionId";
            cboClasificacion.SelectedIndex = 0;



            if (titulo != null)
            {
                txtDescripcion.Text = titulo.Descripcion;
                cboTipoDeTitulo.SelectedValue = titulo.TipoDeTitulo.TipoDeTituloId;
                cboClasificacion.SelectedValue = titulo.Clasificacion.ClasificacionId;
                //descripcionModificada = false;
            }
        }

        private Titulo titulo;

        public Titulo GetTitulo()
        {
            return titulo;
        }

        public void SetTitulo(Titulo titulo)
        {
            this.titulo = titulo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (titulo == null)
                {
                    titulo = new Titulo();
                }

                titulo.Descripcion = txtDescripcion.Text;
                titulo.TipoDeTituloId = tipodetitulo.TipoDeTituloId;
                titulo.ClasificacionId = clasificacion.ClasificacionId;
                this.DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboClasificacion.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboClasificacion, "Debe seleccionar una clasificacion");
            }
            if (cboTipoDeTitulo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoDeTitulo, "Debe seleccionar un tipo de titulo");
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Debe ingresar una descripcion");
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
        private Clasificacion clasificacion;

        private void cboClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClasificacion.SelectedIndex > 0)
            {
                clasificacion = (Clasificacion)cboClasificacion.SelectedItem;
            }
            else
            {
                clasificacion = null;
            }
        }

        //private void btnAgregarClasificacion_Click_1(object sender, EventArgs e)
        //{
        //frmClasificacionesAE frm = new frmClasificacionesAE(servicioClasificaciones);
        //frm.Text = "Agregar una clasificacion";
        //DialogResult dr = frm.ShowDialog(this);
        //if (dr == DialogResult.OK)
        //{
        //    try
        //    {
        //        //Clasificacion p = frm.GetClasificacion();
        //        servicioClasificaciones.Guardar(p);
        //        MessageBox.Show("Nueva clasificacion agregada", "Mensaje");
        //        //
        //        cboClasificacion.DataSource = null;
        //        var listaClasificaciones = servicioClasificaciones.GetLista(null);
        //        var defaultClasificacion = new Clasificacion
        //        {
        //            Descripcion = "<Seleccione clasificacion>"
        //        };
        //        listaClasificaciones.Insert(0, defaultClasificacion);
        //        cboClasificacion.DataSource = listaClasificaciones;
        //        cboClasificacion.DisplayMember = "Descripcion";
        //        cboClasificacion.ValueMember = "ClasificacionId";
        //        cboClasificacion.SelectedIndex = 0;



        //}
        //catch (Exception ex)
        //{

        //    MessageBox.Show(ex.Message, "Error");

        //}
        //    }
        //}

        //private bool descripcionModificada;

        private void btnAgregarTipoDeTitulo_Click(object sender, EventArgs e)
        {
            //frmTipoDeTitulosAE frm = new frmTipoDeTitulosAE(servicioTiposDeTitulos);
            //frm.Text = "Agregar una tipo detitulo";
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.OK)
            //{
            //    try
            //    {
            //        TipoDeTitulo t = frm.GetTipoTitulo();
            //        servicioTiposDeTitulos.Guardar(t);
            //        MessageBox.Show("Nueva tipodetitulo agregada", "Mensaje");
            //        cboTipoDeTitulo.DataSource = null;
            //        var listaTipoDeTitulos = servicioTiposDeTitulos.GetLista();
            //        var defaultTipoDeTitulo = new TipoDeTitulo
            //        {
            //            Descripcion = "<Seleccione tipo de titulo>"
            //        };
            //        listaTipoDeTitulos.Insert(0, defaultTipoDeTitulo);
            //        cboTipoDeTitulo.DataSource = listaTipoDeTitulos;
            //        cboTipoDeTitulo.DisplayMember = "Descripcion";
            //        cboTipoDeTitulo.ValueMember = "TipoDeTituloId";
            //        cboTipoDeTitulo.SelectedIndex = 0;
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message, "Error");

            //    }
        }
        private TipoDeTitulo tipodetitulo;

        private void cboTipoDeTitulo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboTipoDeTitulo.SelectedIndex > 0)
            {
                tipodetitulo = (TipoDeTitulo)cboTipoDeTitulo.SelectedItem;
            }
            else
            {
                tipodetitulo = null;
            }
        }

        private void frmTitulosAE_Load(object sender, EventArgs e)
        {

        }

    }
}
