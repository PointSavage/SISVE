using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_datos;
using capa_entidad;

namespace capa_negocio
{
    public class CN_Negocio
    {
        private CD_Negocio objCDNegocio = new CD_Negocio();

        public Negocio Listar()
        {
            return objCDNegocio.Listar();
        }

        public bool Edita(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.nombre == "")
            {
                mensaje += "Es necesario agregar nombre\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCDNegocio.Edita(obj, out mensaje);
            }
        }

        public byte[] ObtenLogo( out bool respuesta)
        {
            return objCDNegocio.Obtenlogo(out respuesta);
        }

        public bool GuardaLogo(byte[] logo , out string mensaje)
        {
            return objCDNegocio.Guardalogo(logo, out mensaje);
        }
    }
}
