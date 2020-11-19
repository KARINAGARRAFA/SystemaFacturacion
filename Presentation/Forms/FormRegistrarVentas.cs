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
using Business.Business.Cliente;
using Business.Business.Producto;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistrarVentas : Form
    {
        BusinessVenta VENTA = new BusinessVenta();
        BusinessCliente CL = new BusinessCliente();
        BusinessProducto P = new BusinessProducto();
        int n=0;
        bool a = false;
        public FormRegistrarVentas()
        {
            InitializeComponent();           
        }
        
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            FormListarClientes C = new FormListarClientes();
            C.Show();
        }
        private void FormRegistrarVentas_Load(object sender, EventArgs e)
        {
            LlenarCombox();
            GenerarNumeroComprobante();
            Visibilidad();
            
        }
        private void LlenarCombox()
        {
            DataTable dt = new DataTable();
            dt = VENTA.ListarTipoDocumento();

            cbxTipoDocumento.DataSource = null;
            cbxTipoDocumento.Items.Clear();

            try
            {
                cbxTipoDocumento.ValueMember = "id";
                cbxTipoDocumento.DisplayMember = "nombre";
                cbxTipoDocumento.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();

        }
        private void Visibilidad()
        {
            if (txtAnticipos.Text != null)
            {
                pnlAnticipo.Visible = true;
            }
            if (txtSubTotalVentas.Text != null)
            {
                pnlSubTotalVentas.Visible = true;
            }
            if (txtDescuentos.Text != null)
            {
                pnlDescuento.Visible = true;
            }
            if (txtValorVenta.Text != null)
            {
                pnlValorVenta.Visible = true;
            }
            if (txtISC.Text != null)
            {
                pnlISC.Visible = true;
            }
            if (txtOtrosTributos.Text != null)
            {
                pnlOtrosTributos.Visible = true;
            }
            if (txtOtrosCargos.Text != null)
            {
                pnlOtrosCargos.Visible = true;
            }


        }
        private void tmHora_Tick(object sender, EventArgs e)
        {
            lblFechaEmision.Text = DateTime.Now.ToString("dd:MM:yy  HH:mm");
            Calculos();
        }

        private void cbxTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoDocumento.Text == "BOLETA")
            {
                lblTipoComprobante.Text = "BOLETA ELECTRONICA";
                lblSerie.Text = "B001";
            }
            else if (cbxTipoDocumento.Text == "FACTURA")
            {
                lblTipoComprobante.Text = "FACTURA ELECTRONICA";
                lblSerie.Text = "F001";
            }
        }

        private void GenerarNumeroComprobante()
        {
            if (cbxTipoDocumento.Text == "BOLETA")
                lblNroCorrelativo.Text = VENTA.NumeroComprobante("BOLETA");
            else if (cbxTipoDocumento.Text == "FACTURA")
                lblNroCorrelativo.Text = VENTA.NumeroComprobante("FACTURA");
        }

        private void txtRucCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ruc = "";
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                ruc = txtRucCliente.Text;
                dt = CL.BuscarCliente(ruc);
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txtNombreCliente.Text = dt.Rows[i][1].ToString();
                        txtDireccionCliente.Text = dt.Rows[i][3].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Calculos()
        {
            double total=0;

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDouble(row.Cells["Importe"].Value);
            }
            txtImporteTotal.Text = total.ToString();
        }

        private void FormRegistrarVentas_Activated(object sender, EventArgs e)
        {
            txtRucCliente.Text = Program.Ruc_cliente;
            txtNombreCliente.Text = Program.Business_name;
            txtDireccionCliente.Text = Program.Address;

            if(a == true)
            {
                dataGridView1.Rows[n].Cells[2].Value = Program.code_product;
                dataGridView1.Rows[n].Cells[4].Value = Program.Product_name;
                dataGridView1.Rows[n].Cells[6].Value = Convert.ToDecimal(500.00);
                dataGridView1.Rows[n].Cells[8].Value = Convert.ToDecimal(600.00);
                dataGridView1.Rows[n].Cells[7].Value = Convert.ToDouble(dataGridView1.Rows[n].Cells[8].Value) * 0.18;
                dataGridView1.Rows[n].Cells[9].Value = Convert.ToDouble(dataGridView1.Rows[n].Cells[7].Value) * Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);

                Program.code_product = "";
                Program.Product_name = "";
                a = false;
            }
            
        }


        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "buscarProducto" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridView1.Rows[e.RowIndex].Cells["buscarProducto"] as DataGridViewButtonCell;
                Icon icoBuscar = new Icon(Environment.CurrentDirectory + @"\\img\\lupa.ico");
                
                e.Graphics.DrawIcon(icoBuscar, e.CellBounds.Left, e.CellBounds.Top);

                this.dataGridView1.Rows[e.RowIndex].Height = icoBuscar.Height;
                this.dataGridView1.Columns[e.ColumnIndex].Width = icoBuscar.Width;

                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >=0)
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "buscarProducto")
                {
                    FormProduct P = new FormProduct();
                    P.Show();

                    n = dataGridView1.Rows.Add();
                    a = true;
                }
                else { }

            }
            
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvRow = dataGridView1.CurrentRow;
            if (dataGridView1.CurrentRow != null && dgvRow.Cells["code_product"].Value != null )
            {
                var ruc = "";
                DataTable dt = new DataTable();
                ruc = dgvRow.Cells["code_product"].Value.ToString();
                dt = P.BuscarProducto(ruc);
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvRow.Cells["nombre"].Value = dt.Rows[i][1].ToString();
                        dgvRow.Cells["V_U"].Value = Convert.ToDecimal(500.00);
                        dgvRow.Cells["P_unidad"].Value = Convert.ToDecimal(600.00);
                        dgvRow.Cells["Igv"].Value = Convert.ToDouble(dgvRow.Cells["P_unidad"].Value) * 0.18;

                        //if (dgvRow.Cells["Cant"].Value != null) Igv
                        //{
                        dgvRow.Cells["Importe"].Value = Convert.ToDouble(dgvRow.Cells["P_unidad"].Value) * Convert.ToDouble(dgvRow.Cells["Cant"].Value);
                        //}
                       

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                if (MessageBox.Show("¿Está Seguro que Desea Eliminar.?", "Sistema de Facturacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Eliminar.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
