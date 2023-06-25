using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_entidad;
using capa_datos;
namespace capa_negocio
{
    public class CN_Producto
    {
        private CD_Productos objCDProducto = new CD_Productos();
        public List<Producto> Listar()
        {
            return objCDProducto.Listar();
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del producto\n";
            }

            if (obj.codigo == "")
            {
                mensaje += "Es necesario agregar codigo del producto\n";
            }

            if (obj.descripcion == "")
            {
                mensaje += "No se puede agregar este producto porque tiene datos incompletos\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCDProducto.Registrar(obj, out mensaje);
            }
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del producto\n";
            }
            if (obj.codigo == "")
            {
                mensaje += "Es necesario agregar codigo del producto\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCDProducto.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del Producto\n";
            }
            if (obj.codigo == "")
            {
                mensaje += "Es necesario agregar contraseña del Producto\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCDProducto.Eliminar(obj, out mensaje);
            }
        }
    }
}
