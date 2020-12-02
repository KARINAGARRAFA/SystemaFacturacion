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
using Business.Business.Cliente;
using Business.Business.Producto;
using Business.Business.Help;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormReistrarCompras : Form
    {
        BusinessGeneral GENERAL = new BusinessGeneral();
        BusinessCompra COMPRA = new BusinessCompra();
        BusinessDetalleCompra DCOMPRA = new BusinessDetalleCompra();
        BusinessCliente CLIENTE = new BusinessCliente();
        BusimessCompanyProduct PRODUCTO = new BusimessCompanyProduct();

        int n = 0, selecProducto = 0;
        bool b = true;
        string IDCompra,mensaje;

        public FormReistrarCompras()
        {
            InitializeComponent();
        }

        private void FormReistrarCompras_Load(object sender, EventArgs e)
        {
            LlenarCombox();
        }
        private void LlenarCombox()
        {
            DataTable dt = new DataTable();
            dt = GENERAL.ListarTipoDocumento();

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

        private void txtRucProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscarCliente();
            }
        }
        public void buscarCliente()
        {
            if (txtRucProveedor.Text != "")
            {
                var ruc = "";
                DataTable dt = new DataTable();
                ruc = txtRucProveedor.Text;
                dt = CLIENTE.BuscarCliente(ruc);

                try
                {
                    if (dt.Rows.Count == 0)
                    {
                        List<string> cli = new List<string>();
                        cli = CLIENTE.BuscarClienteAPIReniec(ruc);

                        txtRucProveedor.Text = cli[0];
                        txtNombreProveedor.Text = cli[1];
                        txtDireccionProveedor.Text = cli[7];
                        // condicion si no encuentra al cliente
                        CLIENTE.RegistrarClienteRenic(cli);
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            txtNombreProveedor.Text = dt.Rows[i][1].ToString();
                            txtDireccionProveedor.Text = dt.Rows[i][3].ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese RUC del proveedor", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRucProveedor.Focus();
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvRow = dataGridView1.CurrentRow;
            if (dataGridView1.CurrentRow != null && dgvRow.Cells["code_product"].Value != null)
            {
                // AGREGAR CONDICION PARA CUANDO EL PRODUCTO NO EXISTE

                var ruc = "";
                DataTable dt = new DataTable();
                ruc = dgvRow.Cells["code_product"].Value.ToString();
                dt = PRODUCTO.BuscarCompanyProduct_codigo(ruc);
                try
                {
                    agregar(dt, dgvRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        public void agregar(DataTable dt, DataGridViewRow dgvRow)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvRow.Cells["nombre"].Value = dt.Rows[i][1].ToString();
                dgvRow.Cells["P_unidad"].Value = dt.Rows[i][4].ToString();
                dgvRow.Cells["Importe"].Value = Convert.ToDouble(dgvRow.Cells["P_unidad"].Value) * Convert.ToDouble(dgvRow.Cells["Cant"].Value);
                dgvRow.Cells["V_U"].Value = Convert.ToDouble(dgvRow.Cells["Importe"].Value) / 1.18;
                dgvRow.Cells["Igv"].Value = Convert.ToDouble(dgvRow.Cells["Importe"].Value) - Convert.ToDouble(dgvRow.Cells["V_U"].Value);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "buscarProducto")
                {
                    FormProduct P = new FormProduct();
                    Program.Even_listar_producto = 1;
                    n = e.RowIndex;
                    P.ShowDialog();
                }
            }
        }

        private void FormReistrarCompras_Activated(object sender, EventArgs e)
        {
            selecProducto = Program.Even_seleccionar_producto;
            if (selecProducto == 1)
            {
                agregar2();
                Program.code_product = "";
                Program.name_product = "";
                Program.precio = 0;
                Program.Even_seleccionar_producto = 0;
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

        private void tmCalculos_Tick(object sender, EventArgs e)
        {
            Calculos();
            Visibilidad();
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
        private void Calculos()
        {
            decimal ImporteTotal = 0;
            decimal IGV = 0;
            decimal Base_imponible = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ImporteTotal += Convert.ToDecimal(row.Cells["Importe"].Value);
            }

            if (ImporteTotal != 0)
            {
                txtImporteTotal.Text = ImporteTotal.ToString("N2");
            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                IGV += Convert.ToDecimal(row.Cells["Igv"].Value);
            }

            if (IGV != 0)
            {
                txtIGV.Text = IGV.ToString("N2");
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Base_imponible += Convert.ToDecimal(row.Cells["V_U"].Value);
            }

            if (Base_imponible != 0)
            {
                txtSubTotalVentas.Text = Base_imponible.ToString("N2");
            }
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value) != "")
                {
                    if (txtSerieC.Text != "")
                    {
                        if (txtNumeroC.Text != "")
                        {
                            if ( txtRucProveedor.Text != "" )
                            {
                                GuardarCompra();
                                if (mensaje != "Esta Compra ya ha sido Registrado.")
                                {
                                    try
                                    {
                                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                        {
                                            if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) != "")
                                            {
                                                GuardarDetalleCompra(
                                                Convert.ToString(dataGridView1.Rows[i].Cells[2].Value),
                                                Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                                                Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value),
                                                Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value),
                                                Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value),
                                                Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value)
                                                );
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    MessageBox.Show(mensaje, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpiar1();
                                }
                                else
                                {
                                    MessageBox.Show(mensaje, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }                                
                            }
                            else
                            {
                                MessageBox.Show("ingrese el RUC del proveedor", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtRucProveedor.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("ingrese el numero del Comprobate", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSerieC.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ingrese la seire del Comprobate", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSerieC.Focus();
                    }                        
                }
                else
                {
                    MessageBox.Show("ingrese la cantidad del producto.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[3];
                }
            }
            else
            {
                MessageBox.Show("No Existe Ningún Producto en la Lista.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarCompra()
        {
            var c = new Compra();
            if (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) != "")
            {
                IDCompra = COMPRA.GenerarIdCompra(txtRucProveedor.Text,cbxTipoDocumento.SelectedValue.ToString(),txtSerieC.Text,Convert.ToInt32(txtNumeroC.Text)); 
                String TipoMoneda = rbnSoles.Checked == true ? "PEN" : "USS";
                c.Code_purchages = IDCompra;
                c.Numero = Convert.ToInt32("0");
                c.Fecha_emision = Convert.ToDateTime(dtpFechaEmision.Value);
                c.Fecha_pago = Convert.ToDateTime(dtpFechaPago.Value);
                c.Cdp_tipo = cbxTipoDocumento.SelectedValue.ToString();
                c.Cdp_serie = txtSerieC.Text; 
                c.Cdp_numero = Convert.ToInt32(txtNumeroC.Text);
                c.Proveedor_tipo = "";
                c.Proveedor_numero = txtRucProveedor.Text;
                c.Base_imponible = Convert.ToDecimal(txtSubTotalVentas.Text);
                c.Igv = Convert.ToDecimal(txtIGV.Text);
                c.No_gravada = Convert.ToDecimal("0.0");
                c.Descuento = Convert.ToDecimal("0.0");
                c.Importe_total = Convert.ToDecimal(txtImporteTotal.Text);
                c.Dolares = Convert.ToDecimal("0.0");
                c.Perceppcion = Convert.ToDecimal("0.0");
                c.Detraccion_id = Convert.ToInt32("0");
                c.Constancia_detraccion_numero = "";
                c.Constancia_detraccion_fecha_pago = DateTime.Today;
                c.Constancia_detraccion_monto = Convert.ToDecimal("0.0");
                c.Monto_referencial = Convert.ToDecimal("0.0");
                c.Nota_credito_referencia_fecha= DateTime.Today;
                c.Nota_credito_referencia_tipo = "";
                c.Nota_credito_referencia_serie = "";
                c.Nota_credito_referencia_numero = "";
                c.Observacion = txtObservacion.Text;
                c.created_at = DateTime.Now;
                c.updated_at = DateTime.Now;
                c.Company_ruc = Program.ruc_empresa;
                c.Tipo_moneda = TipoMoneda;
                mensaje = COMPRA.RegistrarCompra(c);
                MessageBox.Show(COMPRA.RegistrarCompra(c), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GuardarDetalleCompra(String objIdProducto, Int32 objCantidad, Decimal objPUnitario,
            Decimal objIgv, Decimal objSubTotal, Decimal importe)
        {
            var dc = new DetalleCompra();

            //dv.Code = Dventa.GenerarIdDetalleVenta();
            dc.Code_product = objIdProducto;
            dc.Code_purchages= IDCompra;
            dc.Cantidad = objCantidad;
            dc.Precio = objPUnitario;
            dc.Code_unit = "";
            dc.Igv = objIgv;
            dc.Base_imponible = objSubTotal;
            dc.Importe = importe;
            dc.created_at = DateTime.Today;
            dc.updated_at = DateTime.Today;

            DCOMPRA.RegistrarDetalleCompra(dc);
        }
        private void Limpiar1()
        {
            txtRucProveedor.Text = "";
            txtNombreProveedor.Text = "";
            txtDireccionProveedor.Text = "";
            txtObservacion.Text = "";
            dataGridView1.Rows.Clear();
        }

        public void agregar2()
        {
            // AGREGAR CONDICION CUANDO NO SE SELECCIONA NADA
            dataGridView1.Rows[n].Cells[2].Value = Program.code_product;
            dataGridView1.Rows[n].Cells[4].Value = Program.name_product;
            dataGridView1.Rows[n].Cells[6].Value = Program.precio;
            dataGridView1.Rows[n].Cells[9].Value = Convert.ToDouble(dataGridView1.Rows[n].Cells[6].Value) * Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);
            dataGridView1.Rows[n].Cells[7].Value = Convert.ToDouble(dataGridView1.Rows[n].Cells[9].Value) / 1.18;
            dataGridView1.Rows[n].Cells[8].Value = Convert.ToDouble(dataGridView1.Rows[n].Cells[9].Value) - Convert.ToDouble(dataGridView1.Rows[n].Cells[7].Value);

        }
    }
}
