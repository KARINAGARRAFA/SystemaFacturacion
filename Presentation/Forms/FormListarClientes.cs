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
        BusinessCliente CL = new BusinessCliente();
        public FormListarClientes()
        {
            InitializeComponent();
        }

        private void FormListarClientes_Load(object sender, EventArgs e)
        {
            if (Program.Even_listar_Cliente == 1)
            {
                this.WindowState = FormWindowState.Normal;
            }
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistrarClientes cl = new FormRegistrarClientes();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;
            
            cl.ShowDialog();
            dataGridView1.ClearSelection();
            CargarListado();
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
                

                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;

                ct.ShowDialog();
                dataGridView1.ClearSelection();
                CargarListado();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var ct = new Cliente();
            String msj = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
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
                CargarListado();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Eliminar.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
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
                dt = CL.BuscarCliente(ct.Ruc_client);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            Program.Ruc_cliente = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Program.Business_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.Address = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Program.foco = true;
            this.Close();
        }
    }
}
