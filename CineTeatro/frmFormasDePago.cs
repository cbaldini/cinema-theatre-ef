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
    public partial class frmFormasDePago : Form
    {
        public frmFormasDePago(IFormasDePagoService servicioFormasDePago)
        {
            InitializeComponent();
            this.servicioFormasDePago = servicioFormasDePago;
        }
        private static frmFormasDePago instancia;

        public static frmFormasDePago GetInstancia(IFormasDePagoService servicioFormasDePago)
        {
            if (instancia == null)
            {
                instancia = new frmFormasDePago(servicioFormasDePago);
                instancia.FormClosed += form_close;
            }

            return instancia;
        }

        private static void form_close(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }

        private void tsbCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private IFormasDePagoService servicioFormasDePago;

        private List<FormaDePago> lista;

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var formadepago in lista)
            {
                DataGridViewRow r = ConstruirFila(formadepago);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(FormaDePago formadepago)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, formadepago);

            return r;
        }

        private void SetearFila(DataGridViewRow r, FormaDePago formadepago)
        {
            r.Cells[cmnDescripcion.Index].Value = formadepago.Descripcion;
            r.Tag = formadepago;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFormasDePagoAE frm = new frmFormasDePagoAE(servicioFormasDePago);
            frm.Text = "Agregar FormaDePago";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    FormaDePago ev = frm.GetFormaDePago();
                    servicioFormasDePago.Guardar(ev);
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewRow r = ConstruirFila(ev);
                    AgregarFila(r);
                    lista.Add(ev);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow r = dgvDatos.SelectedRows[0];
                    FormaDePago s = (FormaDePago)r.Tag;
                    DialogResult dr = MessageBox.Show($"Desea dar de baja la forma de pago {s.Descripcion}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {

                        servicioFormasDePago.Borrar(s);
                        MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        dgvDatos.Rows.Remove(r);
                        lista.Remove(s);

                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                FormaDePago formadepago = (FormaDePago)r.Tag;
                FormaDePago pAux = (FormaDePago)formadepago.Clone();
                try
                {
                    frmFormasDePagoAE frm = new frmFormasDePagoAE(servicioFormasDePago);
                    formadepago = servicioFormasDePago.GetObjeto(formadepago.FormaDePagoId);
                    frm.SetFormaDePago(formadepago);
                    frm.Text = "Editar FormaDePago";
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        formadepago = frm.GetFormaDePago();
                        servicioFormasDePago.Guardar(formadepago);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        SetearFila(r, formadepago);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {

        }

        private void frmFormasDePago_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioFormasDePago.GetLista(null);
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void tsbCerrar_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
