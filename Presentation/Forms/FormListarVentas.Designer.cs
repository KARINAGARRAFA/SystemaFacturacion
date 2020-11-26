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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Code_marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdp_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdp_serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdp_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_exportacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_imponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe_total_exonerada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe_total_inafecta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_cambi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.igv_retencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detraccion_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constancia_detraccion_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constancia_detraccion_fecha_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constancia_detraccion_monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constancia_detraccion_referencia_monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_ruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(713, 441);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 20;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(748, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Buscar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(9, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 347);
            this.panel1.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code_marca,
            this.product_name,
            this.description,
            this.fecha_pago,
            this.cdp_tipo,
            this.cdp_serie,
            this.cdp_numero,
            this.proveedor_tipo,
            this.proveedor_numero,
            this.valor_exportacion,
            this.base_imponible,
            this.importe_total_exonerada,
            this.importe_total_inafecta,
            this.igv,
            this.importe_total,
            this.dolares,
            this.tipo_cambi,
            this.igv_retencion,
            this.detraccion_id,
            this.constancia_detraccion_numero,
            this.constancia_detraccion_fecha_pago,
            this.constancia_detraccion_monto,
            this.constancia_detraccion_referencia_monto,
            this.observacion,
            this.company_ruc});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(812, 341);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(365, 8);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(107, 38);
            this.lbl.TabIndex = 22;
            this.lbl.Text = "VENTAS";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Code_marca
            // 
            this.Code_marca.HeaderText = "Codigo";
            this.Code_marca.Name = "Code_marca";
            this.Code_marca.Width = 50;
            // 
            // product_name
            // 
            this.product_name.HeaderText = "#";
            this.product_name.Name = "product_name";
            this.product_name.Width = 30;
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
            // cdp_tipo
            // 
            this.cdp_tipo.HeaderText = "Tipo de C.";
            this.cdp_tipo.Name = "cdp_tipo";
            this.cdp_tipo.ReadOnly = true;
            this.cdp_tipo.Width = 50;
            // 
            // cdp_serie
            // 
            this.cdp_serie.HeaderText = "Serie C.";
            this.cdp_serie.Name = "cdp_serie";
            this.cdp_serie.ReadOnly = true;
            this.cdp_serie.Width = 50;
            // 
            // cdp_numero
            // 
            this.cdp_numero.HeaderText = "Numero C.";
            this.cdp_numero.Name = "cdp_numero";
            this.cdp_numero.ReadOnly = true;
            this.cdp_numero.Width = 50;
            // 
            // proveedor_tipo
            // 
            this.proveedor_tipo.HeaderText = "Tipo Cliente";
            this.proveedor_tipo.Name = "proveedor_tipo";
            this.proveedor_tipo.ReadOnly = true;
            this.proveedor_tipo.Width = 30;
            // 
            // proveedor_numero
            // 
            this.proveedor_numero.HeaderText = "Ruc Cliente";
            this.proveedor_numero.Name = "proveedor_numero";
            this.proveedor_numero.ReadOnly = true;
            this.proveedor_numero.Width = 70;
            // 
            // valor_exportacion
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.valor_exportacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.valor_exportacion.HeaderText = "Valor de E.";
            this.valor_exportacion.Name = "valor_exportacion";
            this.valor_exportacion.ReadOnly = true;
            this.valor_exportacion.Width = 40;
            // 
            // base_imponible
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.base_imponible.DefaultCellStyle = dataGridViewCellStyle2;
            this.base_imponible.HeaderText = "Base Impo.";
            this.base_imponible.Name = "base_imponible";
            this.base_imponible.ReadOnly = true;
            this.base_imponible.Width = 70;
            // 
            // importe_total_exonerada
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.importe_total_exonerada.DefaultCellStyle = dataGridViewCellStyle3;
            this.importe_total_exonerada.HeaderText = "I. T. Exonerada";
            this.importe_total_exonerada.Name = "importe_total_exonerada";
            this.importe_total_exonerada.ReadOnly = true;
            this.importe_total_exonerada.Width = 50;
            // 
            // importe_total_inafecta
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.importe_total_inafecta.DefaultCellStyle = dataGridViewCellStyle4;
            this.importe_total_inafecta.HeaderText = "I. T. Inafecta";
            this.importe_total_inafecta.Name = "importe_total_inafecta";
            this.importe_total_inafecta.ReadOnly = true;
            this.importe_total_inafecta.Width = 50;
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
            // dolares
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.dolares.DefaultCellStyle = dataGridViewCellStyle7;
            this.dolares.HeaderText = "Dolares";
            this.dolares.Name = "dolares";
            this.dolares.ReadOnly = true;
            this.dolares.Width = 40;
            // 
            // tipo_cambi
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle8.Format = "N3";
            dataGridViewCellStyle8.NullValue = null;
            this.tipo_cambi.DefaultCellStyle = dataGridViewCellStyle8;
            this.tipo_cambi.HeaderText = "Tipo Cambio";
            this.tipo_cambi.Name = "tipo_cambi";
            this.tipo_cambi.ReadOnly = true;
            this.tipo_cambi.Width = 40;
            // 
            // igv_retencion
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.igv_retencion.DefaultCellStyle = dataGridViewCellStyle9;
            this.igv_retencion.HeaderText = "Igv Reten.";
            this.igv_retencion.Name = "igv_retencion";
            this.igv_retencion.ReadOnly = true;
            this.igv_retencion.Width = 40;
            // 
            // detraccion_id
            // 
            this.detraccion_id.HeaderText = "DetraccionID";
            this.detraccion_id.Name = "detraccion_id";
            this.detraccion_id.ReadOnly = true;
            this.detraccion_id.Width = 40;
            // 
            // constancia_detraccion_numero
            // 
            this.constancia_detraccion_numero.HeaderText = "Constancia Detraccion Numero";
            this.constancia_detraccion_numero.Name = "constancia_detraccion_numero";
            this.constancia_detraccion_numero.Width = 50;
            // 
            // constancia_detraccion_fecha_pago
            // 
            this.constancia_detraccion_fecha_pago.HeaderText = "Constancia Detraccion Fecha Pago";
            this.constancia_detraccion_fecha_pago.Name = "constancia_detraccion_fecha_pago";
            this.constancia_detraccion_fecha_pago.ReadOnly = true;
            this.constancia_detraccion_fecha_pago.Width = 50;
            // 
            // constancia_detraccion_monto
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.constancia_detraccion_monto.DefaultCellStyle = dataGridViewCellStyle10;
            this.constancia_detraccion_monto.HeaderText = "Constancia Detraccion Monto";
            this.constancia_detraccion_monto.Name = "constancia_detraccion_monto";
            this.constancia_detraccion_monto.ReadOnly = true;
            this.constancia_detraccion_monto.Width = 50;
            // 
            // constancia_detraccion_referencia_monto
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.constancia_detraccion_referencia_monto.DefaultCellStyle = dataGridViewCellStyle11;
            this.constancia_detraccion_referencia_monto.HeaderText = "Constancia Detraccion Referencia Monto";
            this.constancia_detraccion_referencia_monto.Name = "constancia_detraccion_referencia_monto";
            this.constancia_detraccion_referencia_monto.ReadOnly = true;
            this.constancia_detraccion_referencia_monto.Width = 50;
            // 
            // observacion
            // 
            this.observacion.HeaderText = "Observacion";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 60;
            // 
            // company_ruc
            // 
            this.company_ruc.HeaderText = "Ruc Compañia";
            this.company_ruc.Name = "company_ruc";
            this.company_ruc.ReadOnly = true;
            this.company_ruc.Width = 70;
            // 
            // FormListarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 512);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code_marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdp_tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdp_serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdp_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor_tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_exportacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_imponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe_total_exonerada;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe_total_inafecta;
        private System.Windows.Forms.DataGridViewTextBoxColumn igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_cambi;
        private System.Windows.Forms.DataGridViewTextBoxColumn igv_retencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn detraccion_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn constancia_detraccion_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn constancia_detraccion_fecha_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn constancia_detraccion_monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn constancia_detraccion_referencia_monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_ruc;
    }
}