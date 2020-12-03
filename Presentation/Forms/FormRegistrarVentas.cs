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
using Business.Business.Help;
using Business.Business.Venta;
using Business.Business.Cliente;
using Business.Business.Producto;
using Business.Entity;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Drawing.Printing;

namespace Presentation.Forms
{
    public partial class FormRegistrarVentas : Form
    {
        BusinessGeneral GENERAL = new BusinessGeneral();
        BusinessVenta VENTA = new BusinessVenta();
        BusinessDetalleVenta Dventa = new BusinessDetalleVenta();
        BusinessCliente CL = new BusinessCliente();
        BusimessCompanyProduct P = new BusimessCompanyProduct();

        
        int n=0,selecProducto=0;
        bool  b= true;
        string IDVenta,mensaje,numero;
        public FormRegistrarVentas()
        {
            InitializeComponent();           
        }
        
        private void btnBusqueda_Click(object sender, EventArgs e)
        {            
            if (txtRucCliente.Text != null)
            {
                buscarCliente();
            }
        }
        public void buscarCliente()
        {
            if (txtRucCliente.Text != "")
            {
                var ruc = "";
                DataTable dt = new DataTable();
                ruc = txtRucCliente.Text;
                dt = CL.BuscarCliente(ruc);
                try
                {
                    if (dt.Rows.Count == 0)
                    {
                        List<string> cli = new List<string>();
                        cli= CL.BuscarClienteAPIReniec(ruc);

                        txtRucCliente.Text = cli[0];
                        txtNombreCliente.Text = cli[1];
                        txtDireccionCliente.Text = cli[7];

                        //  CONDICION EN CASO Q NO ENCUENTREAL CLIENTE

                        CL.RegistrarClienteRenic(cli);
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
            else
            {
                MessageBox.Show("Ingrese RUC del cliente", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRucCliente.Focus();
            }
            
        }
        private void FormRegistrarVentas_Load(object sender, EventArgs e)
        {
            LlenarCombox();
            lblRucEmpresa.Text = Program.ruc_empresa;
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
                lblNroCorrelativo.Text = VENTA.NumeroComprobante(lblSerie.Text);
            }
            else if (cbxTipoDocumento.Text == "FACTURA")
            {
                lblTipoComprobante.Text = "FACTURA ELECTRONICA";
                lblSerie.Text = "F001";
                lblNroCorrelativo.Text = VENTA.NumeroComprobante(lblSerie.Text);
            }
        }

        private void txtRucCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscarCliente();
            }
        }

        private void Calculos()
        {
            decimal ImporteTotal=0;
            decimal IGV=0;
            decimal Base_imponible=0;

            foreach(DataGridViewRow row in dataGridView1.Rows)
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvRow = dataGridView1.CurrentRow;
            if (dataGridView1.CurrentRow != null && dgvRow.Cells["code_product"].Value != null)
            {
                // AGREGAR CONDICION PARA CUANDO EL PRODUCTO NO EXISTE

                var ruc = "";
                DataTable dt = new DataTable();
                ruc = dgvRow.Cells["code_product"].Value.ToString();
                dt = P.BuscarCompanyProduct_codigo(ruc);
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
            Limpiar1();
        }


        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value) != "")
                {
                    if (cbxTipoDocumento.SelectedValue.ToString() == "01")
                    {
                        if (txtRucCliente.Text != "")
                        {
                            GenerarVenta();
                        }
                        else
                        {
                            MessageBox.Show("ingrese el RUC del cliente", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtRucCliente.Focus();
                        }
                    }
                    else
                    {
                        if (Convert.ToDecimal(txtImporteTotal.Text) >= 700)
                        {
                            if (txtRucCliente.Text != "")
                            {
                                GenerarVenta();
                            }
                            else
                            {
                                MessageBox.Show("ingrese el RUC o DNI del cliente", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtRucCliente.Focus();
                            }
                        }
                        else
                        {
                            GenerarVenta();
                        }

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

            //-------------------------proceso de impresion-----------------------------
            //printComprobante = new PrintDocument();
            //PrinterSettings ps = new PrinterSettings();
            //printComprobante.PrinterSettings = ps;
            //printComprobante.PrintPage += Imprimir;
            //printComprobante.Print();

        }
        private void GenerarVenta()
        {
            GuardarVenta();
            if (mensaje != "Esta Venta ya ha sido Registrado.")
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) != "")
                        {
                            GuardarDetalleVenta(
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
                
                lblNroCorrelativo.Text = VENTA.NumeroComprobante(lblSerie.Text);
            }
            else
            {
                lblNroCorrelativo.Text = Convert.ToString(Convert.ToInt32(lblNroCorrelativo.Text) + 1);
                GenerarVenta();
            }            
        }
        private void GuardarVenta()
        {
            var v = new Venta();
            if (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) != "")
            {
                //string cdp_tipo = cbxTipoDocumento.SelectedValue.ToString(); //Convert.ToString(cbxTipoDocumento.AccessibilityObject); //== "BOLETA" ? "01" : "02";965
                numero = lblNroCorrelativo.Text;
                IDVenta = VENTA.GenerarIdVentas(lblRucEmpresa.Text, cbxTipoDocumento.SelectedValue.ToString(), lblSerie.Text, Convert.ToInt32(lblNroCorrelativo.Text));
                String TipoMoneda=  rbnSoles.Checked == true ? "PEN" : "USS";
                v.Code = IDVenta;
                v.Numero = Convert.ToInt32("0");
                v.Fecha_emision = DateTime.Now; //Convert.ToDateTime(lblFechaEmision.Text);
                v.Fecha_pago = Convert.ToDateTime(dtpFechaPago.Value);
                v.Cdp_tipo = cbxTipoDocumento.SelectedValue.ToString();
                v.Cdp_serie = lblSerie.Text;  ///--------------------4 digitos
                v.Cdp_numero =Convert.ToInt32(lblNroCorrelativo.Text);
                v.Proveedor_tipo = "";
                v.Proveedor_numero = Program.Ruc_cliente;
                v.Valor_exportacion = Convert.ToDecimal("0.0");
                v.Base_imponible = Convert.ToDecimal(txtSubTotalVentas.Text); 
                v.Importe_total_exonerada = Convert.ToDecimal("0.0");
                v.Importe_total_inafecta = Convert.ToDecimal("0.0");
                v.Igv = Convert.ToDecimal(txtIGV.Text);
                v.Importe_total = Convert.ToDecimal(txtImporteTotal.Text); 
                v.Dolares = Convert.ToDecimal("0.0");
                v.Igv_retencion = Convert.ToDecimal("0.0");
                v.Detraccion_id = Convert.ToInt32("0");
                v.Constancia_detraccion_numero = "";
                v.Constancia_detraccion_fecha_pago = DateTime.Today;
                v.Constancia_detraccion_monto = Convert.ToDecimal("0.0");
                v.Constancia_detraccion_referencia_monto = Convert.ToDecimal("0.0");
                v.Observacion = txtObservacion.Text;
                v.created_at = DateTime.Now;
                v.updated_at = DateTime.Now;
                v.Company_ruc = lblRucEmpresa.Text;
                v.Tipo_moneda = TipoMoneda;
                v.Estado = "";
                mensaje = VENTA.RegistrarVenta(v);
                VENTA.ActualizarNumeroCorrelativo(v.Cdp_serie, v.Cdp_numero);
            }
        }
        private void GuardarDetalleVenta(String objIdProducto, Int32 objCantidad, Decimal objPUnitario,
            Decimal objIgv, Decimal objSubTotal, Decimal importe)
        {
            var dv = new DetalleVenta();
            
            //dv.Code = Dventa.GenerarIdDetalleVenta();
            dv.Code_product = objIdProducto;
            dv.Code_sales = IDVenta;
            dv.Cantidad = objCantidad;
            dv.Precio = objPUnitario;
            dv.Code_unit = "";
            dv.Igv = objIgv;
            dv.Base_imponible = objSubTotal;
            dv.Importe = importe;
            dv.created_at = DateTime.Today;
            dv.updated_at = DateTime.Today;

            Dventa.RegistrarDetalleVenta(dv);
        }
        private void Limpiar1()
        {
            txtRucCliente.Text="";
            txtNombreCliente.Text = "";
            txtDireccionCliente.Text = "";
            txtObservacion.Text = "";
            dataGridView1.Rows.Clear();
            Program.Ruc_cliente = "";
            Program.Business_name= "";
            Program.Address = "";
            txtSubTotalVentas.Text = "";
            txtIGV.Text = "";
            txtImporteTotal.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            FormListarClientes C = new FormListarClientes();
            Program.Even_listar_Cliente = 1;
            C.ShowDialog();
        }

        private void cargar_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();

            cbImpresoras.Items.Clear();

            for (int i = 0; i < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; i++)
            {
                cbImpresoras.Items.Add(PrinterSettings.InstalledPrinters[i]);
                if (printDoc.PrinterSettings.IsDefaultPrinter)
                {
                    cbImpresoras.Text = printDoc.PrinterSettings.PrinterName;
                }
            }
            MessageBox.Show("impresoras cargadas ", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnImprimirComprobante_Click(object sender, EventArgs e)
        {
            printComprobante = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printComprobante.PrinterSettings = ps;
            printComprobante.PrintPage += Imprimir;

            PaperSize tamanoHoja = new PaperSize();
            tamanoHoja.RawKind = (int)PaperKind.A4;

            printComprobante.DefaultPageSettings.PaperSize = tamanoHoja;

            printComprobante.Print();




        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            //------------------------------------------------------------------------------
            //DataGridViewRow dgvRow = dataGridView1.CurrentRow;
            //Font font = new Font("Arial",9);
            //int ancho = 600;
            //int y = 20;

            //e.Graphics.DrawString("----- COMPROBANTE ELECTRONICO ------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("Factura "+numero, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("Cliente: "+txtNombreCliente.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("--------Productos--------- ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 20));
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value + " " +
            //                          dataGridView1.Rows[i].Cells[4].Value + " " +
            //                          dataGridView1.Rows[i].Cells[3].Value + " " +
            //                          dataGridView1.Rows[i].Cells[6].Value + " " +
            //                          dataGridView1.Rows[i].Cells[9].Value

            //        , font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //}
            //e.Graphics.DrawString("            subTotal:  " + txtSubTotalVentas.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("                 IGV:  " + txtIGV.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("               Total:  " + txtImporteTotal.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("-----GRACIAS POR SU PREFERENCIA------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //Limpiar1();
            //-----------------------------------------------------------------------

            DataGridViewRow dgvRow = dataGridView1.CurrentRow;
            Font font = new Font("Arial", 9);
            Font font1 = new Font("Arial", 15);
            // TAMAÑO DELA HOJA



            int ancho = 1000;
            int y = 50;
            int x = 20;

            String imagen = @"C:\Users\Procont Business\Desktop\SystemaFacturacion\Presentation\bin\Debug\img\img.png";
            Image img = Image.FromFile(imagen);
            e.Graphics.DrawImage(img,new Rectangle(x,y +=20,150,50));

            DataTable dt = new DataTable();
            String user = Program.ruc_empresa;
            dt = USER.ListarUsuario(user);
            // llamar el nombre de la mepresa admin

            e.Graphics.DrawString("COMUNICACIONES MPJ SOCIEDAD ANONIMA CERRADA", font, Brushes.Black, new RectangleF(x, y += 60, ancho, 20));// nombre de la empresa PROCOMP BUSINESS
            e.Graphics.DrawString("JR. JAUREGUI 289 2do PISO OFICINA 203", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));  // DIRECCION DE LA EMPRESA
            e.Graphics.DrawString("Juliaca - SAN ROMAN - PUNO", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20)); // LUGAR  provincia



            int a = 20;
            e.Graphics.DrawString("RUC 20605971343", font1, Brushes.Black, new RectangleF(x+550, a += 60, ancho, 20)); // ruc de la empresa
            e.Graphics.DrawString("    FACTURA", font1, Brushes.Black, new RectangleF(x+550, a += 30, ancho, 20)); // tipo de comprobante
            e.Graphics.DrawString("  ELECTRONICA", font1, Brushes.Black, new RectangleF(x+550, a += 30, ancho, 20));
            e.Graphics.DrawString(" FA31 - 000045 ", font1, Brushes.Black, new RectangleF(x+550, a += 30, ancho, 20));// serie y numero

            //-------------------------------------------------------

            
            e.Graphics.DrawString("CLIENTE", font, Brushes.Black, new RectangleF(x, y += 40, ancho, 20));
            e.Graphics.DrawString("RUC               : 10025525375", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));// ruc del cliente
            e.Graphics.DrawString("DENOMINACION      : QUILLA QUENALLATA JUAN", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20)); // nombre del cliente
            e.Graphics.DrawString("DIRECCION         : SECTOR BUENA VISTA S/N ALTO INAMBARI - SANDIA - PUNO", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20)); // direccion del cliente


            a = 200;
            e.Graphics.DrawString("FECHA EMISION      : 09/11/2020", font, Brushes.Black, new RectangleF(x + 550, a += 20, ancho, 20)); //fecha de eemision
            e.Graphics.DrawString("FECHA DE VENC.     : 09/11/2020", font, Brushes.Black, new RectangleF(x + 550, a += 20, ancho, 20));// fecha de pago
            e.Graphics.DrawString("MONEDA             : SOLES", font, Brushes.Black, new RectangleF(x + 550, a += 20, ancho, 20));// tipo de moneda


            //-----------------------------------------------------------------


            e.Graphics.DrawString("CANT.                   UM                 COD.                DESCRIPCION                                                   V/U               P/U             IMPORTE", font, Brushes.Black, new RectangleF(x, y += 50, ancho, 20));
            e.Graphics.DrawString(" 1                         ZZ                 2002                PETITORIO MINERO (10NOV)                            593.220            700.00             700.00", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));//detalles del producto
            e.Graphics.DrawString("                                                                                                                            ", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                                                                                            ", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                                                                                            ", font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));
            e.Graphics.DrawString("GRAVADA                S/         593.22", font, Brushes.Black, new RectangleF(x+550, y += 20, ancho, 20));// sub total
            e.Graphics.DrawString("IGV 18.00%               S/         106.78", font, Brushes.Black, new RectangleF(x+550, y += 20, ancho, 20));// igv
            e.Graphics.DrawString("TOTAL                      S/         700.00", font, Brushes.Black, new RectangleF(x+550, y += 20, ancho, 20));// total



            //e.Graphics.DrawString("----- COMPROBANTE ELECTRONICO ------", font, Brushes.Black, new RectangleF(0, y += 100, ancho, 20));
            //e.Graphics.DrawString("Factura " + numero, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("Cliente: " + txtNombreCliente.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("--------Productos--------- ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 20));
           
            //e.Graphics.DrawString("            subTotal:  " + txtSubTotalVentas.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("                 IGV:  " + txtIGV.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("               Total:  " + txtImporteTotal.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //e.Graphics.DrawString("-----GRACIAS POR SU PREFERENCIA------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[2];
            }
        }

        private void txtRucCliente_KeyDown(object sender, KeyEventArgs e)
        {
            //buscarCliente();
        }

    }
}
