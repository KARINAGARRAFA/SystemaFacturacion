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
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Presentation.Forms
{
    public partial class FormRegistrarVentas : Form
    {
        BusinessVenta VENTA = new BusinessVenta();
        BusinessDetalleVenta Dventa = new BusinessDetalleVenta();
        BusinessCliente CL = new BusinessCliente();
        BusinessProducto P = new BusinessProducto();
        int n=0;
        bool a = false, b= true;
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
            if (txtAnticipos.Text != "")
            {
                pnlAnticipo.Visible = true;
            }
            if (txtSubTotalVentas.Text != "")
            {
                pnlSubTotalVentas.Visible = true;
            }
            if (txtDescuentos.Text != "")
            {
                pnlDescuento.Visible = true;
            }
            if (txtValorVenta.Text != "")
            {
                pnlValorVenta.Visible = true;
            }
            if (txtISC.Text != "")
            {
                pnlISC.Visible = true;
            }
            if (txtOtrosTributos.Text != "")
            {
                pnlOtrosTributos.Visible = true;
            }
            if (txtOtrosCargos.Text != "")
            {
                pnlOtrosCargos.Visible = true;
            }
        }
        private void tmHora_Tick(object sender, EventArgs e)
        {
            lblFechaEmision.Text = DateTime.Now.ToString("yyyy:MM:dd  HH:mm:ss");
            Calculos();
            Visibilidad();
        }

        private void cbxTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoDocumento.Text == "BOLETA")
            {
                lblTipoComprobante.Text = "BOLETA ELECTRONICA";
                lblSerie.Text = "B001";
                GenerarNumeroComprobante();
            }
            else if (cbxTipoDocumento.Text == "FACTURA")
            {
                lblTipoComprobante.Text = "FACTURA ELECTRONICA";
                lblSerie.Text = "F001";
                GenerarNumeroComprobante();
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
                    if (dt.Rows.Count == 0)
                    {
                        // buscar en la api y registrarlo en la BD
                        string url = @"https://procontbusiness.com/sunat/sunat.php?ruc="+ruc;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            var json = reader.ReadToEnd();
                            JsonGeneric cliente = JsonConvert.DeserializeObject<JsonGeneric>(json);

                            txtRucCliente.Text = cliente.result.ruc;
                            txtNombreCliente.Text = cliente.result.razon_social;
                            txtDireccionCliente.Text = cliente.result.direccion;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            txtNombreCliente.Text = dt.Rows[i][1].ToString();
                            txtDireccionCliente.Text = dt.Rows[i][3].ToString();
                        }
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
            decimal ImporteTotal=0;
            decimal IGV=0;
            decimal SubTotal=0;

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                ImporteTotal += Convert.ToDecimal(row.Cells["Importe"].Value);
            }
            txtImporteTotal.Text = ImporteTotal.ToString("N2");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                IGV += Convert.ToDecimal(row.Cells["Igv"].Value);
            }
            txtIGV.Text = IGV.ToString("N2");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SubTotal += Convert.ToDecimal(row.Cells["V_U"].Value);
            }
            txtSubTotalVentas.Text = SubTotal.ToString("N2");
        }

        private void FormRegistrarVentas_Activated(object sender, EventArgs e)
        {
            b = Program.foco;
            if (b == true)
            {
                txtRucCliente.Text = Program.Ruc_cliente;
                txtNombreCliente.Text = Program.Business_name;
                txtDireccionCliente.Text = Program.Address;
                Program.foco = false;
            }
            if (a == true)
            {
                dataGridView1.Rows[n].Cells[0].Value = VENTA.GenerarIdVenta();
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
                        dgvRow.Cells["IdD"].Value = VENTA.GenerarIdVenta();
                        dgvRow.Cells["nombre"].Value = dt.Rows[i][1].ToString();
                        dgvRow.Cells["V_U"].Value = Convert.ToDecimal(500.00);
                        dgvRow.Cells["P_unidad"].Value = Convert.ToDecimal(600.00);
                        dgvRow.Cells["Igv"].Value = Convert.ToDouble(dgvRow.Cells["P_unidad"].Value) * 0.18;
                        dgvRow.Cells["Importe"].Value = Convert.ToDouble(dgvRow.Cells["P_unidad"].Value) * Convert.ToDouble(dgvRow.Cells["Cant"].Value);
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
            a = false;
        }

        private void txtImporteTotal_Leave(object sender, EventArgs e)
        {
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) != "")
                {
                    GuardarVenta();
                    try
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            Decimal SumaIgv = 0; Decimal SumaSubTotal = 0;
                            if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) != "")
                            {
                                SumaIgv += Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                                SumaSubTotal += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                                GuardarDetalleVenta(
                                Convert.ToString(dataGridView1.Rows[i].Cells[2].Value),
                                Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),
                                Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                                Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value),
                                SumaIgv, SumaSubTotal
                                );
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Limpiar1();
                }
                else
                {
                    MessageBox.Show("No Existe Ningún Elemento en la Lista.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Existe Ningún Elemento en la Lista.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarVenta()
        {
            var v = new Venta();
            decimal Importe_total = 0;
            if (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) != "")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Importe_total = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                }
                string  cdp_tipo = "";
                //TipoDocumento = rbnBoleta.Checked == true ? "Boleta" : "Factura";
                cdp_tipo = cbxTipoDocumento.Text == "BOLETA" ? "01" : "02";
                v.Code = VENTA.GenerarIdVenta(); //------------------------codigo de venta
                v.Numero = Convert.ToInt32("0");
                v.Fecha_emision = DateTime.Now; //Convert.ToDateTime(lblFechaEmision.Text);
                v.Fecha_pago = Convert.ToDateTime(dtpFechaPago.Value);
                v.Cdp_tipo = cdp_tipo;
                v.Cdp_serie = lblSerie.Text;  ///--------------------4 digitos
                v.Cdp_numero =Convert.ToInt32(lblNroCorrelativo.Text);
                v.Proveedor_tipo = "";
                v.Proveedor_numero = Program.Ruc_cliente;
                v.Valor_exportacion = Convert.ToDecimal("0.0");
                v.Base_imponible = Convert.ToDecimal("0.0");
                v.Importe_total_exonerada = Convert.ToDecimal("0.0");
                v.Importe_total_inafecta = Convert.ToDecimal("0.0");
                v.Igv = Convert.ToDecimal("0.0");
                v.Importe_total = Importe_total;
                v.Dolares = Convert.ToDecimal("0.0");
                v.Tipo_cambio = Convert.ToDecimal("0.0");
                v.Igv_retencion = Convert.ToDecimal("0.0");
                v.Detraccion_id = Convert.ToInt32("0");
                v.Constancia_detraccion_numero = "";
                v.Constancia_detraccion_fecha_pago = DateTime.Today;
                v.Constancia_detraccion_monto = Convert.ToDecimal("0.0");
                v.Constancia_detraccion_referencia_monto = Convert.ToDecimal("0.0");
                v.Observacion = txtObservacion.Text;
                v.created_at = DateTime.Now;
                v.updated_at = DateTime.Now;
                v.Company_ruc = lblRucUsuario.Text;
                MessageBox.Show(VENTA.RegistrarVenta(v), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GuardarDetalleVenta(String objIdProducto, String objIdVenta, Int32 objCantidad, Decimal objPUnitario,
            Decimal objIgv, Decimal objSubTotal)
        {
            var dv = new DetalleVenta();
            
            dv.Code = Dventa.GenerarIdDetalleVenta();
            dv.Code_product = objIdProducto;
            dv.Code_sales = objIdVenta;
            dv.Cantidad = objCantidad;
            dv.Precio = objPUnitario;
            dv.Code_unit = "";
            dv.Igv = objIgv;
            dv.Base_imponible = objSubTotal;
            dv.created_at = DateTime.Today;
            dv.updated_at = DateTime.Today;

            Dventa.RegistrarDetalleVenta(dv);
            //Limpiar1();
        }
        private void Limpiar1()
        {
            txtRucCliente.Text="";
            txtNombreCliente.Text = "";
            txtDireccionCliente.Text = "";
            txtObservacion.Text = "";
            dataGridView1.Rows.Clear();
        }
        private void txtDireccionCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // registrar la direccion
                var ct = new Cliente();
                ct.Ruc_client = txtRucCliente.Text;
                ct.Address = txtDireccionCliente.Text;
                ct.updated_at = DateTime.Today;
                MessageBox.Show(CL.ActualizarDireccionCliente(ct), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}
