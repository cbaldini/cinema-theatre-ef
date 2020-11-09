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
    public partial class frmFormasDeVenta : Form
    {
        public frmFormasDeVenta(IFormasDeVentaService servicioFormasDeVenta)
        {
            InitializeComponent();
            this.servicioFormasDeVenta = servicioFormasDeVenta;
        }
        private static frmFormasDeVenta instancia;

        public static frmFormasDeVenta GetInstancia(IFormasDeVentaService servicioFormasDeVenta)
        {
            if (instancia == null)
            {
                instancia = new frmFormasDeVenta(servicioFormasDeVenta);
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

        private IFormasDeVentaService servicioFormasDeVenta;

        private List<FormaDeVenta> lista;

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var formadeventa in lista)
            {
                DataGridViewRow r = ConstruirFila(formadeventa);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(FormaDeVenta formadeventa)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, formadeventa);

            return r;
        }

        private void SetearFila(DataGridViewRow r, FormaDeVenta formadeventa)
        {
            r.Cells[cmnDescripcion.Index].Value = formadeventa.Descripcion;
            r.Tag = formadeventa;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFormasDeVentaAE frm = new frmFormasDeVentaAE(servicioFormasDeVenta);
            frm.Text = "Agregar FormaDeVenta";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    FormaDeVenta ev = frm.GetFormaDeVenta();
                    servicioFormasDeVenta.Guardar(ev);
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
                    FormaDeVenta s = (FormaDeVenta)r.Tag;
                    DialogResult dr = MessageBox.Show($"Desea dar de baja el formadeventa {s.Descripcion}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {

                        servicioFormasDeVenta.Borrar(s);
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
                FormaDeVenta formadeventa = (FormaDeVenta)r.Tag;
                FormaDeVenta pAux = (FormaDeVenta)formadeventa.Clone();
                try
                {
                    frmFormasDeVentaAE frm = new frmFormasDeVentaAE(servicioFormasDeVenta);
                    formadeventa = servicioFormasDeVenta.GetObjeto(formadeventa.FormaDeVentaId);
                    frm.SetFormaDeVenta(formadeventa);
                    frm.Text = "Editar FormaDeVenta";
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        formadeventa = frm.GetFormaDeVenta();
                        servicioFormasDeVenta.Guardar(formadeventa);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        SetearFila(r, formadeventa);
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

        private void frmFormasDeVenta_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioFormasDeVenta.GetLista(null);
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
