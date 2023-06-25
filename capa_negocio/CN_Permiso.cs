using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_datos;
using capa_entidad;

namespace capa_negocio
{
    public class CN_Permiso
    {
            private CD_Permiso objCDPermiso = new CD_Permiso();

            public List<Permiso> Listar(int id_usuario)
            {
                return objCDPermiso.Listar(id_usuario);
            }
    }
}

