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
    public class CD_Reporte
    {
        public List<ReporteCompra> Compra(string fecha_inicio, string fecha_fin, int id_proveedor)
        {
            List<ReporteCompra> Lista = new List<ReporteCompra>();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spReporteCompra", con);
                    cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                    cmd.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new ReporteCompra()
                            {
                                fecha_registro = reader["fecha_registro"].ToString(),
                                tipo_doc = reader["tipo_doc"].ToString(),
                                num_doc = reader["num_doc"].ToString(),
                                monto_total = reader["monto_total"].ToString(),
                                usuarioRegistro = reader["usuarioRegistro"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                codigo_producto = reader["codigo_producto"].ToString(),
                                nombre_producto = reader["nombre_producto"].ToString(),
                                precio_compra = reader["precio_compra"].ToString(),
                                precio_venta = reader["precio_venta"].ToString(),
                                subtotal = reader["subtotal"].ToString(),
                            });
                        }
                    }
                }
                catch
                {
                    Lista = new List<ReporteCompra>();
                }

                return Lista;
            }
        }

        public List<ReporteVenta> Venta(string fecha_inicio, string fecha_fin)
        {
            List<ReporteVenta> Lista = new List<ReporteVenta>();

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spReporteVenta", con);
                    cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new ReporteVenta()
                            {
                                fecha_registro = reader["fecha_registro"].ToString(),
                                tipo_doc = reader["tipo_doc"].ToString(),
                                num_doc = reader["num_doc"].ToString(),
                                monto_total = reader["monto_total"].ToString(),
                                usuarioRegistro = reader["usuarioRegistro"].ToString(),
                                codigo_producto = reader["codigo_producto"].ToString(),
                                nombre_producto = reader["nombre_producto"].ToString(),
                                precio_venta = reader["precio_venta"].ToString(),
                                cantidad = reader["cantidad"].ToString(),
                            });
                        }
                    }
                }
                catch
                {
                    Lista = new List<ReporteVenta>();
                }

                return Lista;
            }
        }
    }
}
