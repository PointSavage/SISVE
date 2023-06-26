using QRCodeDecoderLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;

namespace capa_presentacion.Detalles
{
    public partial class dtInicioQR : Form
    {

        private bool ExistenDispositivos = false;
        private FilterInfoCollection DispositivosDeVideo;  //lista de dispositivos de video MisDispositivos
        private VideoCaptureDevice FuenteDeVideo = null;

        public dtInicioQR()
        {
            InitializeComponent();
        }

        private void dtInicioQR_Load(object sender, EventArgs e)
        {
            BuscarDispositivos();

            //ACTIVA CAMARA
            TerminarFuenteDeVideo();
            int i = cmbDisp.SelectedIndex;
            string NombreVideo = DispositivosDeVideo[i].MonikerString;
            FuenteDeVideo = new VideoCaptureDevice(NombreVideo);
            FuenteDeVideo.NewFrame += new NewFrameEventHandler(video_NuevoFrameCapturando);
            FuenteDeVideo.Start();
        }

        public void BuscarDispositivos()
        {
            DispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivosDeVideo.Count == 0)
                ExistenDispositivos = false;
            else
            {
                ExistenDispositivos = true;
                CargarDispositivos(DispositivosDeVideo);
            }
        }

        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo.Stop();
                    FuenteDeVideo = null;
                }
        }
        private void video_NuevoFrameCapturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pbQR.Image = Imagen;
        }

        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++)
                cmbDisp.Items.Add(Dispositivos[i].Name.ToString());
            cmbDisp.Text = cmbDisp.Items[0].ToString();
        }

        private void dtInicioQR_FormClosed(object sender, FormClosedEventArgs e)
        {
            TerminarFuenteDeVideo();
        }

        private void dtInicioQR_Click(object sender, EventArgs e)
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    pbFotoCapturada.Image = pbQR.Image;
                }
            Decodifica();
        }

        private void Decodifica()
        {
            QRDecoder decoder = new QRDecoder();

            Bitmap qr = (Bitmap)pbFotoCapturada.Image;
            byte[][] txt = decoder.ImageDecoder(qr);
            MessageBox.Show(txt.ToString());
        }

        
    }
}
