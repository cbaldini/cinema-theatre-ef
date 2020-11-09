using CineTeatro.Common.Entities;
using CineTeatro.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineTeatro.ServiceLayer.Facades;

namespace CineTeatro.Windows
{
    public partial class frmVentasAE : Form
    {
        private ITitulosService servicioTitulos;
        private ITitulosSectoresService servicioTitulosSectores;
        private IFuncionesService servicioFunciones;
        private IButacasFuncionesService servicioButacasFunciones;
        private IVentasService servicioVentas;
        private IItemsVentasService servicioItemsVentas;
        private IFormasDeVentaService servicioFormasDeVenta;
        private IFormasDePagoService servicioFormasDePago;
        private IButacasService servicioButacas;
        private IButacasSectoresService servicioButacaSector;

        public frmVentasAE(IFuncionesService servicioFunciones, ITitulosService servicioTitulos, IButacasFuncionesService servicioButacasFunciones, IVentasService servicioVentas, IItemsVentasService servicioItemsVentas, IFormasDeVentaService servicioFormasDeVenta, IFormasDePagoService servicioFormasDePago, IButacasService servicioButacas, IButacasSectoresService servicioButacaSector, ITitulosSectoresService servicioTitulosSectores)
        {
            InitializeComponent();
            this.servicioTitulos = servicioTitulos;
            this.servicioFunciones = servicioFunciones;
            this.servicioButacasFunciones = servicioButacasFunciones;
            this.servicioVentas = servicioVentas;
            this.servicioItemsVentas = servicioItemsVentas;
            this.servicioFormasDePago = servicioFormasDePago;
            this.servicioFormasDeVenta = servicioFormasDeVenta;
            this.servicioButacas = servicioButacas;
            this.servicioButacaSector = servicioButacaSector;
            this.servicioTitulosSectores = servicioTitulosSectores;
        }

        private Titulo titulo;
        private Sector sector;
        private TituloSector titulosector;
        private Funcion funcion;
        private ButacaFuncion butacafuncion;
        private ItemVenta iventa;
        private Butaca butaca;
        private ButacaSector butacasector;
        private Venta venta;
        private List<ItemVenta> listaiventa = new List<ItemVenta>();
        private List<Butaca> listabutacas = new List<Butaca>();
        private FormaDeVenta formadeventa;
        private FormaDePago formadepago;

        int nrobutaca;
        int cantidaditems = 0;
        decimal importetotal;

        public Venta GetObjeto()
        {
            return venta;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cboFuncion.Enabled = false;
            Helper.CargarComboTitulos(ref cboTitulo, servicioTitulos);
            Helper.CargarComboFormasDeVenta(ref cboFormasDeVenta, servicioFormasDeVenta);
            Helper.CargarComboFormasDePago(ref cboFormasDePago, servicioFormasDePago);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            nrobutaca = int.Parse(botonActual.Text);
            butaca = servicioButacas.GetObjeto(nrobutaca);
            //if (butacafuncion == null)
            //{
            //    butacafuncion = new ButacaFuncion();
            //}

            if (servicioButacasFunciones.EsUnico(butaca.ButacaId, funcion.FuncionId))
            {
                DialogResult msg = MessageBox.Show($"¿Ocupar butaca nro {botonActual.Text}, para el espectáculo {cboTitulo.Text}, función {cboFuncion.Text}", "Ocupar butaca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    butacafuncion = new ButacaFuncion();

                    butacafuncion.ButacaId = butaca.ButacaId;
                    butacafuncion.FuncionId = funcion.FuncionId;
                    butacafuncion.Libre = false;
                    botonActual.Enabled = false;
                    servicioButacasFunciones.Guardar(butacafuncion);
                }
                if (botonActual.Enabled == false)
                {
                    botonActual.BackColor = Color.Gray;
                }

            }
            else
            {
                butacafuncion = servicioButacasFunciones.GetObjetoButacaFuncion(butaca.ButacaId, funcion.FuncionId);
                if (butacafuncion.Libre == false)
                {

                    MessageBox.Show("Butaca ocupada");
                }
                //else
                //{
                //    DialogResult msg = MessageBox.Show($"¿Ocupar butaca nro {botonActual.Text}, para el espectáculo {cboTitulo.Text}, función {cboFuncion.Text}", "Ocupar butaca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (msg == DialogResult.Yes)
                //    {
                //        butacafuncion.Libre = false;
                //        servicioButacasFunciones.Guardar(butacafuncion);
                //        botonActual.Enabled = false;

                //    }
                //    else if (msg == DialogResult.No)
                //    {
                //        botonActual.Enabled = true;
                //    }
                //    if (botonActual.Enabled == false)
                //    {
                //        botonActual.BackColor = Color.Gray;
                //    }
                //}
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosItem())
            {
                if (iventa == null)
                {
                    iventa = new ItemVenta();
                }
                if (butaca == null)
                {
                    butaca = servicioButacas.GetObjeto(nrobutaca);
                }
                if (venta == null)
                {
                    venta = new Venta();
                }
                if (butacasector == null)
                {
                    butacasector = new ButacaSector();
                }
                if (titulosector == null)
                {
                    titulosector = new TituloSector();
                }
                funcion = servicioFunciones.GetObjeto(int.Parse(cboFuncion.SelectedValue.ToString()));
                butaca = servicioButacas.GetObjeto(nrobutaca);
                butacafuncion.FuncionId = funcion.FuncionId;
                butacafuncion.ButacaId = butaca.ButacaId;
                butacafuncion.Libre = false;
                servicioButacasFunciones.Guardar(butacafuncion);
                butacafuncion = servicioButacasFunciones.GetObjetoButacaFuncion(butaca.ButacaId, funcion.FuncionId);

                butacasector = servicioButacaSector.GetSectorXButaca(butaca.ButacaId);
                titulosector = servicioTitulosSectores.GetObjetoXTitulo(titulo.TituloId, butacasector.SectorId);

                iventa.TituloSectorId = titulosector.TituloSectorId;
                iventa.VentaId = venta.VentaId;
                iventa.ButacaFuncionId = butacafuncion.ButacaFuncionId;
                

                        //if (!listaiventa.Contains(iventa)) {
                DataGridViewRow r = ConstruirFila(iventa);
                AgregarItemVendido(iventa);
                cantidaditems++;
                importetotal = importetotal + titulosector.Importe;
                txtTotal.Text = importetotal.ToString();
                txtCantidad.Text = cantidaditems.ToString();
                        //servicioItemsVentas.Guardar(iventa);
                        //}
                txtCantidad.Text = cantidaditems.ToString();
                        //iventa = null;
                        //this.DialogResult = DialogResult.OK;
                    
                }
                
            }
        

