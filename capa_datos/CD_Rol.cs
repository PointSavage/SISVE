using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using capa_entidad;

namespace capa_datos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> Lista = new List<Rol>();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string query = "select id_rol, descripcion from rol";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Rol()
                            {
                                id_rol = Convert.ToInt32(reader["id_rol"]),
                                descripcion = reader["descripcion"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lista = new List<Rol>();
                }

                return Lista;
            }
        }
    }
}
