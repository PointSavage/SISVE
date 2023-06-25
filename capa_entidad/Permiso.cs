using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class Permiso
    {
        public int id_permiso { get; set; }
        public Rol objRol { get; set; }
        public string nombre_menu { get; set; }
        public string fecha_registro { get; set; }
    }
}
