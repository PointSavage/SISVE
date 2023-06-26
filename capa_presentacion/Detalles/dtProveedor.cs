using capa_entidad;
using capa_presentacion.Utilidades;
using capa_negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capa_presentacion.Detalles
{
    public partial class dtProveedor : Form
    {
        public Proveedor objProveedor { get; set; }
        public dtProveedor()
        {
            InitializeComponent();
        }

        private void dtProveedor_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true)
                {
                    cmbFiltro.Items.Add(new OpcionCmb() { valor = columna.Name, texto = columna.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "texto";
            cmbFiltro.ValueMember = "valor";
            cmbFiltro.SelectedIndex = 0;

            List<Proveedor> lista = new CN_Proveedor().Listar();
            foreach (Proveedor item in lista)
            {
                dgvData.Rows.Add(new object[] { item.id_proveedor, item.nombre });
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;

            if (iRow >= 0 && iColumn > 0)
            {
                objProveedor = new Proveedor()
                {
                    id_proveedor = Convert.ToInt32(dgvData.Rows[iRow].Cells["id"].Value.ToString()),
                    nombre = dgvData.Rows[iRow].Cells["nombre"].Value.ToString(),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
