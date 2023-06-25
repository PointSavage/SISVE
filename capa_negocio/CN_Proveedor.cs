using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_datos;
using capa_entidad;

namespace capa_negocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objCDProveedor = new CD_Proveedor();

        public List<Proveedor> Listar()
        {
            return objCDProveedor.Listar();
        }

        public int Registrar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del proveedor\n";
            }

            if (obj.correo == "")
            {
                mensaje += "No se puede agregar este usuario porque tiene datos incompletos\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCDProveedor.Registrar(obj, out mensaje);
            }
        }

        public bool Editar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del Proveedor\n";
            }
            if (obj.correo == "")
            {
                mensaje += "Es necesario agregar contraseña del Proveedor\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCDProveedor.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del Proveedor\n";
            }
            if (obj.correo == "")
            {
                mensaje += "Es necesario agregar contraseña del Proveedor\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCDProveedor.Eliminar(obj, out mensaje);
            }
        }
    }
}
