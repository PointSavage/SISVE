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
    public class CD_Permiso
    {
        public List<Permiso> Listar(int id_usuario)
        {
            List<Permiso> Lista = new List<Permiso>();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.id_rol, p.nombre_menu from Permiso p");
                    query.AppendLine("inner join rol r on r.id_rol = p.id_rol");
                    query.AppendLine("inner join usuario u on u.id_rol = r.id_rol");
                    query.AppendLine("where u.id_usuario = @id_usuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Permiso()
                            {
                                objRol = new Rol() { id_rol = Convert.ToInt32(reader["id_rol"])},
                                nombre_menu = reader["nombre_menu"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lista = new List<Permiso>();
                }

                return Lista;
            }
        }
    }
}
