using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_datos;
using capa_entidad;

namespace capa_negocio
{
    public class CN_Rol
    {
        private CD_Rol objCDRol = new CD_Rol();

        public List<Rol> Listar()
        {
            return objCDRol.Listar();
        }
    }
}
