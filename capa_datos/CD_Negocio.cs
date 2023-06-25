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
    public class CD_Negocio
    {
        public Negocio Listar()
        {
            Negocio objNegocio = new Negocio();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {
                    con.Open();

                    string query = "Select id_negocio, nombre, otro, direccion from negocio where id_negocio = 1";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;

                    using(SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            objNegocio = new Negocio()
                            {
                                id_negocio = int.Parse(rd["id_negocio"].ToString()),
                                nombre = rd["nombre"].ToString(),
                                correo = rd["otro"].ToString(),
                                direccion = rd["direccion"].ToString()
                            };
                            
                        }
                    }
                }
            }
            catch
            {
                objNegocio = new Negocio();
            }

            return objNegocio;
        }

        public bool Edita(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {
                    con.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update Negocio set nombre = @nombre,");
                    query.AppendLine("otro = @otro,");
                    query.AppendLine("direccion = @direccion");
                    query.AppendLine("where id_negocio = 1");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@otro", obj.correo);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.CommandType = CommandType.Text;

                    if(cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudieron actualizar los datos";
                        respuesta = false;
                    }
                }
            }
            catch(Exception ex)
            { 
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Guardalogo(byte[] logo, out string mensaje)
        {
            bool respuesta = true;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {
                    con.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update Negocio set logo = @logo");
                    query.AppendLine("where id_negocio = 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@logo", logo);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudieron actualizar el logo";
                        respuesta = false;
                    }
                }
            }
            catch
            {
                respuesta = false;
                logo = new byte[0];
            }

            return respuesta;
        }

        public byte[] Obtenlogo(out bool respuesta)
        {
            respuesta = true;
            byte[] logo = new byte[0];

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.conexion))
                {
                    con.Open();
                    string query = "Select logo from negocio where id_negocio = 1";
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            logo = (byte[])rd["logo"];

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                logo = new byte[0];
            }

            return logo;
        }
    }
}
