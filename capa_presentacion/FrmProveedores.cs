using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_presentacion.Utilidades;
using capa_entidad;
using capa_negocio;

namespace capa_presentacion
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtName.Clear();
            txtMail.Clear();
            txtTel.Clear();
            cmbStatus.SelectedIndex = 0;
            txtIndice.Text = "-1";
            txtIdP.Text = "0";
        }

        private void Oculta()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            txtIdP.Visible = false;
            txtIndice.Visible = false;
            txtMail.Visible = false;
            txtName.Visible = false;
            txtTel.Visible = false;
            cmbStatus.Visible = false;
            btnSave.Visible = false;
            btnCancela.Visible = false;
        }

        private void Muestra()
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label6.Visible = true;
            label8.Visible = true;
            txtIdP.Visible = true;
            txtIndice.Visible = true;
            txtMail.Visible = true;
            txtName.Visible = true;
            txtTel.Visible = true;
            cmbStatus.Visible = true;
            btnSave.Visible = true;
            btnCancela.Visible = true;
        }

//CARGAR FORMULARIO ------------------------------------------------------------------------------------------------------------------------------------------------
        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            Oculta();
            cmbStatus.Items.Add(new OpcionCmb() { valor = 1, texto = "Activo" });
            cmbStatus.Items.Add(new OpcionCmb() { valor = 0, texto = "No Activo" });
            cmbStatus.DisplayMember = "texto";
            cmbStatus.ValueMember = "valor";
            cmbStatus.SelectedIndex = 0;

            //mostrar proveedores
            List<Proveedor> listaProveedor = new CN_Proveedor().Listar();
            foreach (Proveedor item in listaProveedor)
            {
                dgvData.Rows.Add(new object[] { item.id_proveedor, item.nombre, item.correo, item.telefono,
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

//GUARDAR CAMBIOS -------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Proveedor objProveedor = new Proveedor()
            {
                id_proveedor = Convert.ToInt32(txtIdP.Text),
                nombre = txtName.Text,
                correo = txtMail.Text,
                telefono = txtTel.Text,
                estado = Convert.ToInt32(((OpcionCmb)cmbStatus.SelectedItem).valor) == 1 ? true : false
            };

            if (objProveedor.id_proveedor == 0)
            {
                int idU_resultado = new CN_Proveedor().Registrar(objProveedor, out mensaje);


                if (idU_resultado != 0)
                {
                    //muestra los datos en el dgv
                    dgvData.Rows.Add(new object[] { idU_resultado, txtName.Text, txtMail.Text, txtTel.Text,
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
                bool resultado = new CN_Proveedor().Editar(objProveedor, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["id"].Value = txtIdP.Text;
                    row.Cells["nombre"].Value = txtName.Text;
                    row.Cells["correo"].Value = txtMail.Text;
                    row.Cells["tel"].Value = txtTel.Text;
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

        private void btnCancela_Click_1(object sender, EventArgs e)
        {
            Clear();
            Oculta();
        }

//CLIC EN EL DGV -------------------------------------------------------------------------------------------------------------------------------------------------------
        private void dgvData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            DialogResult boton;

            if (dgvData.Columns[e.ColumnIndex].Name == "btnElimina")
            {
                string mensaje = string.Empty;

                Proveedor objProveedor = new Proveedor()
                {
                    id_proveedor = Convert.ToInt32(dgvData.Rows[indice].Cells["id"].Value.ToString())
                };

                if (objProveedor.id_proveedor != 0)
                {
                    boton = MessageBox.Show("¿Desea eliminar este proveedor?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    if (boton == DialogResult.OK)
                    {
                        bool resultado = new CN_Proveedor().Eliminar(objProveedor, out mensaje);

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
                boton = MessageBox.Show("¿Desea editar este proveedor?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (boton == DialogResult.OK)
                {
                    Muestra();
                    txtIndice.Text = indice.ToString();
                    txtIdP.Text = dgvData.Rows[indice].Cells["id"].Value.ToString();
                    txtName.Text = dgvData.Rows[indice].Cells["nombre"].Value.ToString();
                    txtMail.Text = dgvData.Rows[indice].Cells["correo"].Value.ToString();
                    txtTel.Text = dgvData.Rows[indice].Cells["tel"].Value.ToString();
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
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

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            Muestra();
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

            if (e.ColumnIndex == 7)
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
