using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public Rol objRol { get; set; }
        public bool estado { get; set; }
        public string fecha_registro { get; set; }
    }
}
