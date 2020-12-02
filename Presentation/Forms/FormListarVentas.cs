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
        BusinessVenta VENTA = new BusinessVenta();
        BusinessDetalleVenta DVENTA = new BusinessDetalleVenta();
        public FormListarVentas()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistrarVentas V = new FormRegistrarVentas();
            V.ShowDialog();
            CargarListado();
        }

        private void FormListarVentas_Load(object sender, EventArgs e)
        {
            CargarListado();
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = VENTA.ListarVenta(Program.ruc_empresa); 
            dt1 = VENTA.ListarVenta1(Program.ruc_empresa); 
            try
            {
                dataGridView1.Rows.Clear();
                int i, j,a=0;
                for (i = 0; i < dt.Rows.Count; i++)
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
                }
                for (j = i; j < dt1.Rows.Count+i; j++)
                {
                    
                    dataGridView1.Rows.Add(dt1.Rows[a][0]);
                    dataGridView1.Rows[j].Cells[0].Value = dt1.Rows[a][0].ToString();
                    dataGridView1.Rows[j].Cells[1].Value = dt1.Rows[a][1].ToString();
                    dataGridView1.Rows[j].Cells[2].Value = dt1.Rows[a][2].ToString();
                    dataGridView1.Rows[j].Cells[3].Value = dt1.Rows[a][3].ToString();
                    dataGridView1.Rows[j].Cells[4].Value = dt1.Rows[a][4].ToString();
                    dataGridView1.Rows[j].Cells[5].Value = dt1.Rows[a][5].ToString();
                    dataGridView1.Rows[j].Cells[6].Value = dt1.Rows[a][6].ToString();
                    dataGridView1.Rows[j].Cells[7].Value = dt1.Rows[a][7].ToString();
                    dataGridView1.Rows[j].Cells[8].Value = dt1.Rows[a][8].ToString();
                    a++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.ClearSelection();
            string date;
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                date = textBox1.Text;
                dt = VENTA.BuscarVenta(Program.ruc_empresa,date);
                dt1 = VENTA.BuscarVenta1(Program.ruc_empresa,date);
                try
                {
                    dataGridView1.Rows.Clear();
                    int i, j, a = 0;
                    for (i = 0; i < dt.Rows.Count; i++)
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
                    }
                    for (j = i; j < dt1.Rows.Count + i; j++)
                    {
                        dataGridView1.Rows.Add(dt1.Rows[a][0]);
                        dataGridView1.Rows[j].Cells[0].Value = dt1.Rows[a][0].ToString();
                        dataGridView1.Rows[j].Cells[1].Value = dt1.Rows[a][1].ToString();
                        dataGridView1.Rows[j].Cells[2].Value = dt1.Rows[a][2].ToString();
                        dataGridView1.Rows[j].Cells[3].Value = dt1.Rows[a][3].ToString();
                        dataGridView1.Rows[j].Cells[4].Value = dt1.Rows[a][4].ToString();
                        dataGridView1.Rows[j].Cells[5].Value = dt1.Rows[a][5].ToString();
                        dataGridView1.Rows[j].Cells[6].Value = dt1.Rows[a][6].ToString();
                        dataGridView1.Rows[j].Cells[7].Value = dt1.Rows[a][7].ToString();
                        dataGridView1.Rows[j].Cells[8].Value = dt1.Rows[a][8].ToString();
                    }
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void mostrarDetalle()
        {
            FormListarDetalleVenta dv = new FormListarDetalleVenta();

            DataTable dtCln = new DataTable();
            DataTable dt = new DataTable();
            String date = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dtCln = DVENTA.ListarDetalleVentaCln(date);
            dt = DVENTA.ListarDetalleVenta(date);
            try
            {
                for (int i = 0; i < dtCln.Rows.Count; i++)
                {
                    dv.lblTipoMoneda.Text = dtCln.Rows[i][0].ToString();
                    dv.lblFechaEmision.Text = dtCln.Rows[i][1].ToString();
                    dv.lblFechaPago.Text = dtCln.Rows[i][2].ToString();
                    dv.lblRucEmpresa.Text = dtCln.Rows[i][3].ToString();
                    dv.lblTipoComprobante.Text = dtCln.Rows[i][4].ToString();
                    dv.lblSerie.Text = dtCln.Rows[i][5].ToString();
                    dv.lblNroCorrelativo.Text = dtCln.Rows[i][6].ToString();
                    dv.txtRucCliente.Text = dtCln.Rows[i][7].ToString();
                    dv.txtNombreCliente.Text = dtCln.Rows[i][8].ToString();
                    dv.txtDireccionCliente.Text = dtCln.Rows[i][9].ToString();
                    dv.txtObservacion.Text = dtCln.Rows[i][10].ToString();
                    dv.txtSubTotalVentas.Text = dtCln.Rows[i][11].ToString();
                    dv.txtIGV.Text = dtCln.Rows[i][12].ToString();
                    dv.txtImporteTotal.Text = dtCln.Rows[i][13].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                dv.dgvDetalleVenta.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dv.dgvDetalleVenta.Rows.Add(dt.Rows[i][0]);
                    dv.dgvDetalleVenta.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dv.dgvDetalleVenta.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dv.dgvDetalleVenta.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dv.dgvDetalleVenta.Rows[i].Cells[4].Value = dt.Rows[i][3].ToString();
                    dv.dgvDetalleVenta.Rows[i].Cells[5].Value = dt.Rows[i][4].ToString();
                    dv.dgvDetalleVenta.Rows[i].Cells[6].Value = dt.Rows[i][5].ToString();
                    dv.dgvDetalleVenta.Rows[i].Cells[7].Value = dt.Rows[i][6].ToString();
                }
                dv.dgvDetalleVenta.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dv.ShowDialog();
        }

        private void btnDetalleVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                mostrarDetalle();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un registro de VENTA en la tabla.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            mostrarDetalle();
        }

        private void btnBuscarXfecha_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt = VENTA.BuscarVentaXfecha(Program.ruc_empresa, dtpFechaInicio.Value, dtpFechaFin.Value);
                dt1 = VENTA.BuscarVentaXfecha1(Program.ruc_empresa, dtpFechaInicio.Value, dtpFechaFin.Value);
                try
                {
                    dataGridView1.Rows.Clear();
                    int i, j, a = 0;
                    for (i = 0; i < dt.Rows.Count; i++)
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
                    }
                    for (j = i; j < dt1.Rows.Count + i; j++)
                    {
                        dataGridView1.Rows.Add(dt1.Rows[a][0]);
                        dataGridView1.Rows[j].Cells[0].Value = dt1.Rows[a][0].ToString();
                        dataGridView1.Rows[j].Cells[1].Value = dt1.Rows[a][1].ToString();
                        dataGridView1.Rows[j].Cells[2].Value = dt1.Rows[a][2].ToString();
                        dataGridView1.Rows[j].Cells[3].Value = dt1.Rows[a][3].ToString();
                        dataGridView1.Rows[j].Cells[4].Value = dt1.Rows[a][4].ToString();
                        dataGridView1.Rows[j].Cells[5].Value = dt1.Rows[a][5].ToString();
                        dataGridView1.Rows[j].Cells[6].Value = dt1.Rows[a][6].ToString();
                        dataGridView1.Rows[j].Cells[7].Value = dt1.Rows[a][7].ToString();
                        dataGridView1.Rows[j].Cells[8].Value = dt1.Rows[a][8].ToString();
                    }
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
