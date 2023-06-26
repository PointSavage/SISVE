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
using capa_presentacion.Utilidades;
using ClosedXML.Excel;

namespace capa_presentacion
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Oculta();
            cmbStatus.Items.Add(new OpcionCmb() { valor = 1, texto = "Activo" });
            cmbStatus.Items.Add(new OpcionCmb() { valor = 0, texto = "No Activo" });
            cmbStatus.DisplayMember = "texto";
            cmbStatus.ValueMember = "valor";
            cmbStatus.SelectedIndex = 0;

            //mostrar productos
            List<Producto> listaProductos = new CN_Producto().Listar();
            foreach (Producto item in listaProductos)
            {
                dgvData.Rows.Add(new object[] { item.id_Producto, item.codigo, item.nombre, item.descripcion, item.stock, item.precio_compra, item.precio_venta,
                    item.estado == true ? 1 : 0,
                    item.estado == true ? "Activo" : "No Activo"
                });
            }

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

        private void Clear()
        {
            txtName.Clear();
            txtCode.Clear();
            txtDescription.Clear();
            txtStock.Clear();
            txtPCompra.Clear();
            txtPVenta.Clear();
            cmbStatus.SelectedIndex = 0;
            txtIdP.Text = "0";
            txtIndice.Text = "-1"; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Producto objProducto = new Producto()
            {
                id_Producto = Convert.ToInt32(txtIdP.Text),
                codigo = txtCode.Text,
                nombre = txtName.Text,
                descripcion = txtDescription.Text,
                stock = Convert.ToInt32(txtStock.Text),
                precio_compra = Convert.ToInt32(txtPCompra.Text),
                precio_venta = Convert.ToInt32(txtPVenta.Text),
                estado = Convert.ToInt32(((OpcionCmb)cmbStatus.SelectedItem).valor) == 1 ? true : false
            };

            if (objProducto.id_Producto == 0)
            {
                int idU_resultado = new CN_Producto().Registrar(objProducto, out mensaje);

                if (idU_resultado != 0)
                {
                    //muestra los datos en el dgv
                    dgvData.Rows.Add(new object[] { idU_resultado, txtCode.Text, txtName.Text, txtDescription.Text, txtStock.Text, txtPCompra.Text, txtPVenta.Text,
                    ((OpcionCmb)cmbStatus.SelectedItem).valor.ToString(),
                    ((OpcionCmb)cmbStatus.SelectedItem).texto.ToString()
                    });
                    MessageBox.Show(mensaje);
                    Clear();
                    Oculta();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Producto().Editar(objProducto, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["id"].Value = txtIdP.Text;
                    row.Cells["codigo"].Value = txtCode.Text;
                    row.Cells["nombre"].Value = txtName.Text;
                    row.Cells["descripcion"].Value = txtDescription.Text;
                    row.Cells["stock"].Value = txtStock.Text;
                    row.Cells["precio_compra"].Value = txtPCompra.Text;
                    row.Cells["precio_venta"].Value = txtPVenta.Text;
                    row.Cells["estado_valor"].Value = ((OpcionCmb)cmbStatus.SelectedItem).valor.ToString();
                    row.Cells["estado"].Value = ((OpcionCmb)cmbStatus.SelectedItem).texto.ToString();

                    Clear();
                    Oculta();
                    MessageBox.Show(mensaje);
                }
                else
                {

                    MessageBox.Show(mensaje);
                }
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Muestra();
        }

        private void Oculta()
        {
            lbl.Visible = false;
            lbl1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            txtCode.Visible = false;
            txtDescription.Visible = false;
            txtIdP.Visible = false;
            txtIndice.Visible = false;
            txtName.Visible = false;
            txtPCompra.Visible = false;
            txtPVenta.Visible = false;
            txtStock.Visible = false;
            cmbStatus.Visible = false;
            btnCancela.Visible = false;
            btnSave.Visible = false;
        }

        private void Muestra()
        {
            lbl.Visible = true;
            lbl1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            txtCode.Visible = true;
            txtDescription.Visible = true;
            txtIdP.Visible = true;
            txtIndice.Visible = true;
            txtName.Visible = true;
            txtPCompra.Visible = true;
            txtPVenta.Visible = true;
            txtStock.Visible = true;
            cmbStatus.Visible = true;
            btnSave.Visible = true;
            btnCancela.Visible = true;
        }

        private void dgvData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            DialogResult boton;

            if (dgvData.Columns[e.ColumnIndex].Name == "btnSelect")
            {
                if (indice >= 0)
                {
                    txtIdP.Text = dgvData.Rows[indice].Cells["id"].Value.ToString();
                    txtName.Text = dgvData.Rows[indice].Cells["nombre"].Value.ToString();
                    txtDescription.Text = dgvData.Rows[indice].Cells["descripcion"].Value.ToString();
                    txtCode.Text = dgvData.Rows[indice].Cells["codigo"].Value.ToString();
                    txtStock.Text = dgvData.Rows[indice].Cells["stock"].Value.ToString();
                    txtPCompra.Text = dgvData.Rows[indice].Cells["precio_compra"].Value.ToString();
                    txtPVenta.Text = dgvData.Rows[indice].Cells["precio_venta"].Value.ToString();
                }
            }

            if (dgvData.Columns[e.ColumnIndex].Name == "btnElimina")
            {
                string mensaje = string.Empty;

                Producto objProducto = new Producto()
                {
                    id_Producto = Convert.ToInt32(dgvData.Rows[indice].Cells["id"].Value.ToString())
                };

                if (objProducto.id_Producto != 0)
                {
                    boton = MessageBox.Show("¿Desea eliminar este producto?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    if (boton == DialogResult.OK)
                    {
                        bool resultado = new CN_Producto().Eliminar(objProducto, out mensaje);

                        if (resultado)
                        {
                            dgvData.Rows.RemoveAt(indice);
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show(mensaje);
                        }
                    }
                }
            }

            if (dgvData.Columns[e.ColumnIndex].Name == "btnEdita")
            {
                boton = MessageBox.Show("¿Desea editar este usuario?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (boton == DialogResult.OK)
                {
                    Muestra();
                    txtIndice.Text = indice.ToString();
                    txtIdP.Text = dgvData.Rows[indice].Cells["id"].Value.ToString();
                    txtCode.Text = dgvData.Rows[indice].Cells["codigo"].Value.ToString();
                    txtName.Text = dgvData.Rows[indice].Cells["nombre"].Value.ToString();
                    txtDescription.Text = dgvData.Rows[indice].Cells["descripcion"].Value.ToString();
                    txtStock.Text = dgvData.Rows[indice].Cells["stock"].Value.ToString();
                    txtPCompra.Text = dgvData.Rows[indice].Cells["precio_compra"].Value.ToString();
                    txtPVenta.Text = dgvData.Rows[indice].Cells["precio_venta"].Value.ToString();
                }
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Clear();
            Oculta();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.HeaderText!= "" && column.Visible)
                {
                    dt.Columns.Add(column.HeaderText, typeof(string));
                }
            }

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Visible)
                {
                    dt.Rows.Add(new object[]
                    {
                        row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString(),
                        row.Cells[3].Value.ToString(),
                        row.Cells[4].Value.ToString(),
                        row.Cells[5].Value.ToString(),
                        row.Cells[6].Value.ToString(),
                        row.Cells[8].Value.ToString(),
                    });
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("Reporte.xlsx");
            sfd.Filter = "Excel Files | * xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook wb = new XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Informe");
                    hoja.ColumnsUsed().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Reporte guardado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("No se pudo guardar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string col = ((OpcionCmb)cmbFiltro.SelectedItem).valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[col].Value.ToString().Trim().ToUpper().Contains(txtFiltro.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Clear();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 10)
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
    }
}
