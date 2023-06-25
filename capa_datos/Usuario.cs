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
    public class Cd_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> Lista = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.id_usuario, u.nombre, u.correo, u.clave, u.estado, r.id_rol, r.descripcion from usuario u");
                    query.AppendLine("inner join rol r on r.id_rol = u.id_rol");
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Usuario()
                            {
                                id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                nombre = reader["nombre"].ToString(),
                                correo = reader["correo"].ToString(),
                                clave = reader["clave"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"]),
                                objRol = new Rol() 
                                { 
                                    id_rol = Convert.ToInt32(reader["id_rol"]), 
                                    descripcion = reader["descripcion"].ToString()
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lista = new List<Usuario>();
                }

                return Lista;
            }
        }

        public int  Registrar(Usuario obj, out string mensaje)
        {
            int idU_resultado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spRegistraUsuario", con);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@correo", obj.correo);
                    cmd.Parameters.AddWithValue("@clave", obj.clave);
                    cmd.Parameters.AddWithValue("@id_rol", obj.objRol.id_rol);
                    cmd.Parameters.AddWithValue("@estado", obj.estado);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("idU_resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    idU_resultado = Convert.ToInt32(cmd.Parameters["idU_resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idU_resultado = 0;
                mensaje = ex.Message;
            }
            
            return idU_resultado;
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spEditaUsuario", con);
                    cmd.Parameters.AddWithValue("@id_usuario", obj.id_usuario);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@correo", obj.correo);
                    cmd.Parameters.AddWithValue("@clave", obj.clave);
                    cmd.Parameters.AddWithValue("@id_rol", obj.objRol.id_rol);
                    cmd.Parameters.AddWithValue("@estado", obj.estado);
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spEliminaUsuario", con);
                    cmd.Parameters.AddWithValue("@id_usuario", obj.id_usuario);
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
