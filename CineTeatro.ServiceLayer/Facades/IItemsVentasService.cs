using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.ServiceLayer.Facades
{
    public interface IItemsVentasService
    {
        List<ItemVenta> GetLista(int? id);
        List<ItemVenta> GetListaXVenta(int? id);
        ItemVenta GetObjeto(int id);
        void Guardar(ItemVenta itemVenta);
        void Editar(ItemVenta itemventa);
        void Borrar(ItemVenta itemVenta);
        bool EsUnico(int ventaid, int butacafuncionid);
    }
}
