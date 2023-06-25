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
    public class CD_Proveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> Lista = new List<Proveedor>();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select id_proveedor, nombre, correo, telefono, estado from proveedor");
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Proveedor()
                            {
                                id_proveedor = Convert.ToInt32(reader["id_proveedor"]),
                                nombre = reader["nombre"].ToString(),
                                correo = reader["correo"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lista = new List<Proveedor>();
                }

                return Lista;
            }
        }

        public int Registrar(Proveedor obj, out string mensaje)
        {
            int idU_resultado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spRegistraProveedor", con);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@correo", obj.correo);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@estado", obj.estado);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
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

        public bool Editar(Proveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spEditaProveedor", con);
                    cmd.Parameters.AddWithValue("@id_proveedor", obj.id_proveedor);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@correo", obj.correo);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@estado", obj.estado);
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
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

        public bool Eliminar(Proveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spEliminaProveedor", con);
                    cmd.Parameters.AddWithValue("@id_proveedor", obj.id_proveedor);
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
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
