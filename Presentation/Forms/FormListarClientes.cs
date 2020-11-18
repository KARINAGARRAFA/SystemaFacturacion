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
using Business.Business.Cliente;
using Business.Entity;
using Presentation.Forms;

namespace Presentation.Forms
{
    public partial class FormListarClientes : Form
    {
        int listado = 0;

        BusinessCliente CL = new BusinessCliente();
        public FormListarClientes()
        {
            InitializeComponent();
        }

        private void FormListarClientes_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;

            CargarListado();
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = CL.ListarCliente(); 
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
                    dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (listado)
            {
                case 0: CargarListado(); break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistrarClientes cl = new FormRegistrarClientes();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;
            dataGridView1.ClearSelection();
            cl.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormRegistrarClientes ct = new FormRegistrarClientes();
                ct.txtRuc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ct.txtNombreEmpresa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                ct.txtBrand.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ct.txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                ct.txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                ct.txtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                ct.txtStatus.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                ct.txtCondicion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                ct.Show();

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var ct = new Cliente();
            String msj = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {

                //FrmRegistroProductos P = new FrmRegistroProductos();
                ct.Ruc_client = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                if (MessageBox.Show("¿Está Seguro que Desea Eliminar.?", "Sistema de Facturacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    msj = CL.DeleteCliente(ct);
                    MessageBox.Show(msj, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Eliminar.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //  DevComponents.DotNetBar.MessageBoxEx.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //FormRegistrarVentas V = new FormRegistrarVentas();
            //V.txtDocIdentidad.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //V.txtDatos.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
                timer1.Stop();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.ClearSelection();
            var ct = new Cliente();
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                ct.Ruc_client = textBox1.Text;
                //C.Dni = txtBuscarCliente.Text;
                dt = CL.BuscarCliente(ct.Ruc_client);
                    //C.BuscarCliente(C.Dni);
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
                        dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                    }
                    dataGridView1.ClearSelection();
                    timer1.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                CargarListado();
                timer1.Start();
            }
        }
        
        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            //FormRegistrarVentas ven = new FormRegistrarVentas();
            //ven.txtRucCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //ven.txtNombreCliente.Text =  dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //ven.txtDireccionCliente.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Program.Ruc_cliente = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Program.Business_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.Address = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.Close();
        }
    }
}
