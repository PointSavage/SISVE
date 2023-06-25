using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class Compra
    {
        public int id_compra { get; set; }
        public Usuario objUsuario { get; set; }
        public Proveedor objProveedor { get; set; }
        public string tipo_doc { get; set; }
        public string num_doc { get; set; }
        public decimal monto_total { get; set; }
        public List<Detalle_compra> objDetalleCompra { get; set; }
    public string fecha_registro { get; set; }
    }
}
