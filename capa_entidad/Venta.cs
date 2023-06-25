using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class Venta
    {
        public string id_venta { get; set; }
        public Usuario objUsuario { get; set; }
        public string tipo_doca { get; set; }
        public string num_doc { get; set; }
        public string nombre { get; set; }
        public decimal monto_pago { get; set; }
        public decimal monto_cambio { get; set; }
        public decimal monto_total { get; set; }
        public List<Detalle_venta> objDetalleVenta { get; set; }
        public string fecha_registro { get; set; }
    }
}
