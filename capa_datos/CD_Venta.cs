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
    public class CD_Venta
    {
        public int Extras()
        {
            int id_extras = 0;

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from venta");

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

        public bool Registrar(Venta obj, DataTable detalle_venta, out string mensaje)
        {
            //int idU_resultado = 0;
            mensaje = string.Empty;
            bool respuesta = false;

            using (SqlConnection con = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistraVenta", con);
                    cmd.Parameters.AddWithValue("id_usuario", obj.objUsuario.id_usuario);
                    cmd.Parameters.AddWithValue("tipo_doc", obj.tipo_doca);
                    cmd.Parameters.AddWithValue("num_doc", obj.num_doc);
                    cmd.Parameters.AddWithValue("monto_pago", obj.monto_pago);
                    cmd.Parameters.AddWithValue("monto_cambio", obj.monto_cambio);
                    cmd.Parameters.AddWithValue("subtotal", obj.monto_total);
                    cmd.Parameters.AddWithValue("detalle_venta", detalle_venta);
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
    }
}
