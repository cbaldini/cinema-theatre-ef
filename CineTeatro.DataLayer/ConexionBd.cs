using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatro.DataLayer
{
    public class ConexionBd
    {
        private readonly string cadenaDeConexion;

        public ConexionBd()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public SqlConnection CrearConexion()
        { 
            var cn = new SqlConnection(cadenaDeConexion);
            return cn;
        }
    }
}
