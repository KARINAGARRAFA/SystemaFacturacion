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
        int listado = 0;

        BusinessProducto p = new BusinessProducto();

        public FormProduct()
        {
            InitializeComponent();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;

            CargarListado();

            //DataTable dt = p.Listado();
            //dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = p.Listado();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
                timer1.Stop();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistroProducto fr = new FormRegistroProducto();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;
            dataGridView1.ClearSelection();
            fr.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormRegistroProducto producto = new FormRegistroProducto();
                //FrmRegistroProductos P = new FrmRegistroProductos();
                producto.txtCode_product.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                producto.txtProduct_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                producto.txtCode_trademark.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                producto.txtCode_category.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                producto.txtDescription.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                producto.Show();
                

                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //  DevComponents.DotNetBar.MessageBoxEx.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (listado)
            {
                case 0: CargarListado(); break;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Program.code_product = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Program.Product_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.Code_trademark = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Program.Code_category = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Program.Description = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var product = new ClsProduct();
            String msj = "";
            
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    
                    //FrmRegistroProductos P = new FrmRegistroProductos();
                    product.Code_product = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    
                    if (MessageBox.Show("¿Está Seguro que Desea Eliminar.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        msj = p.Delete(product);
                        MessageBox.Show(msj, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    //  DevComponents.DotNetBar.MessageBoxEx.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //Close();            
        }
    }
}
