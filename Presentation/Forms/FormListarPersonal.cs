using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Business.Business.login;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormListarPersonal : Form
    {
        BusinessCompanyUser UC = new BusinessCompanyUser();
        public FormListarPersonal()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistrarCompanyUser CU = new FormRegistrarCompanyUser();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;

            CU.ShowDialog();
            dataGridView1.ClearSelection();
            CargarListado();
        }

        private void FormListarPersonal_Load(object sender, EventArgs e)
        {
            CargarListado();
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = UC.ListarUserCompany(Program.ruc_empresa);
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][5].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormRegistrarCompanyUser cu = new FormRegistrarCompanyUser();
                cu.txtUsername.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cu.txtPassword.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cu.txtState.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();


                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;

                cu.ShowDialog();
                dataGridView1.ClearSelection();
                CargarListado();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cu = new CompanyUser();
            String msj = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                cu.Username = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                if (MessageBox.Show("¿Está Seguro que Desea Eliminar.?", "Sistema de Facturacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    msj = UC.DeleteUserCompany(cu);
                    MessageBox.Show(msj, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Debe Seleccionar la Fila a Eliminar.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
