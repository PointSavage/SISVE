using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class ReporteCompra
    {
        public string fecha_registro { get; set; }
        public string tipo_doc { get; set; }
        public string num_doc { get; set; }
        public string monto_total { get; set; }
        public string usuarioRegistro { get; set; }
        public string nombre { get; set; }
        public string codigo_producto { get; set; }
        public string nombre_producto { get; set; }
        public string precio_compra { get; set; }
        public string precio_venta { get; set; }
        public string subtotal { get; set; }

    }
}
