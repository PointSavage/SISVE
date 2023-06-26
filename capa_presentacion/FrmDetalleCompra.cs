using capa_entidad;
using capa_negocio;
using capa_presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capa_presentacion
{
    public partial class FrmDetalleCompra : Form
    {
        public FrmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            List<Proveedor> listaRol = new CN_Proveedor().Listar();
            cmbProveedor.Items.Add(new OpcionCmb() { valor = 0, texto = "Todos" });
            foreach (Proveedor item in listaRol)
            {
                cmbProveedor.Items.Add(new OpcionCmb { valor = item.id_proveedor, texto = item.nombre });
            }
            cmbProveedor.DisplayMember = "texto";
            cmbProveedor.ValueMember = "valor";
            cmbProveedor.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.HeaderText != "")
                {
                    cmbFiltro.Items.Add(new OpcionCmb() { valor = columna.Name, texto = columna.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "texto";
            cmbFiltro.ValueMember = "valor";
            cmbFiltro.SelectedIndex = 0;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            int id_proveedor = Convert.ToInt32(((OpcionCmb)cmbProveedor.SelectedItem).valor.ToString());
            List<ReporteCompra> listaRol = new List<ReporteCompra>();
            listaRol = new CN_Reporte().Compra(
                dateTimePicker1.Value.ToString(),
                dateTimePicker2.Value.ToString(),
                id_proveedor
                );

            dgvData.Rows.Clear();
            foreach (ReporteCompra rc in listaRol)
            {
                dgvData.Rows.Add(new object[]{
                    rc.fecha_registro,
                    rc.tipo_doc,
                    rc.num_doc,
                    rc.monto_total,
                    rc.usuarioRegistro,
                    rc.nombre,
                    rc.codigo_producto,
                    rc.nombre_producto,
                    rc.precio_compra,
                    rc.precio_venta,
                    rc.subtotal
                });
            }
        }
    }
}
