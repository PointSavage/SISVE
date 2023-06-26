namespace capa_presentacion
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mstrMenu = new System.Windows.Forms.MenuStrip();
            this.btnUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.btnProductos = new FontAwesome.Sharp.IconMenuItem();
            this.btnVenta = new FontAwesome.Sharp.IconMenuItem();
            this.btnCompra = new FontAwesome.Sharp.IconMenuItem();
            this.btnProveedor = new FontAwesome.Sharp.IconMenuItem();
            this.btnReporte = new FontAwesome.Sharp.IconMenuItem();
            this.smGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.smCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.smVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInfo = new FontAwesome.Sharp.IconMenuItem();
            this.smPerfilU = new System.Windows.Forms.ToolStripMenuItem();
            this.smPerfilN = new System.Windows.Forms.ToolStripMenuItem();
            this.mstrTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.mstrMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstrMenu
            // 
            this.mstrMenu.AutoSize = false;
            this.mstrMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.mstrMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUsuarios,
            this.btnProductos,
            this.btnVenta,
            this.btnCompra,
            this.btnProveedor,
            this.btnReporte,
            this.btnInfo});
            this.mstrMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.mstrMenu.Location = new System.Drawing.Point(0, 80);
            this.mstrMenu.Name = "mstrMenu";
            this.mstrMenu.Size = new System.Drawing.Size(145, 561);
            this.mstrMenu.TabIndex = 0;
            this.mstrMenu.Text = "menuStrip1";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.AutoSize = false;
            this.btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.btnUsuarios.IconColor = System.Drawing.Color.Black;
            this.btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuarios.IconSize = 50;
            this.btnUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(122, 69);
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.AutoSize = false;
            this.btnProductos.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.btnProductos.IconColor = System.Drawing.Color.Black;
            this.btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProductos.IconSize = 50;
            this.btnProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(122, 69);
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.AutoSize = false;
            this.btnVenta.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.btnVenta.IconColor = System.Drawing.Color.Black;
            this.btnVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVenta.IconSize = 50;
            this.btnVenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(122, 69);
            this.btnVenta.Text = "Registrar Venta";
            this.btnVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVenta.Click += new System.EventHandler(this.btnRVentas_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.AutoSize = false;
            this.btnCompra.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.btnCompra.IconColor = System.Drawing.Color.Black;
            this.btnCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCompra.IconSize = 50;
            this.btnCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(122, 69);
            this.btnCompra.Text = "Registrar Compra";
            this.btnCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCompra.Click += new System.EventHandler(this.btnRCompra_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.AutoSize = false;
            this.btnProveedor.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.btnProveedor.IconColor = System.Drawing.Color.Black;
            this.btnProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProveedor.IconSize = 50;
            this.btnProveedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(122, 69);
            this.btnProveedor.Text = "Proveedores";
            this.btnProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.AutoSize = false;
            this.btnReporte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smGeneral,
            this.smCompra,
            this.smVenta});
            this.btnReporte.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.btnReporte.IconColor = System.Drawing.Color.Black;
            this.btnReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReporte.IconSize = 50;
            this.btnReporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(122, 69);
            this.btnReporte.Text = "Reportes";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReporte.Visible = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // smGeneral
            // 
            this.smGeneral.Name = "smGeneral";
            this.smGeneral.Size = new System.Drawing.Size(180, 22);
            this.smGeneral.Text = "General";
            this.smGeneral.Click += new System.EventHandler(this.smGeneral_Click_1);
            // 
            // smCompra
            // 
            this.smCompra.Name = "smCompra";
            this.smCompra.Size = new System.Drawing.Size(180, 22);
            this.smCompra.Text = "Compra";
            this.smCompra.Click += new System.EventHandler(this.smCompra_Click);
            // 
            // smVenta
            // 
            this.smVenta.Name = "smVenta";
            this.smVenta.Size = new System.Drawing.Size(180, 22);
            this.smVenta.Text = "Venta";
            this.smVenta.Click += new System.EventHandler(this.smVenta_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.AutoSize = false;
            this.btnInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smPerfilU,
            this.smPerfilN});
            this.btnInfo.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.btnInfo.IconColor = System.Drawing.Color.Black;
            this.btnInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInfo.IconSize = 50;
            this.btnInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(122, 69);
            this.btnInfo.Text = "Acerca de";
            this.btnInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // smPerfilU
            // 
            this.smPerfilU.Name = "smPerfilU";
            this.smPerfilU.Size = new System.Drawing.Size(168, 22);
            this.smPerfilU.Text = "Perfil de Usuario";
            this.smPerfilU.Click += new System.EventHandler(this.smPerfilU_Click);
            // 
            // smPerfilN
            // 
            this.smPerfilN.Name = "smPerfilN";
            this.smPerfilN.Size = new System.Drawing.Size(168, 22);
            this.smPerfilN.Text = "Perfil del Negocio";
            this.smPerfilN.Click += new System.EventHandler(this.smPerfilN_Click);
            // 
            // mstrTitulo
            // 
            this.mstrTitulo.AutoSize = false;
            this.mstrTitulo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mstrTitulo.Location = new System.Drawing.Point(0, 0);
            this.mstrTitulo.Name = "mstrTitulo";
            this.mstrTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mstrTitulo.Size = new System.Drawing.Size(1090, 80);
            this.mstrTitulo.TabIndex = 1;
            this.mstrTitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.WindowText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "SISVE";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(145, 80);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(945, 561);
            this.pnlContenedor.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 20;
            this.btnClose.Location = new System.Drawing.Point(1042, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 33);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.SystemColors.WindowText;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUser.Location = new System.Drawing.Point(929, 33);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(78, 16);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "lblUsuario";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.BackColor = System.Drawing.SystemColors.WindowText;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRol.Location = new System.Drawing.Point(830, 33);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(61, 16);
            this.lblRol.TabIndex = 7;
            this.lblRol.Text = "Usuario";
            this.lblRol.Visible = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 641);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mstrMenu);
            this.Controls.Add(this.mstrTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.mstrMenu;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Home_Load);
            this.mstrMenu.ResumeLayout(false);
            this.mstrMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstrMenu;
        private System.Windows.Forms.MenuStrip mstrTitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem btnInfo;
        private FontAwesome.Sharp.IconMenuItem btnProductos;
        private FontAwesome.Sharp.IconMenuItem btnProveedor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private FontAwesome.Sharp.IconMenuItem btnUsuarios;
        private System.Windows.Forms.Panel pnlContenedor;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ToolStripMenuItem smPerfilU;
        private System.Windows.Forms.ToolStripMenuItem smPerfilN;
        private FontAwesome.Sharp.IconMenuItem btnVenta;
        private FontAwesome.Sharp.IconMenuItem btnCompra;
        private FontAwesome.Sharp.IconMenuItem btnReporte;
        private System.Windows.Forms.ToolStripMenuItem smGeneral;
        private System.Windows.Forms.ToolStripMenuItem smCompra;
        private System.Windows.Forms.ToolStripMenuItem smVenta;
    }
}

