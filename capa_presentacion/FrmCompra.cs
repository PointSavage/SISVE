using capa_entidad;
using capa_negocio;
using capa_presentacion.Detalles;
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
    public partial class FrmCompra : Form
    {
        private Usuario UActual;
        public FrmCompra(Usuario objUsuario = null)
        {
            UActual = objUsuario;
            InitializeComponent();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            cmbDoc.Items.Add(new OpcionCmb() { valor = "Boleta", texto = "Boleta" });
            cmbDoc.Items.Add(new OpcionCmb() { valor = "Factura", texto = "Factura" });
            cmbDoc.DisplayMember = "texto";
            cmbDoc.ValueMember = "valor";
            cmbDoc.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/mm/yyyy");
            txtIdProv.Text = "0";
            txtIdPro.Text = "0";
        }

        private void btnBuscaPr_Click(object sender, EventArgs e)
        {
            using (var detalle = new dtProveedor())
            {
                var resultado = detalle.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtIdProv.Text = detalle.objProveedor.id_proveedor.ToString();
                    txtNProv.Text = detalle.objProveedor.nombre.ToString();
                }
                else
                {
                    txtNProv.Select();
                }
            }
        }

        private void btnBuscaProducto_Click(object sender, EventArgs e)
        {
            using (var detalle = new dtProducto())
            {
                var resultado = detalle.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtCode.Text = detalle.objProducto.codigo.ToString();
                    txtIdPro.Text = detalle.objProducto.id_Producto.ToString();
                    txtNPro.Text = detalle.objProducto.nombre.ToString();
                    txtPC.Text = detalle.objProducto.precio_compra.ToString();
                    txtP_v.Text = detalle.objProducto.precio_venta.ToString();
                }
                else
                {
                    txtNPro.Select();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal p_compra = 0;
            decimal p_venta = 0;
            bool existe = false;

            if (int.Parse(txtIdPro.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Adveertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPC.Text, out p_compra))
            {
                MessageBox.Show("Precio Compra = Formato Incorrecto", "Adveertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtP_v.Select();
                return;
            }

            if (!decimal.TryParse(txtP_v.Text, out p_venta))
            {
                MessageBox.Show("Precio Venta = Formato Incorrecto", "Adveertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtP_v.Select();
                return;
            }

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["id"].Value.ToString() == txtIdPro.Text)
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                dgvData.Rows.Add(new object[]
                {
                    txtIdPro.Text,
                    txtNPro.Text,
                    p_compra.ToString("0.00"),
                    p_venta.ToString("0.00"),
                    nudCantidad.Value.ToString(),
                    (nudCantidad.Value * p_compra).ToString("0.00")
                });
                Total();
                limpiar();
            }
        }

        private void limpiar()
        {
            txtIdPro.Clear();
            txtCode.Clear();
            txtCode.BackColor = Color.White;
            txtNPro.Clear();
            txtPC.Clear();
            txtP_v.Clear();
            nudCantidad.Value = 1;
        }

        private void Total()
        {
            decimal total = 0;
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString());
                }
            }
            txtTotal.Text = total.ToString("0.00");
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.Elimina.Width;
                var h = Properties.Resources.Elimina.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.Elimina, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            DialogResult boton;

            if (dgvData.Columns[e.ColumnIndex].Name == "btnelimina")
            {
                boton = MessageBox.Show("¿Desea eliminar este producto?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (boton == DialogResult.OK)
                {
                    dgvData.Rows.RemoveAt(indice);
                    Total();
                }
            }
        }

        // SOLO PERMITE NUMEROS Y PUNTOS//////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void txtPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPC.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        // SOLO PERMITE NUMEROS Y PUNTOS//////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void txtP_v_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPC.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtIdProv.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable detalle_compra = new DataTable();
            detalle_compra.Columns.Add("id_producto", typeof(int));
            detalle_compra.Columns.Add("precio_compra", typeof(decimal));
            detalle_compra.Columns.Add("precio_venta", typeof(decimal));
            detalle_compra.Columns.Add("cantidad", typeof(int));
            detalle_compra.Columns.Add("monto_total", typeof(decimal));

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["id"].Value.ToString()),
                        row.Cells["precio_c"].Value.ToString(),
                        row.Cells["precio_v"].Value.ToString(),
                        row.Cells["cantidad"].Value.ToString(),
                        row.Cells["subtotal"].Value.ToString()
                    });
            }

            int id = new CN_Compra().Extras();
            string extra = string.Format("{0:00000}", id);
            Compra objCompra = new Compra() {
                objUsuario = new Usuario() { id_usuario = UActual.id_usuario},
                objProveedor= new Proveedor() { id_proveedor = Convert.ToInt32(txtIdProv.Text) },
                tipo_doc = ((OpcionCmb)cmbDoc.SelectedItem).texto,
                num_doc = extra,
                monto_total = Convert.ToDecimal(txtTotal.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(objCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de compra:\n" + extra + "\n\n¿Desea copiar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(extra);
                }
                txtIdProv.Clear();
                txtNProv.Clear();
                dgvData.Rows.Clear();
                Total();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}