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
    public class CD_Productos
    {
        public List<Producto> Listar()
        {
            List<Producto> Lista = new List<Producto>();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select id_producto, codigo, nombre, descripcion, stock, precio_compra, precio_venta, estado from PRODUCTO");
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Producto()
                            {
                                id_Producto = Convert.ToInt32(reader["id_producto"]),
                                codigo = reader["codigo"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                stock = Convert.ToInt32(reader["stock"]),
                                precio_compra = Convert.ToInt32(reader["precio_compra"]),
                                precio_venta = Convert.ToInt32(reader["precio_venta"]),
                                estado = Convert.ToBoolean(reader["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lista = new List<Producto>();
                }

                return Lista;
            }
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            int idU_resultado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spRegistraProducto", con);
                    cmd.Parameters.AddWithValue("@codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@stock", obj.stock);
                    cmd.Parameters.AddWithValue("@pcompra", obj.precio_compra);
                    cmd.Parameters.AddWithValue("@pventa", obj.precio_venta);
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

        public bool Editar(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spEditaProducto", con);
                    cmd.Parameters.AddWithValue("@id_producto", obj.id_Producto);
                    cmd.Parameters.AddWithValue("@codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@stock", obj.stock);
                    cmd.Parameters.AddWithValue("@precio_compra", obj.precio_compra);
                    cmd.Parameters.AddWithValue("@precio_venta", obj.precio_venta);
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

        public bool Eliminar(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {

                    SqlCommand cmd = new SqlCommand("spEliminaProducto", con);
                    cmd.Parameters.AddWithValue("@id_producto", obj.id_Producto);
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
