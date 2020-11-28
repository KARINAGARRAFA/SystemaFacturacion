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

        BusimessCompanyProduct CProduct = new BusimessCompanyProduct();
        

        public FormRegistroProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var product = new CompanyProduct();
            String msj = "";
            if (txtProduct_name.Text.Trim() != "")
            {
                if (txtPrecio.Text.Trim() !="")
                {
                    if (txtUM.Text.Trim() != "")
                    {
                        if (Program.Evento == 0)
                        {
                            product.Code_product = txtCode_product.Text;
                            product.Product_name = txtProduct_name.Text;
                            product.Code_brand = txtCode_brand.Text;
                            product.Code_category = txtCode_category.Text;
                            product.Precio = Convert.ToDecimal(txtPrecio.Text);
                            product.Unidad_medida = txtUM.Text;
                            product.Ruc_empresa = Program.ruc_empresa;
                            product.created_at = DateTime.Today;
                            product.updated_at = DateTime.Today;

                            msj = CProduct.RegistrarCompanyProduct(product);
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
                            product.Code_brand = txtCode_brand.Text;
                            product.Code_category = txtCode_category.Text;
                            product.Precio = Convert.ToDecimal(txtPrecio.Text);
                            product.Unidad_medida = txtUM.Text;
                            product.Ruc_empresa = txtRuc_Pcomopany.Text;
                            product.updated_at = DateTime.Today;
                            MessageBox.Show(CProduct.ActualizarCompanyProduct(product), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por Favor Ingrese la unidad de medida.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUM.Focus();
                    }                           
                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese Marca del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecio.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProduct_name.Focus();
            }
        }
        private void Limpiar()
        {
            txtCode_product.Text = "";
            txtProduct_name.Clear();
            txtCode_brand.Clear();
            txtCode_category.Clear();
            txtPrecio.Clear();
            txtUM.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void activar()
        {
            if (Program.Evento != 0)
            {
                gbProductos.Visible = false;
            }
        }


        BusinessProducto P = new BusinessProducto();
        private void txtBuscarProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.ClearSelection();
            string date;
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                date = txtBuscarProduct.Text;
                dt = P.BuscarProducto(date);
                try
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(dt.Rows[i][0]);
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    }
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void FormRegistroProducto_Load(object sender, EventArgs e)
        {
            if (Program.Evento == 0)
            {
                gbProductos.Visible = true;
                CargarListado();
                dataGridView1.ClearSelection();
            }            
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = P.Listado();
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtCode_product.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtProduct_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCode_brand.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtCode_category.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
