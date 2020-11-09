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
    public partial class frmFunciones : Form
    {
        public frmFunciones(IFuncionesService servicioFunciones, ITitulosService servicioTitulos)
        {
            InitializeComponent();
            this.servicioFunciones = servicioFunciones;
            this.servicioTitulos = servicioTitulos;
        }
        private static frmFunciones instancia;

        public static frmFunciones GetInstancia(IFuncionesService servicioFunciones, ITitulosService servicioTitulos)
        {
            if (instancia == null)
            {
                instancia = new frmFunciones(servicioFunciones, servicioTitulos);
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

        private IFuncionesService servicioFunciones;
        private ITitulosService servicioTitulos;

        private List<Funcion> lista = new List<Funcion>();

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var funcion in lista)
            {
                DataGridViewRow r = ConstruirFila(funcion);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(Funcion funcion)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, funcion);

            return r;
        }

      

        private void SetearFila(DataGridViewRow r, Funcion funcion)
        {
            if (funcion.Titulo == null)
            {
                funcion.Titulo = servicioTitulos.GetObjeto(funcion.TituloId);
            }
            r.Cells[cmnTitulo.Index].Value = funcion.Titulo.Descripcion;
            r.Cells[cmnFecha.Index].Value = funcion.Fecha;
            r.Cells[cmnHora.Index].Value = funcion.Hora;
            r.Cells[cmnDescripcion.Index].Value = funcion.Descripcion;
            r.Cells[cmnSuspendido.Index].Value = funcion.Suspendido.ToString();
            r.Tag = funcion;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFuncionesAE frm = new frmFuncionesAE(servicioFunciones, servicioTitulos);
            frm.Text = "Agregar Titulo";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Funcion fn = frm.GetFuncion();
                    servicioFunciones.Guardar(fn);
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewRow r = ConstruirFila(fn);
                    AgregarFila(r);
                    lista.Add(fn);
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
                    Funcion f = (Funcion)r.Tag;
                    DialogResult dr = MessageBox.Show($"Desea dar de baja la funcion {f.Descripcion}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {

                        servicioFunciones.Borrar(f);
                        MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        dgvDatos.Rows.Remove(r);
                        lista.Remove(f);

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
                Funcion funcion = (Funcion)r.Tag;
                Funcion pAux = (Funcion)funcion.Clone();
                try
                {
                    frmFuncionesAE frm = new frmFuncionesAE(servicioFunciones, servicioTitulos);
                    funcion = servicioFunciones.GetObjeto(funcion.FuncionId);
                    frm.SetFuncion(funcion);
                    frm.Text = "Editar Titulo";
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        funcion = frm.GetFuncion();
                        servicioFunciones.Guardar(funcion);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        SetearFila(r, funcion);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void frmFunciones_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioFunciones.GetLista(null);
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
