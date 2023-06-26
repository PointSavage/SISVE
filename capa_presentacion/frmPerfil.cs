using capa_entidad;
using capa_negocio;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capa_presentacion
{
    public partial class frmPerfil : Form
    {
        private static Usuario UActual;

        public frmPerfil(Usuario objUsuario = null)
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

        private void frmPerfil_Load(object sender, EventArgs e)
        {
            txtName.Text = UActual.nombre;
            txtRol.Text = UActual.objRol.descripcion;
            txtMail.Text = UActual.correo;

            //Crear QR
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(UActual.nombre.Trim(), out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(100, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var image = new Bitmap(imageTemporal, new Size(new Point(150, 150)));
            picQR.BackgroundImage = image;
            image.Save("imagen.png", ImageFormat.Png);
        }
    }
}
