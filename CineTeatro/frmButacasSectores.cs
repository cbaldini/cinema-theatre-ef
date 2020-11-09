using CineTeatro.Common.Entities;
using CineTeatro.ServiceLayer;
using CineTeatro.ServiceLayer.Facades;
using CineTeatro.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineTeatro
{
    public partial class frmButacasSectores : Form
    {
        private IButacasSectoresService servicioButacasSectores;
        private IButacasService servicioButacas;
        private ISectoresService servicioSectores;

        public frmButacasSectores(IButacasSectoresService servicioButacasSectores, IButacasService servicioButacas, ISectoresService servicioSectores)
        {
            InitializeComponent();
            this.servicioButacasSectores = servicioButacasSectores;
            this.servicioButacas = servicioButacas;
            this.servicioSectores = servicioSectores;
        }
        private static frmButacasSectores instancia;

        public static frmButacasSectores GetInstancia(IButacasSectoresService servicioButacasSectores, IButacasService servicioButacas, ISectoresService servicioSectores)
        {
            if (instancia == null)
            {
                instancia = new frmButacasSectores(servicioButacasSectores, servicioButacas, servicioSectores);
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


        private List<ButacaSector> lista;

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var butacasector in lista)
            {
                DataGridViewRow r = ConstruirFila(butacasector);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(ButacaSector butacasector)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, butacasector);

            return r;
        }

        private void SetearFila(DataGridViewRow r, ButacaSector butacasector)
        {
            r.Cells[cmnButaca.Index].Value = butacasector.Butaca.Numero.ToString();
            r.Cells[cmnSector.Index].Value = butacasector.Sector.Descripcion;
            r.Tag = butacasector;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmButacasSectoresAE frm = new frmButacasSectoresAE(servicioButacasSectores, servicioButacas, servicioSectores);
            frm.Text = "Agregar Butaca";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ButacaSector butacasector = frm.GetButacaSector();
                    servicioButacasSectores.Guardar(butacasector);
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewRow r = ConstruirFila(butacasector);
                    AgregarFila(r);
                    lista.Add(butacasector);
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
                    ButacaSector bs = (ButacaSector)r.Tag;
                    DialogResult dr = MessageBox.Show($"Desea dar de baja el butaca-sector {bs.Butaca.Numero}, {bs.Sector.Descripcion}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {

                        servicioButacasSectores.Borrar(bs);
                        MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        dgvDatos.Rows.Remove(r);
                        lista.Remove(bs);

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
                ButacaSector butacasector = (ButacaSector)r.Tag;
                ButacaSector pAux = (ButacaSector)butacasector.Clone();
                try
                {
                    frmButacasSectoresAE frm = new frmButacasSectoresAE(servicioButacasSectores, servicioButacas, servicioSectores);
                    butacasector = servicioButacasSectores.GetObjeto(butacasector.ButacaSectorId);
                    frm.SetButacaSector(butacasector);
                    frm.Text = "Editar Butaca";
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        butacasector = frm.GetButacaSector();
                        servicioButacasSectores.Guardar(butacasector);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        SetearFila(r, butacasector);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void frmButacasSectores_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioButacasSectores.GetLista(null);
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void tsbConstruir_Click(object sender, EventArgs e)
        {

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
