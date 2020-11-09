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
    public partial class frmItemsVentas : Form
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

        public frmItemsVentas(IFuncionesService servicioFunciones, ITitulosService servicioTitulos, IButacasFuncionesService servicioButacasFunciones, IVentasService servicioVentas, IItemsVentasService servicioItemsVentas, IFormasDeVentaService servicioFormasDeVenta, IFormasDePagoService servicioFormasDePago, IButacasService servicioButacas, IButacasSectoresService servicioButacaSector, ITitulosSectoresService servicioTitulosSectores)
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
        private static frmItemsVentas instancia;
        private Venta venta;

        public Venta GetObjeto()
        {
            return venta;
        }

        public static frmItemsVentas GetInstancia(IFuncionesService servicioFunciones, ITitulosService servicioTitulos, IButacasFuncionesService servicioButacasFunciones, IVentasService servicioVentas, IItemsVentasService servicioItemsVentas, IFormasDeVentaService servicioFormasDeVenta, IFormasDePagoService servicioFormasDePago, IButacasService servicioButacas, IButacasSectoresService servicioButacaSector, ITitulosSectoresService servicioTitulosSectores)
        {
            if (instancia == null)
            {
                instancia = new frmItemsVentas(servicioFunciones, servicioTitulos, servicioButacasFunciones, servicioVentas, servicioItemsVentas, servicioFormasDeVenta, servicioFormasDePago, servicioButacas, servicioButacaSector, servicioTitulosSectores);
                instancia.FormClosed += form_close;
            }

            return instancia;
        }

        private static void form_close(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }

        private List<ItemVenta> lista;


        private void frmItemsVentas_Load(object sender, EventArgs e)
        {
            {
                this.Dock = DockStyle.Fill;
                try
                {
                    lista = servicioItemsVentas.GetListaXVenta(venta.VentaId);
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var item in lista)
            {
                DataGridViewRow r = ConstruirFila(item);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(ItemVenta item)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, item);

            return r;
        }

        private void SetearFila(DataGridViewRow r, ItemVenta item)
        {
            r.Cells[cmnNroVenta.Index].Value = item.Venta.VentaId.ToString();
            r.Cells[cmnFechaDeVenta.Index].Value = item.Venta.FechaDeVenta.ToShortDateString();
            r.Cells[cmnButaca.Index].Value = item.Venta.FormaDeVenta.Descripcion.ToString();
            r.Cells[cmnSector.Index].Value = item.Venta.Cantidad.ToString();
            r.Cells[cmnTitulo.Index].Value = item.ButacaFuncion.Funcion.Titulo.Descripcion;
            r.Cells[cmnFecha.Index].Value = item.ButacaFuncion.Funcion.Fecha/*Hora*/;
            r.Tag = item;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
