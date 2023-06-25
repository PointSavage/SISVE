using capa_datos;
using capa_entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_negocio
{
    public class CN_Venta
    {
        private CD_Venta objCDVenta = new CD_Venta();

        public int Extras()
        {
            return objCDVenta.Extras();
        }

        public bool Registrar(Venta obj, DataTable detalle_compra, out string mensaje)
        {
            mensaje = string.Empty;
            return objCDVenta.Registrar(obj, detalle_compra, out mensaje);
        }
    }
}
