using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace capa_datos
{
    public class Conexion
    {
        public static string conexion = ConfigurationManager.ConnectionStrings["Cadena_Conexion"].ToString();
    }
}
