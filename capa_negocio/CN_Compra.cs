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
    public class CN_Compra
    {
        private CD_Compra objCDCompra = new CD_Compra();

        public int Extras()
        {
            return objCDCompra.Extras();
        }

        public bool Registrar(Compra obj, DataTable detalle_compra, out string mensaje)
        {
            mensaje = string.Empty;
            return objCDCompra.Registrar(obj, detalle_compra, out mensaje);
        } 

        public Compra GetCompra(string num)
        {
            Compra objCompra = objCDCompra.GetCompra(num);

            if (objCompra.id_compra != 0)
            {
                List<Detalle_compra> detalle_compra = objCDCompra.GetDetalle_Compra(objCompra.id_compra);
                objCompra.objDetalleCompra = detalle_compra;
            }
            return objCompra;
        }
    }
}
