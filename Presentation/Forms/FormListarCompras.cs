using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Business.Compra;

namespace Presentation.Forms
{
    public partial class FormListarCompras : Form
    {
        BusinessCompra COMPRA = new BusinessCompra();
        BusinessDetalleCompra DCOMPRA = new BusinessDetalleCompra();
        
        public FormListarCompras()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormReistrarCompras c = new FormReistrarCompras();
            c.ShowDialog();
            CargarListado();
        }

        private void FormListarCompras_Load(object sender, EventArgs e)
        {
            CargarListado();
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = COMPRA.ListarCompras(Program.ruc_empresa);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.ClearSelection();
            string date;
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                date = txtBuscar.Text;
                dt = COMPRA.BuscarCompra(Program.ruc_empresa, date);
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
                    }
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            mostrarDetalle();
        }
        private void mostrarDetalle()
        {
            //FormListarDetalleVenta dv = new FormListarDetalleVenta();
            FormListarDetalleCompra dc = new FormListarDetalleCompra();

            DataTable dtCln = new DataTable();
            DataTable dt = new DataTable();
            String date = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dtCln = DCOMPRA.ListarDetalleCompraCln(date);
            dt = DCOMPRA.ListarDetalleCompra(date);
            try
            {
                for (int i = 0; i < dtCln.Rows.Count; i++)
                {
                    dc.lblTipoMoneda.Text = dtCln.Rows[i][0].ToString();
                    dc.lblFechaEmision.Text = dtCln.Rows[i][1].ToString();
                    dc.lblFechaPago.Text = dtCln.Rows[i][2].ToString();
                    dc.lblRucProveedor.Text = dtCln.Rows[i][3].ToString();
                    dc.lblTipoComprobante.Text = dtCln.Rows[i][4].ToString();
                    dc.lblSerie.Text = dtCln.Rows[i][5].ToString();
                    dc.lblNroCorrelativo.Text = dtCln.Rows[i][6].ToString();
                    dc.txtRucProveedor.Text = dtCln.Rows[i][7].ToString();
                    dc.txtNombreProveedor.Text = dtCln.Rows[i][8].ToString();
                    dc.txtDireccionProveedor.Text = dtCln.Rows[i][9].ToString();
                    dc.txtObservacion.Text = dtCln.Rows[i][10].ToString();
                    dc.txtSubTotalVentas.Text = dtCln.Rows[i][11].ToString();
                    dc.txtIGV.Text = dtCln.Rows[i][12].ToString();
                    dc.txtImporteTotal.Text = dtCln.Rows[i][13].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                dc.dgvDetalleCompra.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dc.dgvDetalleCompra.Rows.Add(dt.Rows[i][0]);
                    dc.dgvDetalleCompra.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dc.dgvDetalleCompra.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dc.dgvDetalleCompra.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dc.dgvDetalleCompra.Rows[i].Cells[4].Value = dt.Rows[i][3].ToString();
                    dc.dgvDetalleCompra.Rows[i].Cells[5].Value = dt.Rows[i][4].ToString();
                    dc.dgvDetalleCompra.Rows[i].Cells[6].Value = dt.Rows[i][5].ToString();
                    dc.dgvDetalleCompra.Rows[i].Cells[7].Value = dt.Rows[i][6].ToString();
                }
                dc.dgvDetalleCompra.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dc.ShowDialog();
        }

        private void btnDetalleCompra_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                mostrarDetalle();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un registro de COMPRA en la tabla.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscarXfecha_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            DataTable dt = new DataTable();
            dt = COMPRA.BuscarCompraXfecha(Program.ruc_empresa, dtpFechaInicio.Value, dtpFechaFin.Value);
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