        private void btnCancelarI_Click(object sender, EventArgs e)
        {

        }

        private void AgregarItemVendido(ItemVenta iventa)
        {
            listaiventa.Add(iventa);

        }

        private DataGridViewRow ConstruirFila(ItemVenta iventa)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, iventa);
            AgregarFila(r);
            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, object itemVenta)
        {
            try
            {
                //if (iventa.ButacaFuncion == null)
                //{
                //    iventa.ButacaFuncion = servicioButacasFunciones.GetObjeto(butacafuncion.ButacaFuncionId);
                //}
                iventa.ButacaFuncion = servicioButacasFunciones.GetObjeto(butacafuncion.ButacaFuncionId);
                r.Cells[cmnFuncion.Index].Value = iventa.ButacaFuncion.Funcion.Titulo.Descripcion;
                r.Cells[cmnDiaHora.Index].Value = iventa.ButacaFuncion.Funcion.FechaHora;
                r.Cells[cmnButaca.Index].Value = iventa.ButacaFuncion.Butaca.Numero;
                r.Cells[cmnImporte.Index].Value = titulosector.Importe.ToString();
                r.Tag = iventa;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private bool ValidarDatosItem()
        {
            bool valido = true;
            errorProvider1.Clear();
            //if (listaventa.Count == 0)
            //{
            //    valido = false;
            //    errorProvider1.SetError(dgvDatos, "Debe ingresar un ítem.");
            //}
            if (cboTitulo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTitulo, "Debe ingresar un título.");
            }
            if (cboFuncion.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboFuncion, "Debe ingresar un título.");
            }
            return valido;
        }

        private bool ValidarDatosVenta()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboFormasDeVenta.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboFormasDeVenta, "Debe ingresar una forma de venta.");
            }
            if (cboFormasDePago.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboFormasDePago, "Debe ingresar una forma de pago.");
            }
            return valido;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosVenta())
            {
                venta = new Venta();
                venta.FechaDeVenta = DateTime.Now;
                venta.DetalleDeVenta = listaiventa;
                venta.FormaDeVenta = formadeventa;
                venta.FormaDePago = formadepago;
                venta.Cantidad = cantidaditems;
                venta.Total = importetotal;
                this.DialogResult = DialogResult.OK;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void cboTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTitulo.SelectedIndex > 0)
            {
                titulo = (Titulo)cboTitulo.SelectedItem;
                Helper.CargarComboFunciones(ref cboFuncion, servicioFunciones, titulo.TituloId);
                cboFuncion.Enabled = true;
            }
            else
            {
                titulo = null;
                cboFuncion.DataSource = null;
                cboFuncion.Enabled = false;
            }


        }

        private void frmVentasAE_Load(object sender, EventArgs e)
        {
            //var listaButacasFunciones = servicioButacasFunciones.GetLista(null);
            //if (butacafuncion != null)
            //{

            //    cboTitulo.SelectedValue = titulo.TituloId;
            //    cboFuncion.SelectedValue = funcion.FuncionId;
            //    butacafuncion.Funcion.FuncionId = funcion.FuncionId;
            //    Button botonActual = (Button)sender;
            //    butacafuncion.Butaca.ButacaId = int.Parse(botonActual.Text);

            //}
            //var listaTitulosSectores = servicioTitulosSectores.GetLista(null);
            //var listaButacasSectores = servicioButacaSector.GetLista(null);
        }

        private void cboFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control control in gpbxDelantero.Controls)
            {
                control.Enabled = true;
                if (control.AccessibleDescription == "Campo")
                {
                    control.BackColor = Color.Thistle;
                }
                else if (control.AccessibleDescription == "Lateral")
                {
                    control.BackColor = Color.Pink;
                }
            }
            foreach (Control control in gpbxMedio.Controls)
            {
                control.Enabled = true;
                if (control.AccessibleDescription == "Campo")
                {
                    control.BackColor = Color.Bisque;
                }
                else if (control.AccessibleDescription == "Lateral")
                {
                    control.BackColor = Color.LightYellow;
                }
            }
            foreach (Control control in gpbxTrasero.Controls)
            {
                control.Enabled = true;
                if (control.AccessibleDescription == "Campo")
                {
                    control.BackColor = Color.LightSteelBlue;
                }
                else if (control.AccessibleDescription == "Lateral")
                {
                    control.BackColor = Color.PowderBlue;
                }
            }
            if (cboFuncion.SelectedIndex > 0)
            {
                funcion = (Funcion)cboFuncion.SelectedItem;

                if (funcion.Suspendido == false && DateTime.Parse(funcion.Fecha).Date >= DateTime.Today.Date) {

                listabutacas = servicioButacas.GetLista(null);
                foreach (var butaca in listabutacas)
                {
                    butacafuncion = servicioButacasFunciones.GetObjetoButacaFuncion(butaca.ButacaId, funcion.FuncionId);
                    if (butacafuncion != null)
                    {
                        foreach (Control control in gpbxDelantero.Controls)
                        {
                            if (control is Button)
                            {

                                if (butaca.ButacaId.ToString() == control.Text && butacafuncion.Libre == false)
                                {
                                    control.Enabled = false;
                                    control.BackColor = Color.Gray;
                                }
                            }
                        }
                        foreach (Control control in gpbxMedio.Controls)
                        {
                            if (control is Button)
                            {

                                if (butaca.ButacaId.ToString() == control.Text && butacafuncion.Libre == false)
                                {
                                    control.Enabled = false;
                                    control.BackColor = Color.Gray;
                                }
                            }
                        }
                        foreach (Control control in gpbxTrasero.Controls)
                        {
                            if (control is Button)
                            {

                                if (butaca.ButacaId.ToString() == control.Text && butacafuncion.Libre == false)
                                {
                                    control.Enabled = false;
                                    control.BackColor = Color.Gray;
                                }
                            }
                        }
                    }
                }
            }
                else if (DateTime.Parse(funcion.Fecha) < DateTime.Today)
                {
                    MessageBox.Show("La función ya no está vigente. Por favor, seleccione otra función.", "FUNCIÓN NO VIGENTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (funcion.Suspendido == true)
                {
                    MessageBox.Show("La función fue suspendida. Por favor, seleccione otra función.", "FUNCIÓN SUSPENDIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                funcion = null;
                cboFuncion.DataSource = null;
                cboFuncion.Enabled = false;
            }

        }

        private void btn2_Click(object sender, EventArgs e)
        {

        }

        private void cboFormasDeVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormasDeVenta.SelectedIndex > 0)
            {
                formadeventa = (FormaDeVenta)cboFormasDeVenta.SelectedItem;
            }
            else
            {
                formadeventa = null;
                cboFormasDeVenta.DataSource = null;
                cboFormasDeVenta.Enabled = true;
            }
        }

        private void cboFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormasDePago.SelectedIndex > 0)
            {
                formadepago = (FormaDePago)cboFormasDePago.SelectedItem;
            }
            else
            {
                funcion = null;
                cboFormasDePago.DataSource = null;
                cboFormasDePago.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}
