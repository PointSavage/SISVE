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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

//CARGAR FORMULARIO -------------------------------------------------------------------------------------------------------------------------------------------------
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Oculta();
            cmbStatus.Items.Add(new OpcionCmb() { valor = 1, texto = "Activo" });
            cmbStatus.Items.Add(new OpcionCmb() { valor = 0, texto = "No Activo" });
            cmbStatus.DisplayMember = "texto";
            cmbStatus.ValueMember = "valor";
            cmbStatus.SelectedIndex = 0;

            List<Rol> listaRol = new CN_Rol().Listar();
            foreach (Rol item in listaRol)
            {
                cmbRol.Items.Add(new OpcionCmb { valor = item.id_rol, texto = item.descripcion });
            }
            cmbRol.DisplayMember = "texto";
            cmbRol.ValueMember = "valor";
            cmbRol.SelectedIndex = 0;

            //mostrar usuarios
            List<Usuario> listaUsuarios = new CN_Usuario().Listar();
            foreach (Usuario item in listaUsuarios)
            {
                dgvData.Rows.Add(new object[] { item.id_usuario, item.nombre, item.correo, item.clave,
                    item.objRol.id_rol,
                    item.objRol.descripcion,
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Usuario objUsuario = new Usuario()
            {
                id_usuario = Convert.ToInt32(txtIdU.Text),
                nombre = txtName.Text,
                correo = txtMail.Text,
                clave = txtPass.Text,
                objRol = new Rol() { id_rol = Convert.ToInt32(((OpcionCmb)cmbRol.SelectedItem).valor) },
                estado = Convert.ToInt32(((OpcionCmb)cmbStatus.SelectedItem).valor) == 1 ? true : false
            };

            if (objUsuario.id_usuario == 0)
            {
                int idU_resultado = new CN_Usuario().Registrar(objUsuario, out mensaje);


                if (idU_resultado != 0)
                {
                    //muestra los datos en el dgv
                    dgvData.Rows.Add(new object[] { idU_resultado, txtName.Text, txtMail.Text, txtPass.Text,
                    ((OpcionCmb)cmbRol.SelectedItem).valor.ToString(),
                    ((OpcionCmb)cmbRol.SelectedItem).texto.ToString(),
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
                bool resultado = new CN_Usuario().Editar(objUsuario, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["id"].Value = txtIdU.Text;
                    row.Cells["nombre"].Value = txtName.Text;
                    row.Cells["correo"].Value = txtMail.Text;
                    row.Cells["contrasena"].Value = txtPass.Text;
                    row.Cells["id_rol"].Value = ((OpcionCmb)cmbRol.SelectedItem).valor.ToString();
                    row.Cells["rol"].Value = ((OpcionCmb)cmbRol.SelectedItem).texto.ToString();
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

//CLIC EN EL DGV -------------------------------------------------------------------------------------------------------------------------------------------------------
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            DialogResult boton;

            if (dgvData.Columns[e.ColumnIndex].Name == "btnElimina")
            {
                string mensaje = string.Empty;

                Usuario objUsuario = new Usuario()
                {
                    id_usuario = Convert.ToInt32(dgvData.Rows[indice].Cells["id"].Value.ToString())
                };

                if (objUsuario.id_usuario != 0)
                {
                    boton = MessageBox.Show("¿Desea eliminar este usuario?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    if (boton == DialogResult.OK)
                    {
                        bool resultado = new CN_Usuario().Eliminar(objUsuario, out mensaje);

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

            if (dgvData.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                boton = MessageBox.Show("¿Desea editar este usuario?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (boton == DialogResult.OK)
                {
                    Muestra();
                    txtIndice.Text = indice.ToString();
                    txtIdU.Text = dgvData.Rows[indice].Cells["id"].Value.ToString();
                    txtName.Text = dgvData.Rows[indice].Cells["nombre"].Value.ToString();
                    txtMail.Text = dgvData.Rows[indice].Cells["correo"].Value.ToString();
                    txtPass.Text = dgvData.Rows[indice].Cells["contrasena"].Value.ToString();
                    txtCPass.Text = dgvData.Rows[indice].Cells["contrasena"].Value.ToString();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Muestra();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void Clear()
        {
            txtName.Clear();
            txtMail.Clear();
            txtPass.Clear();
            txtCPass.Clear();
            cmbRol.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            txtIndice.Text = "-1";
            txtIdU.Text = "0";
        }

        private void Oculta()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            txtCPass.Visible = false;
            txtIdU.Visible = false;
            txtIndice.Visible = false;
            txtMail.Visible = false;
            txtName.Visible = false;
            txtPass.Visible = false;
            cmbRol.Visible = false;
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
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            txtCPass.Visible = true;
            txtIdU.Visible = true;
            txtIndice.Visible = true;
            txtMail.Visible = true;
            txtName.Visible = true;
            txtPass.Visible = true;
            cmbRol.Visible = true;
            cmbStatus.Visible = true;
            btnSave.Visible = true;
            btnCancela.Visible = true;
        }

        private void btnBusca_Click(object sender, EventArgs e)
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

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Clear();
            Oculta();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Clear();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvData_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }



            if (e.ColumnIndex == 9)
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
