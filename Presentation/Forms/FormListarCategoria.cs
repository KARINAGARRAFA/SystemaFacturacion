using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Business.Business.Categoria;
using Business.Entity;
using Presentation.Forms;

namespace Presentation.Forms
{
    public partial class FormListarCategoria : Form
    {
        int listado = 0;
        BusinessCategoria CT = new BusinessCategoria();

        public FormListarCategoria()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (listado)
            {
                case 0: CargarListado(); break;
            }
        }

        private void FormListarCategoria_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;

            CargarListado();
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = CT.ListarCategoria(); 
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
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
            FormRegistroCategoria C = new FormRegistroCategoria();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;
            dataGridView1.ClearSelection();
            C.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = new Categoria();
            String msj = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                c.Code_category = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                if (MessageBox.Show("¿Está Seguro que Desea Eliminar.?", "Sistema de Facturacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    msj = CT.DeleteCategoria(c); 
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
            }
            timer1.Start();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormRegistroCategoria ct = new FormRegistroCategoria();
                ct.txtCodigoCategoria.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ct.txtNombreCategoria.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                ct.txtDescriptionCategoria.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ct.Show();

                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //  DevComponents.DotNetBar.MessageBoxEx.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
