using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_negocio;
using capa_entidad;

namespace capa_presentacion
{
    public partial class FrmNegocio : Form
    {
        public FrmNegocio()
        {
            InitializeComponent();
        }

        public Image ByteLogo(byte[] logo)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(logo, 0, logo.Length);
            Image imagen = new Bitmap(ms);
            return imagen;
        }

        private void FrmNegocio_Load(object sender, EventArgs e)
        {
            bool respuesta = true;
            byte[] logo = new CN_Negocio().ObtenLogo(out respuesta);

            if (respuesta)
            {
                picLogo.Image = ByteLogo(logo);
            }

            Negocio datos = new CN_Negocio().Listar();

            txtName.Text = datos.nombre;
            txtMail.Text = datos.correo;
            txtDireccion.Text = datos.direccion;
        } 

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Files |* .jpg; *.jpeg; *.png"; 

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] logo = File.ReadAllBytes(ofd.FileName);
                bool respuesta = new CN_Negocio().GuardaLogo(logo, out mensaje);

                if (respuesta)
                {
                    picLogo.Image = ByteLogo(logo);
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Negocio obj = new Negocio()
            {
                nombre = txtName.Text,
                correo = txtMail.Text,
                direccion = txtDireccion.Text
            };

            bool respuesta = new CN_Negocio().Edita(obj, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Cambios guardados exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
