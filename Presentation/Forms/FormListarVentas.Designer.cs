namespace Presentation.Forms
{
    partial class FormListarVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Code_marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_imponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_ruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl = new System.Windows.Forms.Label();
            this.btnDetalleVenta = new System.Windows.Forms.Button();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarXfecha = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(725, 461);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 20;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Buscar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(9, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 373);
            this.panel1.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code_marca,
            this.description,
            this.fecha_pago,
            this.proveedor_numero,
            this.base_imponible,
            this.igv,
            this.importe_total,
            this.observacion,
            this.company_ruc});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(812, 367);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Code_marca
            // 
            this.Code_marca.HeaderText = "Codigo";
            this.Code_marca.Name = "Code_marca";
            this.Code_marca.Width = 50;
            // 
            // description
            // 
            this.description.HeaderText = "Fecha de E";
            this.description.Name = "description";
            this.description.Width = 80;
            // 
            // fecha_pago
            // 
            this.fecha_pago.HeaderText = "Fecha de P.";
            this.fecha_pago.Name = "fecha_pago";
            this.fecha_pago.ReadOnly = true;
            this.fecha_pago.Width = 80;
            // 
            // proveedor_numero
            // 
            this.proveedor_numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proveedor_numero.HeaderText = "Cliente";
            this.proveedor_numero.Name = "proveedor_numero";
            this.proveedor_numero.ReadOnly = true;
            // 
            // base_imponible
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.base_imponible.DefaultCellStyle = dataGridViewCellStyle4;
            this.base_imponible.HeaderText = "Base Impo.";
            this.base_imponible.Name = "base_imponible";
            this.base_imponible.ReadOnly = true;
            this.base_imponible.Width = 70;
            // 
            // igv
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.igv.DefaultCellStyle = dataGridViewCellStyle5;
            this.igv.HeaderText = "Igv";
            this.igv.Name = "igv";
            this.igv.ReadOnly = true;
            this.igv.Width = 70;
            // 
            // importe_total
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.importe_total.DefaultCellStyle = dataGridViewCellStyle6;
            this.importe_total.HeaderText = "Importe Total";
            this.importe_total.Name = "importe_total";
            this.importe_total.ReadOnly = true;
            this.importe_total.Width = 70;
            // 
            // observacion
            // 
            this.observacion.HeaderText = "Observacion";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 70;
            // 
            // company_ruc
            // 
            this.company_ruc.HeaderText = "Comprobante";
            this.company_ruc.Name = "company_ruc";
            this.company_ruc.ReadOnly = true;
            this.company_ruc.Width = 80;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(313, 1);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(107, 38);
            this.lbl.TabIndex = 22;
            this.lbl.Text = "VENTAS";
            // 
            // btnDetalleVenta
            // 
            this.btnDetalleVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleVenta.Location = new System.Drawing.Point(577, 461);
            this.btnDetalleVenta.Name = "btnDetalleVenta";
            this.btnDetalleVenta.Size = new System.Drawing.Size(116, 23);
            this.btnDetalleVenta.TabIndex = 23;
            this.btnDetalleVenta.Text = "Mostrar Detalle";
            this.btnDetalleVenta.UseVisualStyleBackColor = true;
            this.btnDetalleVenta.Click += new System.EventHandler(this.btnDetalleVenta_Click);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(438, 44);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(113, 20);
            this.dtpFechaInicio.TabIndex = 24;
            this.dtpFechaInicio.Value = new System.DateTime(2020, 12, 2, 0, 0, 0, 0);
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(613, 44);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(114, 20);
            this.dtpFechaFin.TabIndex = 25;
            this.dtpFechaFin.Value = new System.DateTime(2020, 12, 2, 0, 0, 0, 0);
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "DESDE:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "HASTA:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnBuscarXfecha
            // 
            this.btnBuscarXfecha.Location = new System.Drawing.Point(749, 42);
            this.btnBuscarXfecha.Name = "btnBuscarXfecha";
            this.btnBuscarXfecha.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarXfecha.TabIndex = 28;
            this.btnBuscarXfecha.Text = "BUSCAR";
            this.btnBuscarXfecha.UseVisualStyleBackColor = true;
            this.btnBuscarXfecha.Click += new System.EventHandler(this.btnBuscarXfecha_Click);
            // 
            // FormListarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 512);
            this.Controls.Add(this.btnBuscarXfecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.btnDetalleVenta);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FormListarVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormListarVentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormListarVentas_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnDetalleVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code_marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_imponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_ruc;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarXfecha;
    }
}