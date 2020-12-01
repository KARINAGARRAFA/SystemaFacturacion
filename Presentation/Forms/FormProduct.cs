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
using Presentation.Forms;


namespace Presentation.Forms
{
    public partial class FormProduct : Form
    {
        BusimessCompanyProduct CProduct = new BusimessCompanyProduct();

        public FormProduct()
        {
            InitializeComponent();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (Program.Even_listar_producto == 1)
            {
                this.WindowState = FormWindowState.Normal;
                Program.Even_listar_producto = 0;
            }
            CargarListado();
            dataGridView1.ClearSelection();            
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = CProduct.Listado(Program.ruc_empresa);
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
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistroProducto fr = new FormRegistroProducto();
            Program.Evento = 0;
            dataGridView1.ClearSelection();
            fr.ShowDialog();
            CargarListado();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormRegistroProducto producto = new FormRegistroProducto();
                producto.txtCode_product.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                producto.txtProduct_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                producto.txtCode_brand.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                producto.txtCode_category.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                producto.txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                producto.txtUM.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                producto.txtRuc_Pcomopany.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
               
                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;

                producto.ShowDialog();
                dataGridView1.ClearSelection();
                CargarListado();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            var product = new CompanyProduct();
            String msj = "";
            
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    product.Code_product = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    
                    if (MessageBox.Show("¿Está Seguro que Desea Eliminar.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        msj = CProduct.DeleteCompanyProduct(product);
                        MessageBox.Show(msj, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CargarListado();
                    }
                    if (dataGridView1.SelectedRows.Count > 0)
                        Program.Evento = 1;
                    else
                        Program.Evento = 0;
                    dataGridView1.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar la Fila a Eliminar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }    
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Program.code_product = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Program.name_product = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.Code_brand = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Program.Code_category = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Program.precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            Program.unidad_medida = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Program.ruc_Pcompany = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            Program.Even_seleccionar_producto = 1;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.ClearSelection();
            string date;
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                date = textBox1.Text;
                dt = CProduct.BuscarCompanyProduct(date);
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
                        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                        dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                    }
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
