using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_datos;
using capa_entidad;

namespace capa_negocio

{
    public class CN_Usuario
    {
        private Cd_Usuario objCDUsuario = new Cd_Usuario();

        public List<Usuario> Listar()
        {
            return objCDUsuario.Listar();
        }

        public int Registrar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if(obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del usuario\n";
            }

            if (obj.clave == "")
            {
                mensaje += "Es necesario agregar contraseña del usuario\n";
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
                return objCDUsuario.Registrar(obj, out mensaje);
            }
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del usuario\n";
            }
            if (obj.clave == "")
            {
                mensaje += "Es necesario agregar contraseña del usuario\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCDUsuario.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre del usuario\n";
            }
            if (obj.clave == "")
            {
                mensaje += "Es necesario agregar contraseña del usuario\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCDUsuario.Eliminar(obj, out mensaje);
            }
        }
    }
}
