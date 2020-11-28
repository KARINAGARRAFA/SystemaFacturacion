namespace Presentation.Forms
{
    partial class FormRegistroProducto
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode_product = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbProductosCompania = new System.Windows.Forms.GroupBox();
            this.txtUM = new System.Windows.Forms.TextBox();
            this.txtRuc_Pcomopany = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCode_category = new System.Windows.Forms.TextBox();
            this.txtCode_brand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProduct_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuscarProduct = new System.Windows.Forms.TextBox();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbProductosCompania.SuspendLayout();
            this.gbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // txtCode_product
            // 
            this.txtCode_product.Location = new System.Drawing.Point(86, 29);
            this.txtCode_product.Name = "txtCode_product";
            this.txtCode_product.Size = new System.Drawing.Size(100, 20);
            this.txtCode_product.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // gbProductosCompania
            // 
            this.gbProductosCompania.Controls.Add(this.txtUM);
            this.gbProductosCompania.Controls.Add(this.txtRuc_Pcomopany);
            this.gbProductosCompania.Controls.Add(this.label7);
            this.gbProductosCompania.Controls.Add(this.btnCancelar);
            this.gbProductosCompania.Controls.Add(this.txtPrecio);
            this.gbProductosCompania.Controls.Add(this.btnGuardar);
            this.gbProductosCompania.Controls.Add(this.txtCode_category);
            this.gbProductosCompania.Controls.Add(this.txtCode_brand);
            this.gbProductosCompania.Controls.Add(this.label5);
            this.gbProductosCompania.Controls.Add(this.label4);
            this.gbProductosCompania.Controls.Add(this.label3);
            this.gbProductosCompania.Controls.Add(this.txtProduct_name);
            this.gbProductosCompania.Controls.Add(this.label1);
            this.gbProductosCompania.Controls.Add(this.label2);
            this.gbProductosCompania.Controls.Add(this.txtCode_product);
            this.gbProductosCompania.Location = new System.Drawing.Point(3, 186);
            this.gbProductosCompania.Name = "gbProductosCompania";
            this.gbProductosCompania.Size = new System.Drawing.Size(524, 161);
            this.gbProductosCompania.TabIndex = 3;
            this.gbProductosCompania.TabStop = false;
            this.gbProductosCompania.Text = "Producto de la Compañia";
            // 
            // txtUM
            // 
            this.txtUM.Location = new System.Drawing.Point(323, 92);
            this.txtUM.Name = "txtUM";
            this.txtUM.Size = new System.Drawing.Size(100, 20);
            this.txtUM.TabIndex = 11;
            // 
            // txtRuc_Pcomopany
            // 
            this.txtRuc_Pcomopany.Location = new System.Drawing.Point(147, 135);
            this.txtRuc_Pcomopany.Name = "txtRuc_Pcomopany";
            this.txtRuc_Pcomopany.Size = new System.Drawing.Size(100, 20);
            this.txtRuc_Pcomopany.TabIndex = 12;
            this.txtRuc_Pcomopany.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Unidad Medida";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(363, 132);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(86, 95);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 9;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(253, 132);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCode_category
            // 
            this.txtCode_category.Location = new System.Drawing.Point(323, 56);
            this.txtCode_category.Name = "txtCode_category";
            this.txtCode_category.Size = new System.Drawing.Size(100, 20);
            this.txtCode_category.TabIndex = 8;
            // 
            // txtCode_brand
            // 
            this.txtCode_brand.Location = new System.Drawing.Point(86, 59);
            this.txtCode_brand.Name = "txtCode_brand";
            this.txtCode_brand.Size = new System.Drawing.Size(100, 20);
            this.txtCode_brand.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Marca";
            // 
            // txtProduct_name
            // 
            this.txtProduct_name.Location = new System.Drawing.Point(323, 26);
            this.txtProduct_name.Name = "txtProduct_name";
            this.txtProduct_name.Size = new System.Drawing.Size(100, 20);
            this.txtProduct_name.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "REGISTRO DE PRODUCTO";
            // 
            // txtBuscarProduct
            // 
            this.txtBuscarProduct.Location = new System.Drawing.Point(60, 19);
            this.txtBuscarProduct.Name = "txtBuscarProduct";
            this.txtBuscarProduct.Size = new System.Drawing.Size(458, 20);
            this.txtBuscarProduct.TabIndex = 14;
            this.txtBuscarProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProduct_KeyPress);
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.dataGridView1);
            this.gbProductos.Controls.Add(this.label8);
            this.gbProductos.Controls.Add(this.txtBuscarProduct);
            this.gbProductos.Location = new System.Drawing.Point(3, 3);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(524, 177);
            this.gbProductos.TabIndex = 13;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "Productos";
            this.gbProductos.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code_product,
            this.product_name,
            this.code_brand,
            this.code_category});
            this.dataGridView1.Location = new System.Drawing.Point(14, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(504, 119);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // code_product
            // 
            this.code_product.HeaderText = "Codigo";
            this.code_product.Name = "code_product";
            this.code_product.ReadOnly = true;
            this.code_product.Width = 80;
            // 
            // product_name
            // 
            this.product_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.product_name.HeaderText = "Nombre";
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            // 
            // code_brand
            // 
            this.code_brand.HeaderText = "Marca";
            this.code_brand.Name = "code_brand";
            this.code_brand.ReadOnly = true;
            this.code_brand.Width = 40;
            // 
            // code_category
            // 
            this.code_category.HeaderText = "Categoria";
            this.code_category.Name = "code_category";
            this.code_category.ReadOnly = true;
            this.code_category.Width = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Buscar :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.gbProductos);
            this.flowLayoutPanel1.Controls.Add(this.gbProductosCompania);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(542, 359);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // FormRegistroProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 420);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label6);
            this.Name = "FormRegistroProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRegistroProducto";
            this.Load += new System.EventHandler(this.FormRegistroProducto_Load);
            this.gbProductosCompania.ResumeLayout(false);
            this.gbProductosCompania.PerformLayout();
            this.gbProductos.ResumeLayout(false);
            this.gbProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbProductosCompania;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.TextBox txtCode_product;
        public System.Windows.Forms.TextBox txtPrecio;
        public System.Windows.Forms.TextBox txtCode_category;
        public System.Windows.Forms.TextBox txtCode_brand;
        public System.Windows.Forms.TextBox txtProduct_name;
        public System.Windows.Forms.TextBox txtUM;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtRuc_Pcomopany;
        private System.Windows.Forms.TextBox txtBuscarProduct;
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn code_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn code_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn code_category;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}