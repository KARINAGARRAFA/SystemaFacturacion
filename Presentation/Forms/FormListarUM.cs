using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Business.Business.UnidadMedida;
using Business.Entity;
using Presentation.Forms;

namespace Presentation.Forms
{
    public partial class FormListarUM : Form
    {
        int listado = 0;
        BusinessUnidadMedida UM = new BusinessUnidadMedida();

        public FormListarUM()
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

        private void FormListarUM_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;

            CargarListado();
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = UM.ListarUnidaMedida(); 
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
            FormRegistroUnidadMedida um = new FormRegistroUnidadMedida();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;

            um.ShowDialog();
            dataGridView1.ClearSelection();
            timer1.Start();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormRegistroUnidadMedida um = new FormRegistroUnidadMedida();
                um.txtCodigoUM.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                um.txtNombreUM.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                um.txtDescriptionUM.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                

                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;

                um.ShowDialog();
                dataGridView1.ClearSelection();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var um = new UnidadMedida();
            String msj = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                um.Code_unit = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                if (MessageBox.Show("¿Está Seguro que Desea Eliminar.?", "Sistema de Facturacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    msj = UM.DeleteUnidadMedida(um);
                    MessageBox.Show(msj, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
                timer1.Start();
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
                timer1.Stop();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.ClearSelection();
            string date;
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                date = textBox1.Text;
                dt = UM.BuscarUM(date); 
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
    }
}
