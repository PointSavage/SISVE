using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class Detalle_compra
    {
        public string id_DetalleCompra { get; set; }
        public Producto objProducto{ get; set; }
        public decimal precio_venta { get; set; }
        public decimal precio_compra { get; set; }
        public int cantidad { get; set; }
        public decimal monto_total { get; set; }
        public string fecha_registro { get; set; }
    }
}
