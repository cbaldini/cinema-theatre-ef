using CineTeatro.Common.Entities;
using CineTeatro.DataLayer;
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
    public partial class frmTitulosSectores : Form
    {
        private ITitulosSectoresService servicioTitulosSectores;
        private ITitulosService servicioTitulos;
        private ISectoresService servicioSectores;
        private readonly CineTeatroDbContext dbContext;


        public frmTitulosSectores(ITitulosSectoresService servicioTitulosSectores, ITitulosService servicioTitulos, ISectoresService servicioSectores, CineTeatroDbContext dbContext)
        {
            InitializeComponent();
            this.servicioTitulosSectores = servicioTitulosSectores;
            this.servicioTitulos = servicioTitulos;
            this.servicioSectores = servicioSectores;
            this.dbContext = dbContext;
            
        }
        private static frmTitulosSectores instancia;

        public static frmTitulosSectores GetInstancia(ITitulosSectoresService servicioTitulosSectores, ITitulosService servicioTitulos, ISectoresService servicioSectores, CineTeatroDbContext dbContext)
        {
            if (instancia == null)
            {
                instancia = new frmTitulosSectores(servicioTitulosSectores, servicioTitulos, servicioSectores, dbContext);
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


        private List<TituloSector> lista;

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var titulosector in lista)
            {
                DataGridViewRow r = ConstruirFila(titulosector);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(TituloSector titulosector)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, titulosector);

            return r;
        }

        private void SetearFila(DataGridViewRow r, TituloSector titulosector)
        {
            if(titulosector.Titulo == null)
            {
                servicioTitulos.GetObjeto(titulosector.TituloId);
            }
            r.Cells[cmnTitulo.Index].Value = titulosector.Titulo.Descripcion;
            r.Cells[cmnSector.Index].Value = titulosector.Sector.Descripcion;
            r.Cells[cmnImporte.Index].Value = titulosector.Importe.ToString();
            r.Tag = titulosector;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTitulosSectoresAE frm = new frmTitulosSectoresAE(servicioTitulosSectores, servicioTitulos, servicioSectores, dbContext);
            frm.Text = "Agregar Titulo";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TituloSector titulosector = frm.GetTituloSector();
                    servicioTitulosSectores.Guardar(titulosector);
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewRow r = ConstruirFila(titulosector);
                    AgregarFila(r);
                    lista.Add(titulosector);
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
                    TituloSector ts = (TituloSector)r.Tag;
                    DialogResult dr = MessageBox.Show($"Desea dar de baja el titulo-sector {ts.Titulo.Descripcion}, {ts.Sector.Descripcion}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {

                        servicioTitulosSectores.Borrar(ts);
                        MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        dgvDatos.Rows.Remove(r);
                        lista.Remove(ts);

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
                TituloSector titulosector = (TituloSector)r.Tag;
                TituloSector pAux = (TituloSector)titulosector.Clone();
                try
                {
                    frmTitulosSectoresAE frm = new frmTitulosSectoresAE(servicioTitulosSectores, servicioTitulos, servicioSectores, dbContext);
                    titulosector = servicioTitulosSectores.GetObjeto(titulosector.TituloSectorId);
                    frm.SetTituloSector(titulosector);
                    frm.Text = "Editar Titulo";
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        titulosector = frm.GetTituloSector();
                        servicioTitulosSectores.Guardar(titulosector);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        SetearFila(r, titulosector);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void frmTitulosSectores_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioTitulosSectores.GetLista(null);
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
