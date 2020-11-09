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
    public partial class frmSectores : Form
    {
        public frmSectores(ISectoresService servicioSectores)
        {
            InitializeComponent();
            this.servicioSectores = servicioSectores;
        }
        private static frmSectores instancia;

        public static frmSectores GetInstancia(ISectoresService servicioSectores)
        {
            if (instancia == null)
            {
                instancia = new frmSectores(servicioSectores);
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

        private ISectoresService servicioSectores;

        private List<Sector> lista;

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var sector in lista)
            {
                DataGridViewRow r = ConstruirFila(sector);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(Sector sector)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, sector);

            return r;
        }

        private void SetearFila(DataGridViewRow r, Sector sector)
        {
            r.Cells[cmnDescripcion.Index].Value = sector.Descripcion;
            r.Tag = sector;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmSectoresAE frm = new frmSectoresAE(servicioSectores);
            frm.Text = "Agregar Sector";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Sector ev = frm.GetSector();
                    servicioSectores.Guardar(ev);
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
                    Sector s = (Sector)r.Tag;
                    DialogResult dr = MessageBox.Show($"Desea dar de baja el sector {s.Descripcion}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {

                        servicioSectores.Borrar(s);
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
                Sector sector = (Sector)r.Tag;
                Sector pAux = (Sector)sector.Clone();
                try
                {
                    frmSectoresAE frm = new frmSectoresAE(servicioSectores);
                    sector = servicioSectores.GetObjeto(sector.SectorId);
                    frm.SetSector(sector);
                    frm.Text = "Editar Sector";
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        sector = frm.GetSector();
                        servicioSectores.Guardar(sector);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        SetearFila(r, sector);
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
            this.Close();
        }

        private void frmSectores_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioSectores.GetLista(null);
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
    }
}
