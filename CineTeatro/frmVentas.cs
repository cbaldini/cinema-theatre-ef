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
    public partial class frmVentas : Form
    {
        private IVentasService servicioVentas;
        private ITitulosService servicioTitulos;
        private ITitulosSectoresService servicioTitulosSectores;
        private IFuncionesService servicioFunciones;
        private IButacasFuncionesService servicioButacasFunciones;
        private IItemsVentasService servicioItemsVentas;
        private IFormasDeVentaService servicioFormasDeVenta;
        private IFormasDePagoService servicioFormasDePago;
        private IButacasService servicioButacas;
        private IButacasSectoresService servicioButacaSector;

        public frmVentas(IFuncionesService servicioFunciones, ITitulosService servicioTitulos, IButacasFuncionesService servicioButacasFunciones, IVentasService servicioVentas, IItemsVentasService servicioItemsVentas, IFormasDeVentaService servicioFormasDeVenta, IFormasDePagoService servicioFormasDePago, IButacasService servicioButacas, IButacasSectoresService servicioButacaSector, ITitulosSectoresService servicioTitulosSectores)
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
        private static frmVentas instancia;

        public static frmVentas GetInstancia(IFuncionesService servicioFunciones, ITitulosService servicioTitulos, IButacasFuncionesService servicioButacasFunciones, IVentasService servicioVentas, IItemsVentasService servicioItemsVentas, IFormasDeVentaService servicioFormasDeVenta, IFormasDePagoService servicioFormasDePago, IButacasService servicioButacas, IButacasSectoresService servicioButacaSector, ITitulosSectoresService servicioTitulosSectores)
        {
            if (instancia == null)
            {
                instancia = new frmVentas(servicioFunciones,servicioTitulos, servicioButacasFunciones, servicioVentas, servicioItemsVentas, servicioFormasDeVenta, servicioFormasDePago, servicioButacas, servicioButacaSector, servicioTitulosSectores);
                instancia.FormClosed += form_close;
            }

            return instancia;
        }

        private static void form_close(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }

        private void tsbCerrar_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }


        private List<Venta> lista;

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var venta in lista)
            {
                DataGridViewRow r = ConstruirFila(venta);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(Venta venta)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, venta);

            return r;
        }

        private void SetearFila(DataGridViewRow r, Venta venta)
        {
            if (venta.FechaDeVenta == null)
            {
                MessageBox.Show("Fecha de venta es null");
            }
            r.Cells[cmnNroVenta.Index].Value = venta.VentaId.ToString();
            r.Cells[cmnFechaDeVenta.Index].Value = venta.FechaDeVenta.ToShortDateString();
            r.Cells[cmnFormaDeVenta.Index].Value = venta.FormaDeVenta.Descripcion.ToString();
            r.Cells[cmnFormaDePago.Index].Value = venta.FormaDePago.Descripcion.ToString();
            r.Cells[cmnCantidad.Index].Value = venta.Cantidad;
            r.Cells[cmnTotal.Index].Value = venta.Total;
            r.Tag = venta;
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            frmVentasAE frm = new frmVentasAE(servicioFunciones, servicioTitulos, servicioButacasFunciones, servicioVentas, servicioItemsVentas, servicioFormasDeVenta, servicioFormasDePago, servicioButacas, servicioButacaSector, servicioTitulosSectores);
            frm.Text = "Agregar Venta";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Venta venta = frm.GetObjeto();
                    servicioVentas.Guardar(venta);
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewRow r = ConstruirFila(venta);
                    AgregarFila(r);
                    lista.Add(venta);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        //private void tsbBorrar_Click(object sender, EventArgs e)
        //{
        //    if (dgvDatos.SelectedRows.Count > 0)
        //    {
        //        try
        //        {
        //            DataGridViewRow r = dgvDatos.SelectedRows[0];
        //            Venta s = (Venta)r.Tag;
        //            DialogResult dr = MessageBox.Show($"Desea dar de baja la venta del {s.FechaDeVenta}?",
        //                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        //            if (dr == DialogResult.Yes)
        //            {

        //                servicioVentas.Borrar(s.VentaId);
        //                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK,
        //                    MessageBoxIcon.Information);
        //                dgvDatos.Rows.Remove(r);
        //                lista.Remove(s);

        //            }

        //        }
        //        catch (Exception exception)
        //        {
        //            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);

        //        }
        //    }
        //}

        //private void tsbEditar_Click(object sender, EventArgs e)
        //{
        //    if (dgvDatos.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow r = dgvDatos.SelectedRows[0];
        //        Venta venta = (Venta)r.Tag;
        //        Venta pAux = (Venta)venta.Clone();
        //        try
        //        {
        //            frmVentasAE frm = new frmVentasAE(servicioVentas);
        //            venta = servicioVentas.GetObjeto(venta.VentaId);
        //            frm.SetVenta(venta);
        //            frm.Text = "Editar Venta";
        //            DialogResult dr = frm.ShowDialog(this);
        //            if (dr == DialogResult.OK)
        //            {
        //                venta = frm.GetVenta();
        //                servicioVentas.Guardar(venta);
        //                MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
        //                    MessageBoxIcon.Information);
        //                SetearFila(r, venta);
        //            }

        //        }
        //        catch (Exception exception)
        //        {
        //            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //        }
        //    }

        //}

        private void tsbCerrar_Click(object sender, EventArgs e)
        {

        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioVentas.GetLista(null);
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {

            frmItemsVentas frm = new frmItemsVentas(servicioFunciones, servicioTitulos, servicioButacasFunciones, servicioVentas, servicioItemsVentas, servicioFormasDeVenta, servicioFormasDePago, servicioButacas, servicioButacaSector, servicioTitulosSectores);
            Venta venta = frm.GetObjeto();
            frm.Text = "Detalles de venta";
            DialogResult dr = frm.ShowDialog(this);
        }
    }
}
