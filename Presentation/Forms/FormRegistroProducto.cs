using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Business;
using Business.Business.Producto;
using Business.Entity;


namespace Presentation.Forms
{
    public partial class FormRegistroProducto : Form
    {
        
        BusinessProducto p = new BusinessProducto();
        

        public FormRegistroProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var product = new ClsProduct();
            String msj = "";
            /*try
            {
                

                product.Code_product = txtCode_product.Text;
                product.Product_name = txtProduct_name.Text;
                product.Code_trademark = txtCode_trademark.Text;
                product.Code_category = txtCode_category.Text;
                product.Description = txtDescription.Text;
                product.created_at = DateTime.Today;
                product.updated_at = DateTime.Today;

                msj = p.RegistrarProducto(product);
                Limpiar();
                MessageBox.Show(msj);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            if (txtProduct_name.Text.Trim() != "")
            {
                if (txtDescription.Text.Trim() !="")
                {
                    if (Program.Evento == 0)
                    {
                        product.Code_product = txtCode_product.Text;
                        product.Product_name = txtProduct_name.Text;
                        product.Code_trademark = txtCode_trademark.Text;
                        product.Code_category = txtCode_category.Text;
                        product.Description = txtDescription.Text;
                        product.created_at = DateTime.Today;
                        product.updated_at = DateTime.Today;

                        msj = p.RegistrarProducto(product);
                        if (msj == "Este Producto ya ha sido Registrado.")
                        {
                            MessageBox.Show(msj, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show(msj, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                    }
                     else
                     {
                        product.Code_product = txtCode_product.Text;
                        product.Product_name = txtProduct_name.Text;
                        product.Code_trademark = txtCode_trademark.Text;
                        product.Code_category = txtCode_category.Text;
                        product.Description = txtDescription.Text;
                        product.created_at = DateTime.Today;
                        product.updated_at = DateTime.Today;
                        MessageBox.Show(p.ActualizarProductos(product), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        Close();
                    }
                            
                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese Marca del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescription.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProduct_name.Focus();
            }
            FormProduct LP = new FormProduct();
            LP.timer1.Start();


        }
        private void Limpiar()
        {
            txtCode_product.Text = "";
            txtProduct_name.Clear();
            txtCode_trademark.Clear();
            txtCode_category.Clear();
            txtDescription.Clear();

        }

        private void txtProduct_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProduct_name_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormProduct fr = new FormProduct();
            fr.ShowDialog();
        }

        private void FormRegistroProducto_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
