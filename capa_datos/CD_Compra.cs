using capa_entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos
{
    public class CD_Compra
    {
        public int Extras()
        {
            int id_extras = 0;

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from compra");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    id_extras = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    return id_extras = 0;
                }
            }

            return id_extras;
        }

        public bool Registrar(Compra obj, DataTable detalle_compra, out string mensaje)
        {
            //int idU_resultado = 0;
            mensaje = string.Empty;
            bool respuesta = false;

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistraCompra", con);
                    cmd.Parameters.AddWithValue("id_usuario", obj.objUsuario.id_usuario);
                    cmd.Parameters.AddWithValue("id_proveedor", obj.objProveedor.id_proveedor);
                    cmd.Parameters.AddWithValue("tipo_doc", obj.tipo_doc);
                    cmd.Parameters.AddWithValue("num_doc", obj.num_doc);
                    cmd.Parameters.AddWithValue("total", obj.monto_total);
                    cmd.Parameters.AddWithValue("detalle_compra", detalle_compra);
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        public Compra GetCompra(string num)
        {
            Compra objCompra = new Compra();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.id_compra, u.nombre, p.nombre as nombrep, c.tipo_doc, c.num_doc, c.monto_total, convert(char(10), c.fecha_registro, 103)[fecha_registro]");
                    query.AppendLine("from compra c");
                    query.AppendLine("inner join usuario u on u.id_usuario = c.id_usuario");
                    query.AppendLine("inner join proveedor p on p.id_proveedor = c.id_proveedor");
                    query.AppendLine("where c.num_doc = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);

                    cmd.Parameters.AddWithValue("@numero", num);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objCompra = new Compra()
                            {
                                id_compra = Convert.ToInt32(reader["id_compra"]),
                                objUsuario = new Usuario() { nombre = reader["nombre"].ToString() },
                                objProveedor = new Proveedor() { nombre = reader["nombrep"].ToString() },
                                tipo_doc = reader["tipo_doc"].ToString(),
                                num_doc = reader["num_doc"].ToString(),
                                monto_total = Convert.ToDecimal(reader["monto_total"].ToString()),
                                fecha_registro = reader["fecha_registro"].ToString()
                            };
                        }
                    }
                }
                catch
                {
                    objCompra = new Compra();
                }
            }

            return objCompra;
        }

        public List<Detalle_compra> GetDetalle_Compra(int id_compra)
        {
            List<Detalle_compra> Lista = new List<Detalle_compra>();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.nombre, dc.precio_compra, dc.cantidad, dc.monto_total");
                    query.AppendLine("from detalle_compra dc");
                    query.AppendLine("inner join PRODUCTO p on p.id_producto = dc.id_producto");
                    query.AppendLine("where dc.id_compra = @id_compra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@id_compra", id_compra);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Detalle_compra()
                            {
                                objProducto = new Producto() { nombre = reader["nombre"].ToString() },
                                precio_compra = Convert.ToDecimal(reader["precio_compra"].ToString()),
                                cantidad = Convert.ToInt32(reader["cantidad"].ToString()),
                                monto_total = Convert.ToDecimal(reader["total"].ToString()),
                            });
                        }
                    }
                }
                catch
                {
                    Lista = new List<Detalle_compra>();
                }

                return Lista;
            }
        }
    }
}
