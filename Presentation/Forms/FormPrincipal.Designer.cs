namespace Presentation.Forms
{
    partial class FormPrincipal
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
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pnlProducto = new System.Windows.Forms.Panel();
            this.btnUMedida = new System.Windows.Forms.Button();
            this.btnModelo = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnMarca = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.btnUserLogin = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlProducto.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "SISTEMA DE FACTURACION ELECTRONICA";
            // 
            // btnProduct
            // 
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.Location = new System.Drawing.Point(44, 3);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(115, 33);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "PRODUCTOS";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Location = new System.Drawing.Point(44, 3);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(115, 33);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Location = new System.Drawing.Point(44, 3);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(115, 32);
            this.btnVentas.TabIndex = 3;
            this.btnVentas.Text = "VENTAS";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.Location = new System.Drawing.Point(44, 3);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(115, 36);
            this.btnCompras.TabIndex = 4;
            this.btnCompras.Text = "COMPRAS";
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Location = new System.Drawing.Point(44, 3);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(115, 33);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pnlProducto
            // 
            this.pnlProducto.Controls.Add(this.btnUMedida);
            this.pnlProducto.Controls.Add(this.btnModelo);
            this.pnlProducto.Controls.Add(this.btnCategoria);
            this.pnlProducto.Controls.Add(this.btnMarca);
            this.pnlProducto.Controls.Add(this.btnProductos);
            this.pnlProducto.Location = new System.Drawing.Point(3, 137);
            this.pnlProducto.Name = "pnlProducto";
            this.pnlProducto.Size = new System.Drawing.Size(197, 145);
            this.pnlProducto.TabIndex = 7;
            this.pnlProducto.Visible = false;
            // 
            // btnUMedida
            // 
            this.btnUMedida.Location = new System.Drawing.Point(78, 119);
            this.btnUMedida.Name = "btnUMedida";
            this.btnUMedida.Size = new System.Drawing.Size(94, 23);
            this.btnUMedida.TabIndex = 4;
            this.btnUMedida.Text = "U. MEDIDA";
            this.btnUMedida.UseVisualStyleBackColor = true;
            this.btnUMedida.Click += new System.EventHandler(this.btnUMedida_Click);
            // 
            // btnModelo
            // 
            this.btnModelo.Location = new System.Drawing.Point(78, 90);
            this.btnModelo.Name = "btnModelo";
            this.btnModelo.Size = new System.Drawing.Size(94, 23);
            this.btnModelo.TabIndex = 3;
            this.btnModelo.Text = "MODELO";
            this.btnModelo.UseVisualStyleBackColor = true;
            this.btnModelo.Click += new System.EventHandler(this.btnModelo_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(78, 61);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(94, 23);
            this.btnCategoria.TabIndex = 2;
            this.btnCategoria.Text = "CATEGORIA";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnMarca
            // 
            this.btnMarca.Location = new System.Drawing.Point(78, 32);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(94, 23);
            this.btnMarca.TabIndex = 1;
            this.btnMarca.Text = "MARCA";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(78, 3);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(94, 23);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "PRODUCTOS";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.btnUserLogin);
            this.pnlUser.Controls.Add(this.btnUser);
            this.pnlUser.Location = new System.Drawing.Point(3, 335);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(197, 61);
            this.pnlUser.TabIndex = 8;
            this.pnlUser.Visible = false;
            // 
            // btnUserLogin
            // 
            this.btnUserLogin.Location = new System.Drawing.Point(78, 33);
            this.btnUserLogin.Name = "btnUserLogin";
            this.btnUserLogin.Size = new System.Drawing.Size(94, 23);
            this.btnUserLogin.TabIndex = 2;
            this.btnUserLogin.Text = "USUARIOS";
            this.btnUserLogin.UseVisualStyleBackColor = true;
            this.btnUserLogin.Click += new System.EventHandler(this.btnUserLogin_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(78, 4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(94, 23);
            this.btnUser.TabIndex = 1;
            this.btnUser.Text = "EMPRESA";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.pnlProducto);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.pnlUser);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 51);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 473);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCompras);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 39);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnVentas);
            this.panel3.Location = new System.Drawing.Point(3, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 39);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnProduct);
            this.panel4.Location = new System.Drawing.Point(3, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(197, 38);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnUsuarios);
            this.panel5.Location = new System.Drawing.Point(3, 288);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(197, 41);
            this.panel5.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnClientes);
            this.panel6.Location = new System.Drawing.Point(3, 402);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(197, 36);
            this.panel6.TabIndex = 9;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 522);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPrincipal";
            this.pnlProducto.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Button btnUserLogin;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Panel pnlProducto;
        private System.Windows.Forms.Button btnModelo;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnUMedida;
    }
}