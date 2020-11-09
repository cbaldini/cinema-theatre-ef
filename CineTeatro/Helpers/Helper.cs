using CineTeatro.Common.Entities;
using CineTeatro.ServiceLayer.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineTeatro.Windows.Helpers
{
    public class Helper
    {
        public static void CargarComboTitulos(ref ComboBox cbo, ITitulosService servicioTitulos)
        {
            cbo.DataSource = null;
            var listaTitulos = servicioTitulos.GetLista(null);
            var defaultTitulo = new Titulo
            {
                Descripcion = "<Seleccione título>"
            };
            listaTitulos.Insert(0, defaultTitulo);
            cbo.DataSource = listaTitulos;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "TituloId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboFunciones(ref ComboBox cbo, IFuncionesService servicioFunciones, int tituloid)
        {
            cbo.DataSource = null;
            var listaFunciones = servicioFunciones.GetFuncionXTitulo(tituloid);
            var defaultFuncion = new Funcion
            {
                Fecha = "<Seleccione",
                Hora=" horario>"
            };
            listaFunciones.Insert(0, defaultFuncion);
            cbo.DataSource = listaFunciones;
            cbo.DisplayMember = "FechaHora";
            cbo.ValueMember = "FuncionId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboFormasDeVenta(ref ComboBox cbo, IFormasDeVentaService servicioFormasDeVenta)
        {
            cbo.DataSource = null;
            var listaTitulos = servicioFormasDeVenta.GetLista(null);
            var defaultFormaDeVenta = new FormaDeVenta
            {
                Descripcion = "<Seleccione forma de venta>"
            };
            listaTitulos.Insert(0, defaultFormaDeVenta);
            cbo.DataSource = listaTitulos;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "FormaDeVentaId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboFormasDePago(ref ComboBox cbo, IFormasDePagoService servicioFormasDePago)
        {
            cbo.DataSource = null;
            var listaTitulos = servicioFormasDePago.GetLista(null);
            var defaultFormaDePago = new FormaDePago
            {
                Descripcion = "<Seleccione forma de pago>"
            };
            listaTitulos.Insert(0, defaultFormaDePago);
            cbo.DataSource = listaTitulos;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "FormaDePagoId";
            cbo.SelectedIndex = 0;
        }
    }
}
