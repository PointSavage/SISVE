using capa_datos;
using capa_entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_negocio
{
    public class CN_Reporte
    {
        private CD_Reporte obj = new CD_Reporte();

        public List<ReporteCompra> Compra(string fecha_inicio, string fecha_fin, int id_proveedoor)
        {
            return obj.Compra(fecha_inicio, fecha_fin, id_proveedoor);
        }

        public List<ReporteVenta> Venta(string fecha_inicio, string fecha_fin)
        {
            return obj.Venta(fecha_inicio, fecha_fin);
        }
    }
}
