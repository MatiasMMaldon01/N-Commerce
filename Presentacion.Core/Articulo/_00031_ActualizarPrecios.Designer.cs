namespace Presentacion.Core.Articulo
{
    partial class _00031_ActualizarPrecios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.RdbPrecio = new System.Windows.Forms.RadioButton();
            this.rdbPorcentaje = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nudValor = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbListaPrecio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.chkArticulo = new System.Windows.Forms.CheckBox();
            this.chkRubro = new System.Windows.Forms.CheckBox();
            this.chkMarca = new System.Windows.Forms.CheckBox();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.nudCodigoDesde = new System.Windows.Forms.NumericUpDown();
            this.nudCodigoHasta = new System.Windows.Forms.NumericUpDown();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.chkListaPrecio = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigoDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigoHasta)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.Black;
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparador.Location = new System.Drawing.Point(0, 58);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(502, 4);
            this.pnlSeparador.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Navy;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEjecutar,
            this.btnLimpiar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Size = new System.Drawing.Size(502, 58);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEjecutar.Image = global::Presentacion.Core.Properties.Resources.checked_2;
            this.btnEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(53, 49);
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLimpiar.Image = global::Presentacion.Core.Properties.Resources.compartimiento;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(51, 49);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.Image = global::Presentacion.Core.Properties.Resources.cancel_2;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(34, 49);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // RdbPrecio
            // 
            this.RdbPrecio.AutoSize = true;
            this.RdbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbPrecio.Location = new System.Drawing.Point(311, 283);
            this.RdbPrecio.Name = "RdbPrecio";
            this.RdbPrecio.Size = new System.Drawing.Size(47, 20);
            this.RdbPrecio.TabIndex = 184;
            this.RdbPrecio.Text = "[ $ ]";
            this.RdbPrecio.UseVisualStyleBackColor = true;
            // 
            // rdbPorcentaje
            // 
            this.rdbPorcentaje.AutoSize = true;
            this.rdbPorcentaje.Checked = true;
            this.rdbPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPorcentaje.Location = new System.Drawing.Point(260, 283);
            this.rdbPorcentaje.Name = "rdbPorcentaje";
            this.rdbPorcentaje.Size = new System.Drawing.Size(52, 20);
            this.rdbPorcentaje.TabIndex = 183;
            this.rdbPorcentaje.TabStop = true;
            this.rdbPorcentaje.Text = "[ % ]";
            this.rdbPorcentaje.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(77, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 182;
            this.label2.Text = "Valor";
            // 
            // nudValor
            // 
            this.nudValor.DecimalPlaces = 2;
            this.nudValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudValor.Location = new System.Drawing.Point(123, 281);
            this.nudValor.Name = "nudValor";
            this.nudValor.Size = new System.Drawing.Size(120, 22);
            this.nudValor.TabIndex = 181;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(11, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 4);
            this.panel1.TabIndex = 180;
            // 
            // cmbListaPrecio
            // 
            this.cmbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaPrecio.Enabled = false;
            this.cmbListaPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListaPrecio.FormattingEnabled = true;
            this.cmbListaPrecio.Location = new System.Drawing.Point(137, 242);
            this.cmbListaPrecio.Name = "cmbListaPrecio";
            this.cmbListaPrecio.Size = new System.Drawing.Size(337, 24);
            this.cmbListaPrecio.TabIndex = 178;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(307, 178);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 177;
            this.label1.Text = "Codigo hasta";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Enabled = false;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(152, 177);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 16);
            this.label17.TabIndex = 175;
            this.label17.Text = "Codigo desde";
            // 
            // chkArticulo
            // 
            this.chkArticulo.AutoSize = true;
            this.chkArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkArticulo.Location = new System.Drawing.Point(47, 195);
            this.chkArticulo.Name = "chkArticulo";
            this.chkArticulo.Size = new System.Drawing.Size(71, 20);
            this.chkArticulo.TabIndex = 173;
            this.chkArticulo.Text = "Articulo";
            this.chkArticulo.UseVisualStyleBackColor = true;
            this.chkArticulo.CheckedChanged += new System.EventHandler(this.chkArticulo_CheckedChanged);
            // 
            // chkRubro
            // 
            this.chkRubro.AutoSize = true;
            this.chkRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRubro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkRubro.Location = new System.Drawing.Point(47, 145);
            this.chkRubro.Name = "chkRubro";
            this.chkRubro.Size = new System.Drawing.Size(64, 20);
            this.chkRubro.TabIndex = 172;
            this.chkRubro.Text = "Rubro";
            this.chkRubro.UseVisualStyleBackColor = true;
            this.chkRubro.CheckedChanged += new System.EventHandler(this.chkRubro_CheckedChanged);
            // 
            // chkMarca
            // 
            this.chkMarca.AutoSize = true;
            this.chkMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkMarca.Location = new System.Drawing.Point(47, 117);
            this.chkMarca.Name = "chkMarca";
            this.chkMarca.Size = new System.Drawing.Size(65, 20);
            this.chkMarca.TabIndex = 171;
            this.chkMarca.Text = "Marca";
            this.chkMarca.UseVisualStyleBackColor = true;
            this.chkMarca.CheckedChanged += new System.EventHandler(this.chkMarca_CheckedChanged);
            // 
            // cmbRubro
            // 
            this.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubro.Enabled = false;
            this.cmbRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(137, 145);
            this.cmbRubro.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(337, 24);
            this.cmbRubro.TabIndex = 170;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Enabled = false;
            this.cmbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarca.Location = new System.Drawing.Point(137, 117);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(337, 24);
            this.cmbMarca.TabIndex = 169;
            // 
            // nudCodigoDesde
            // 
            this.nudCodigoDesde.Enabled = false;
            this.nudCodigoDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCodigoDesde.Location = new System.Drawing.Point(140, 197);
            this.nudCodigoDesde.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.nudCodigoDesde.Name = "nudCodigoDesde";
            this.nudCodigoDesde.Size = new System.Drawing.Size(120, 22);
            this.nudCodigoDesde.TabIndex = 185;
            // 
            // nudCodigoHasta
            // 
            this.nudCodigoHasta.Enabled = false;
            this.nudCodigoHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCodigoHasta.Location = new System.Drawing.Point(288, 197);
            this.nudCodigoHasta.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.nudCodigoHasta.Name = "nudCodigoHasta";
            this.nudCodigoHasta.Size = new System.Drawing.Size(120, 22);
            this.nudCodigoHasta.TabIndex = 186;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(77, 75);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 187;
            this.lblFecha.Text = "Fecha";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(18, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 4);
            this.panel2.TabIndex = 181;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(147, 75);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(211, 20);
            this.dtpFecha.TabIndex = 188;
            // 
            // chkListaPrecio
            // 
            this.chkListaPrecio.AutoSize = true;
            this.chkListaPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListaPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkListaPrecio.Location = new System.Drawing.Point(8, 244);
            this.chkListaPrecio.Name = "chkListaPrecio";
            this.chkListaPrecio.Size = new System.Drawing.Size(123, 20);
            this.chkListaPrecio.TabIndex = 190;
            this.chkListaPrecio.Text = "Lista de Precios";
            this.chkListaPrecio.UseVisualStyleBackColor = true;
            this.chkListaPrecio.CheckedChanged += new System.EventHandler(this.chkListaPrecio_CheckedChanged);
            // 
            // _00031_ActualizarPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 360);
            this.Controls.Add(this.chkListaPrecio);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.nudCodigoHasta);
            this.Controls.Add(this.nudCodigoDesde);
            this.Controls.Add(this.RdbPrecio);
            this.Controls.Add(this.rdbPorcentaje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudValor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbListaPrecio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.chkArticulo);
            this.Controls.Add(this.chkRubro);
            this.Controls.Add(this.chkMarca);
            this.Controls.Add(this.cmbRubro);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(502, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(502, 360);
            this.Name = "_00031_ActualizarPrecios";
            this.Text = "Actualización de Precios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigoDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigoHasta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton btnEjecutar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.RadioButton RdbPrecio;
        private System.Windows.Forms.RadioButton rdbPorcentaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudValor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbListaPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkArticulo;
        private System.Windows.Forms.CheckBox chkRubro;
        private System.Windows.Forms.CheckBox chkMarca;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.NumericUpDown nudCodigoDesde;
        private System.Windows.Forms.NumericUpDown nudCodigoHasta;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox chkListaPrecio;
    }
}