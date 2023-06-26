using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_entidad;
using capa_negocio;
using capa_presentacion.Detalles;

namespace capa_presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Filtrado, expresión lambda, automatiza la busqueda de un usuario igual al ingresado y que retorne el primero o nulo
            Usuario objUsuario = new CN_Usuario().Listar().Where(u => u.nombre ==txtUser.Text && u.clave == txtPass.Text).FirstOrDefault();
            //validacion
            if (objUsuario != null)
            {
                Home home = new Home(objUsuario);
                home.Show();
                this.Hide();

                home.FormClosing += CloseHome;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CloseHome(object sender , FormClosingEventArgs e)
        {
            this.Show();
            txtUser.Clear();
            txtPass.Clear();
        }

        private void btnInicioQR_Click(object sender, EventArgs e)
        {
            using (var detalle = new dtInicioQR())
            {
                var resultado = detalle.ShowDialog();

                /*if (resultado == DialogResult.OK)
                {
                    txtIdProv.Text = detalle.objProveedor.id_proveedor.ToString();
                    txtNProv.Text = detalle.objProveedor.nombre.ToString();
                }
                else
                {
                    txtNProv.Select();
                }*/
            }
        }
    }

}
