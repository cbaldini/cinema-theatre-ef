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
    public partial class frmTitulos : Form
    {
        public frmTitulos(ITitulosService servicioTitulos, ITiposDeTitulosService servicioTiposDeTitulos, IClasificacionesService servicioClasificaciones)
        {
            InitializeComponent();
            this.servicioTitulos = servicioTitulos;
            this.servicioTiposDeTitulos = servicioTiposDeTitulos;
            this.servicioClasificaciones = servicioClasificaciones;
        }
        private static frmTitulos instancia;

        public static frmTitulos GetInstancia(ITitulosService servicioTitulos, ITiposDeTitulosService servicioTiposDeTitulo, IClasificacionesService servicioClasificaciones)
        {
            if (instancia == null)
            {
                instancia = new frmTitulos(servicioTitulos, servicioTiposDeTitulo, servicioClasificaciones);
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

        private ITitulosService servicioTitulos;
        private ITiposDeTitulosService servicioTiposDeTitulos;
        private IClasificacionesService servicioClasificaciones;

        private List<Titulo> lista;

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var titulo in lista)
            {
                DataGridViewRow r = ConstruirFila(titulo);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(Titulo titulo)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, titulo);

            return r;
        }

        private void SetearFila(DataGridViewRow r, Titulo titulo)
        {
            if (titulo.Clasificacion == null)
            {
                titulo.Clasificacion = servicioClasificaciones.GetObjeto(titulo.ClasificacionId);
            }
            if (titulo.TipoDeTitulo == null)
            {
                titulo.TipoDeTitulo = servicioTiposDeTitulos.GetObjeto(titulo.TipoDeTituloId);
            }
            r.Cells[cmnTipoDeTitulo.Index].Value = titulo.TipoDeTitulo.Descripcion;
            r.Cells[cmnClasificacion.Index].Value = titulo.Clasificacion.Descripcion;
            r.Cells[cmnDescripcion.Index].Value = titulo.Descripcion;
            r.Tag = titulo;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTitulosAE frm = new frmTitulosAE(servicioTitulos, servicioTiposDeTitulos, servicioClasificaciones);
            frm.Text = "Agregar Titulo";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Titulo ev = frm.GetTitulo();
                    servicioTitulos.Guardar(ev);
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
                    Titulo t = (Titulo)r.Tag;
                    DialogResult dr = MessageBox.Show($"Desea dar de baja el titulo {t.Descripcion}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {

                        servicioTitulos.Borrar(t);
                        MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        dgvDatos.Rows.Remove(r);
                        lista.Remove(t);

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
                Titulo titulo = (Titulo)r.Tag;
                Titulo pAux = (Titulo)titulo.Clone();
                try
                {
                    frmTitulosAE frm = new frmTitulosAE(servicioTitulos, servicioTiposDeTitulos, servicioClasificaciones);
                    titulo = servicioTitulos.GetObjeto(titulo.TituloId);
                    frm.SetTitulo(titulo);
                    frm.Text = "Editar Titulo";
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        titulo = frm.GetTitulo();
                        servicioTitulos.Guardar(titulo);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        SetearFila(r, titulo);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void frmTitulos_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioTitulos.GetLista(null);
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
