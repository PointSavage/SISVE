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
using FontAwesome.Sharp;
using capa_negocio;

namespace capa_presentacion
{
    public partial class Home : Form
    {
        private static Usuario UActual;
        private static IconMenuItem MActivo = null;
        private static Form FActivo = null;

        public Home(Usuario objUsuario = null)
        {
            if (objUsuario == null)
            {
                UActual = new Usuario()
                {
                    nombre = "Usuario Predefinido",
                    id_usuario = 1,
                };
            }
            else
            {
                UActual = objUsuario;
            }
            
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            List<Permiso> listaP = new CN_Permiso().Listar(UActual.id_usuario);
            foreach (IconMenuItem iconMenu in mstrMenu.Items)
            {
                bool encontrado = listaP.Any(m => m.nombre_menu == iconMenu.Name);
                if (encontrado == false)
                {
                    iconMenu.Visible = false;
                }
            }
            lblUser.Text = UActual.nombre;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenFrm(IconMenuItem menu, Form Formulario)
        {
            if (MActivo != null)
            {
                MActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MActivo = menu;

            if (FActivo != null)
            {
                FActivo.Close();
            }
            FActivo = Formulario;
            Formulario.TopLevel = false;
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Dock = DockStyle.Fill;
            Formulario.BackColor = Color.LightBlue;

            pnlContenedor.Controls.Add(Formulario);
            Formulario.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            OpenFrm((IconMenuItem)sender, new frmUsuarios());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            OpenFrm((IconMenuItem)sender, new FrmProveedores());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            OpenFrm(btnProductos, new FrmProducto());
        }

        private void smPerfilU_Click(object sender, EventArgs e)
        {
            OpenFrm(btnInfo, new frmPerfil(UActual));
        }

        private void smPerfilN_Click(object sender, EventArgs e)
        {
            OpenFrm(btnInfo, new FrmNegocio());
        }

        private void btnRVentas_Click(object sender, EventArgs e)
        {
            OpenFrm(btnVenta, new FrmVenta(UActual));
        }

        private void btnRCompra_Click(object sender, EventArgs e)
        {
            OpenFrm(btnCompra, new FrmCompra(UActual));
        }

        private void smGeneral_Click_1(object sender, EventArgs e)
        {
            OpenFrm(btnReporte, new FrmReportes());
        }

        private void smCompra_Click(object sender, EventArgs e)
        {
            OpenFrm(btnReporte, new FrmDetalleCompra());
        }

        private void smVenta_Click(object sender, EventArgs e)
        {
            OpenFrm(btnReporte, new FrmDetalleVenta());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

        }
    }
}
