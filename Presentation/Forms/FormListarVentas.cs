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
using Business.Business.Venta;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormListarVentas : Form
    {
        int listado = 0;
        BusinessVenta VENTA = new BusinessVenta();
        public FormListarVentas()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistrarVentas V = new FormRegistrarVentas();
            V.ShowDialog();
            timer1.Start();
        }

        private void FormListarVentas_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;

            CargarListado();
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = VENTA.ListarVenta(); 
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
                    dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][9].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dt.Rows[i][10].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dt.Rows[i][11].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dt.Rows[i][12].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dt.Rows[i][13].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dt.Rows[i][14].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dt.Rows[i][15].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dt.Rows[i][16].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dt.Rows[i][17].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dt.Rows[i][18].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dt.Rows[i][19].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dt.Rows[i][20].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dt.Rows[i][21].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dt.Rows[i][22].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dt.Rows[i][23].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dt.Rows[i][26].ToString();
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
                //C.Dni = txtBuscarCliente.Text;
                dt = VENTA.BuscarVenta(date); 
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
                        dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                        dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][9].ToString();
                        dataGridView1.Rows[i].Cells[10].Value = dt.Rows[i][10].ToString();
                        dataGridView1.Rows[i].Cells[11].Value = dt.Rows[i][11].ToString();
                        dataGridView1.Rows[i].Cells[12].Value = dt.Rows[i][12].ToString();
                        dataGridView1.Rows[i].Cells[13].Value = dt.Rows[i][13].ToString();
                        dataGridView1.Rows[i].Cells[14].Value = dt.Rows[i][14].ToString();
                        dataGridView1.Rows[i].Cells[15].Value = dt.Rows[i][15].ToString();
                        dataGridView1.Rows[i].Cells[16].Value = dt.Rows[i][16].ToString();
                        dataGridView1.Rows[i].Cells[17].Value = dt.Rows[i][17].ToString();
                        dataGridView1.Rows[i].Cells[18].Value = dt.Rows[i][18].ToString();
                        dataGridView1.Rows[i].Cells[19].Value = dt.Rows[i][19].ToString();
                        dataGridView1.Rows[i].Cells[20].Value = dt.Rows[i][20].ToString();
                        dataGridView1.Rows[i].Cells[21].Value = dt.Rows[i][21].ToString();
                        dataGridView1.Rows[i].Cells[22].Value = dt.Rows[i][22].ToString();
                        dataGridView1.Rows[i].Cells[23].Value = dt.Rows[i][23].ToString();
                        dataGridView1.Rows[i].Cells[24].Value = dt.Rows[i][26].ToString();
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
