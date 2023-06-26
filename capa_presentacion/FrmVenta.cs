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
    public partial class FrmVenta : Form
    {
        private Usuario UActual;

        public FrmVenta(Usuario objUsuario = null)
        {
            UActual = objUsuario;
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            cmbDoc.Items.Add(new OpcionCmb() { valor = "Boleta", texto = "Boleta" });
            cmbDoc.Items.Add(new OpcionCmb() { valor = "Factura", texto = "Factura" });
            cmbDoc.DisplayMember = "texto";
            cmbDoc.ValueMember = "valor";
            cmbDoc.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/mm/yyyy");
            txtIdPro.Text = "0";
        }

        private void btnBuscaProducto_Click(object sender, EventArgs e)
        {
            using (var detalle = new dtProducto())
            {
                var resultado = detalle.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtIdPro.Text = detalle.objProducto.id_Producto.ToString();
                    txtCode.Text = detalle.objProducto.codigo.ToString();
                    txtIdPro.Text = detalle.objProducto.id_Producto.ToString();
                    txtNPro.Text = detalle.objProducto.nombre.ToString();
                    txtPrecio.Text = detalle.objProducto.precio_venta.ToString();
                    txtStock.Text = detalle.objProducto.stock.ToString();
                }
                else
                {
                    txtCode.Select();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool existe = false;

            if (int.Parse(txtIdPro.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio = Formato Incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Select();
                return;
            }

            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(txtCantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Select();
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
                    precio.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value * precio).ToString("0.00")
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
            txtPrecio.Clear();
            txtStock.Clear();
            txtCantidad.Value = 1;
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

            if (e.ColumnIndex == 5)
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

        private void txtPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void Cambio()
        {
            if (txtTotal.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pago;
            decimal total = Convert.ToDecimal(txtTotal.Text);

            if (txtPago.Text.Trim() == "")
            {
                txtPago.Text = "0";
            }

            if (decimal.TryParse(txtPago.Text.Trim(), out pago))
            {
                if (pago < total)
                {
                    txtCambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pago - total;
                    txtCambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Cambio();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable detalle_venta = new DataTable();
            detalle_venta.Columns.Add("id_producto", typeof(int));
            detalle_venta.Columns.Add("precio_venta", typeof(decimal));
            detalle_venta.Columns.Add("cantidad", typeof(int));
            detalle_venta.Columns.Add("subtotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                detalle_venta.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["id"].Value.ToString()),
                        row.Cells["precio"].Value.ToString(),
                        row.Cells["cantidad"].Value.ToString(),
                        row.Cells["subtotal"].Value.ToString()
                    });
            }

            int id = new CN_Venta().Extras();
            string extra = string.Format("{0:00000}", id);
            Venta objVenta = new Venta()
            {
                objUsuario = new Usuario() { id_usuario = UActual.id_usuario },
                tipo_doca = ((OpcionCmb)cmbDoc.SelectedItem).texto,
                num_doc = extra,
                monto_pago = Convert.ToDecimal(txtPago.Text),
                monto_cambio = Convert.ToDecimal(txtCambio.Text),
                monto_total = Convert.ToDecimal(txtTotal.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(objVenta, detalle_venta, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de compra:\n" + extra + "\n\n¿Desea copiar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(extra);
                }
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
