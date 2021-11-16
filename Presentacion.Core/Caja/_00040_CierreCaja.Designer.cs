namespace Presentacion.Core.Caja
{
    partial class _00040_CierreCaja
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
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.txtTotalEfectivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCajaInicial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCtaCte2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCheque2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTarjeta2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCtaCte = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVerDetalleGastos = new System.Windows.Forms.Button();
            this.btnVerDetalleCompra = new System.Windows.Forms.Button();
            this.txtGastos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompras = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVerDetalleVenta = new System.Windows.Forms.Button();
            this.txtVentas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.pnlTotales.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.Black;
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparador.Location = new System.Drawing.Point(0, 58);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(785, 4);
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
            this.toolStrip1.Size = new System.Drawing.Size(785, 58);
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
            // pnlTotales
            // 
            this.pnlTotales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTotales.Controls.Add(this.lblFechaApertura);
            this.pnlTotales.Controls.Add(this.txtTotalEfectivo);
            this.pnlTotales.Controls.Add(this.label1);
            this.pnlTotales.Controls.Add(this.txtCajaInicial);
            this.pnlTotales.Controls.Add(this.label2);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTotales.Location = new System.Drawing.Point(0, 62);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(785, 77);
            this.pnlTotales.TabIndex = 8;
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaApertura.Location = new System.Drawing.Point(540, 7);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(230, 57);
            this.lblFechaApertura.TabIndex = 8;
            this.lblFechaApertura.Text = "Fecha Apertura\r\n30/08/2019";
            this.lblFechaApertura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalEfectivo
            // 
            this.txtTotalEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalEfectivo.Location = new System.Drawing.Point(306, 34);
            this.txtTotalEfectivo.Name = "txtTotalEfectivo";
            this.txtTotalEfectivo.ReadOnly = true;
            this.txtTotalEfectivo.Size = new System.Drawing.Size(218, 31);
            this.txtTotalEfectivo.TabIndex = 7;
            this.txtTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total en Efectivo";
            // 
            // txtCajaInicial
            // 
            this.txtCajaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCajaInicial.Location = new System.Drawing.Point(26, 34);
            this.txtCajaInicial.Name = "txtCajaInicial";
            this.txtCajaInicial.ReadOnly = true;
            this.txtCajaInicial.Size = new System.Drawing.Size(218, 31);
            this.txtCajaInicial.TabIndex = 5;
            this.txtCajaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Caja Inicial";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCtaCte2);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtCheque2);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtTarjeta2);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(403, 272);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(369, 148);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[ Total de Salidas ]";
            // 
            // txtCtaCte2
            // 
            this.txtCtaCte2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCtaCte2.Location = new System.Drawing.Point(140, 105);
            this.txtCtaCte2.Name = "txtCtaCte2";
            this.txtCtaCte2.Size = new System.Drawing.Size(205, 26);
            this.txtCtaCte2.TabIndex = 9;
            this.txtCtaCte2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(6, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Cuenta Corriente";
            // 
            // txtCheque2
            // 
            this.txtCheque2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCheque2.Location = new System.Drawing.Point(140, 72);
            this.txtCheque2.Name = "txtCheque2";
            this.txtCheque2.Size = new System.Drawing.Size(205, 26);
            this.txtCheque2.TabIndex = 5;
            this.txtCheque2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label13.Location = new System.Drawing.Point(69, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "Cheque";
            // 
            // txtTarjeta2
            // 
            this.txtTarjeta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTarjeta2.Location = new System.Drawing.Point(140, 40);
            this.txtTarjeta2.Name = "txtTarjeta2";
            this.txtTarjeta2.Size = new System.Drawing.Size(205, 26);
            this.txtTarjeta2.TabIndex = 3;
            this.txtTarjeta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label14.Location = new System.Drawing.Point(76, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 20);
            this.label14.TabIndex = 2;
            this.label14.Text = "Tarjeta";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCtaCte);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtCheque);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTarjeta);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 148);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ Total de Ingresos ]";
            // 
            // txtCtaCte
            // 
            this.txtCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCtaCte.Location = new System.Drawing.Point(140, 105);
            this.txtCtaCte.Name = "txtCtaCte";
            this.txtCtaCte.Size = new System.Drawing.Size(205, 26);
            this.txtCtaCte.TabIndex = 9;
            this.txtCtaCte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(6, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Cuenta Corriente";
            // 
            // txtCheque
            // 
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCheque.Location = new System.Drawing.Point(140, 72);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(205, 26);
            this.txtCheque.TabIndex = 5;
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(69, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Cheque";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTarjeta.Location = new System.Drawing.Point(140, 40);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(205, 26);
            this.txtTarjeta.TabIndex = 3;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(76, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tarjeta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVerDetalleGastos);
            this.groupBox2.Controls.Add(this.btnVerDetalleCompra);
            this.groupBox2.Controls.Add(this.txtGastos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCompras);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(403, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 115);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ Salidas del Día ]";
            // 
            // btnVerDetalleGastos
            // 
            this.btnVerDetalleGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalleGastos.Location = new System.Drawing.Point(315, 66);
            this.btnVerDetalleGastos.Name = "btnVerDetalleGastos";
            this.btnVerDetalleGastos.Size = new System.Drawing.Size(30, 26);
            this.btnVerDetalleGastos.TabIndex = 7;
            this.btnVerDetalleGastos.Text = "...";
            this.btnVerDetalleGastos.UseVisualStyleBackColor = true;
            // 
            // btnVerDetalleCompra
            // 
            this.btnVerDetalleCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalleCompra.Location = new System.Drawing.Point(315, 33);
            this.btnVerDetalleCompra.Name = "btnVerDetalleCompra";
            this.btnVerDetalleCompra.Size = new System.Drawing.Size(30, 26);
            this.btnVerDetalleCompra.TabIndex = 6;
            this.btnVerDetalleCompra.Text = "...";
            this.btnVerDetalleCompra.UseVisualStyleBackColor = true;
            // 
            // txtGastos
            // 
            this.txtGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGastos.Location = new System.Drawing.Point(126, 65);
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.Size = new System.Drawing.Size(183, 26);
            this.txtGastos.TabIndex = 5;
            this.txtGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(59, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Gastos";
            // 
            // txtCompras
            // 
            this.txtCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCompras.Location = new System.Drawing.Point(126, 33);
            this.txtCompras.Name = "txtCompras";
            this.txtCompras.Size = new System.Drawing.Size(183, 26);
            this.txtCompras.TabIndex = 3;
            this.txtCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(47, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Compras";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVerDetalleVenta);
            this.groupBox1.Controls.Add(this.txtVentas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 115);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Ingresos Efectivo del Día ]";
            // 
            // btnVerDetalleVenta
            // 
            this.btnVerDetalleVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalleVenta.Location = new System.Drawing.Point(303, 40);
            this.btnVerDetalleVenta.Name = "btnVerDetalleVenta";
            this.btnVerDetalleVenta.Size = new System.Drawing.Size(30, 26);
            this.btnVerDetalleVenta.TabIndex = 6;
            this.btnVerDetalleVenta.Text = "...";
            this.btnVerDetalleVenta.UseVisualStyleBackColor = true;
            this.btnVerDetalleVenta.Click += new System.EventHandler(this.btnVerDetalleVenta_Click);
            // 
            // txtVentas
            // 
            this.txtVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtVentas.Location = new System.Drawing.Point(114, 40);
            this.txtVentas.Name = "txtVentas";
            this.txtVentas.Size = new System.Drawing.Size(183, 26);
            this.txtVentas.TabIndex = 3;
            this.txtVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(48, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ventas";
            // 
            // _00040_CierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 432);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(801, 471);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(801, 471);
            this.Name = "_00040_CierreCaja";
            this.Text = "Cierre de Caja";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton btnEjecutar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.TextBox txtTotalEfectivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCajaInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCtaCte2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCheque2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTarjeta2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCtaCte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnVerDetalleGastos;
        private System.Windows.Forms.Button btnVerDetalleCompra;
        private System.Windows.Forms.TextBox txtGastos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVerDetalleVenta;
        private System.Windows.Forms.TextBox txtVentas;
        private System.Windows.Forms.Label label4;
    }
}