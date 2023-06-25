using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class Detalle_venta
    {
        public string id_DetalleVenta { get; set; }
        public Producto objProducto { get; set; }
        public decimal precio_venta { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
        public string fecha_registro { get; set; }
    }
}
