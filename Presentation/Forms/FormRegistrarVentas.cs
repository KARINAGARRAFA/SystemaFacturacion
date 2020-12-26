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
using Business.Business.User;
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
        BusinessUser USER = new BusinessUser();
        Loading lod;


        int n=0,selecProducto=0;
        bool  b= true;
        string IDVenta,mensaje,numero;
        DateTime fechaEmision;
        public FormRegistrarVentas()
        {
            InitializeComponent();           
        }
        
        private async void btnBusqueda_Click(object sender, EventArgs e)
        {
            //    if(txtRucCliente.Text != "")
            //    {
            //        Shows();
            //        Task oTask = new Task(buscarCliente);
            //        oTask.Start();
            //        //buscarCliente();
            //        await oTask;
            //        hides();
            //    }

            buscarCliente();
        }
        public void Shows()
        {
            Loading loading = new Loading();
            loading.Show();
        }
        public void hides()
        {
            Loading loading = new Loading();
            if (loading != null)
                loading.Close();
        }
        public async void buscarCliente()
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
                        //show();
                        cli = await CL.BuscarClienteAPIReniec(ruc);
                         
                        //Closes();
                        txtRucCliente.Text = cli[0];
                        txtNombreCliente.Text = cli[1];
                        txtDireccionCliente.Text = cli[7];

                        //  CONDICION EN CASO Q NO ENCUENTREAL CLIENTE

                        //CL.RegistrarClienteRenic(cli);
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
        public void show()
        {
            lod = new Loading();
            lod.ShowDialog();
        }
        public void Closes()
        {
            if (lod != null)
                lod.Close();
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
            dataGridView1.Rows[n].Cells[9].Value = decimal.Round((Convert.ToDecimal(dataGridView1.Rows[n].Cells[6].Value) * Convert.ToDecimal(dataGridView1.Rows[n].Cells[3].Value)),2);
            dataGridView1.Rows[n].Cells[7].Value = decimal.Round((Convert.ToDecimal(dataGridView1.Rows[n].Cells[9].Value) / Convert.ToDecimal(1.18)),2);
            dataGridView1.Rows[n].Cells[8].Value = decimal.Round((Convert.ToDecimal(dataGridView1.Rows[n].Cells[9].Value) - Convert.ToDecimal(dataGridView1.Rows[n].Cells[7].Value)),2);

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
                dgvRow.Cells["Importe"].Value = decimal.Round((Convert.ToDecimal(dgvRow.Cells["P_unidad"].Value) * Convert.ToDecimal(dgvRow.Cells["Cant"].Value)),2); 
                dgvRow.Cells["V_U"].Value = decimal.Round((Convert.ToDecimal(dgvRow.Cells["Importe"].Value) / Convert.ToDecimal(1.18)),2);
                dgvRow.Cells["Igv"].Value = decimal.Round((Convert.ToDecimal(dgvRow.Cells["Importe"].Value) - Convert.ToDecimal(dgvRow.Cells["V_U"].Value)),2);
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
            
            printComprobante = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printComprobante.PrinterSettings = ps;
            printComprobante.PrintPage += Imprimir;

            // TAMAÑO DELA HOJA
            PaperSize tamanoHoja = new PaperSize();
            tamanoHoja.RawKind = (int)PaperKind.A4;

            printComprobante.DefaultPageSettings.PaperSize = tamanoHoja;
            printComprobante.DefaultPageSettings.Landscape = true;

            printComprobante.Print();


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
                fechaEmision= DateTime.Now;
                IDVenta = VENTA.GenerarIdVentas(lblRucEmpresa.Text, cbxTipoDocumento.SelectedValue.ToString(), lblSerie.Text, Convert.ToInt32(lblNroCorrelativo.Text));
                String TipoMoneda=  rbnSoles.Checked == true ? "PEN" : "USS";
                v.Code = IDVenta;
                v.Numero = Convert.ToInt32("0");
                v.Fecha_emision = fechaEmision;//Convert.ToDateTime(lblFechaEmision.Text);
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

            // TAMAÑO DELA HOJA
            PaperSize tamanoHoja = new PaperSize();
            tamanoHoja.RawKind = (int)PaperKind.A4;

            printComprobante.DefaultPageSettings.PaperSize = tamanoHoja;

            printComprobante.Print();




        }

        private void cbImpresoras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            DataGridViewRow dgvRow = dataGridView1.CurrentRow;
            Font font = new Font("Arial", 10);
            Font font1 = new Font("Arial", 10, FontStyle.Bold);
            Font font2 = new Font("Arial", 20,FontStyle.Bold);




            int ancho = 1500;
            int y = 100;
            int x = 50;

            Image img = Image.FromFile("img.png");
            e.Graphics.DrawImage(img, new Rectangle(x, y += 20, 200, 70));

            DataTable dt = new DataTable();
            String ruc_empresa = Program.ruc_empresa, money = rbnSoles.Checked == true ? "SOLES" : "DOLARES";
            dt = USER.BuscarUsuario(ruc_empresa);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i][0]);
                e.Graphics.DrawString(dt.Rows[i][1].ToString(), font1, Brushes.Black, new RectangleF(x, y += 80, ancho, 20));// nombre de la empresa PROCOMP BUSINESS
                e.Graphics.DrawString(dt.Rows[i][4].ToString(), font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));  // DIRECCION DE LA EMPRESA
                e.Graphics.DrawString(dt.Rows[i][2].ToString(), font, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));
            }


            int a = 100;
            e.Graphics.DrawString("RUC "+ruc_empresa, font2, Brushes.Black, new RectangleF(x + 700, a += 30, ancho, 30)); // ruc de la empresa
            e.Graphics.DrawString("     "+cbxTipoDocumento.Text, font2, Brushes.Black, new RectangleF(x + 700, a += 30, ancho, 30)); // tipo de comprobante
            e.Graphics.DrawString("  ELECTRONICA", font2, Brushes.Black, new RectangleF(x + 700, a += 30, ancho, 30));
            e.Graphics.DrawString("    " + lblSerie.Text + " - " + numero, font2, Brushes.Black, new RectangleF(x + 700, a += 30, ancho, 30));// serie y numero

            //-------------------------------------------------------

            int c = y;
            e.Graphics.DrawString("CLIENTE", font1, Brushes.Black, new RectangleF(x, y += 40, ancho, 20));
            e.Graphics.DrawString("RUC ", font1, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));
            e.Graphics.DrawString("DENOMINACION", font1, Brushes.Black, new RectangleF(x, y += 20, ancho, 20));
            e.Graphics.DrawString("DIRECCION ", font1, Brushes.Black, new RectangleF(x, y += 20, ancho, 20)); 

            e.Graphics.DrawString(": "+txtRucCliente.Text, font, Brushes.Black, new RectangleF(x+150, c += 60, ancho, 20));// ruc del cliente
            e.Graphics.DrawString(": " + txtNombreCliente.Text, font, Brushes.Black, new RectangleF(x+150, c += 20, ancho, 20)); // nombre del cliente
            e.Graphics.DrawString(": " + txtDireccionCliente.Text, font, Brushes.Black, new RectangleF(x+150, c += 20, 500, 50)); // direccion del cliente


            int b = a;
            e.Graphics.DrawString("FECHA EMISION ", font1, Brushes.Black, new RectangleF(x + 700, a += 50, ancho, 20)); //fecha de eemision
            e.Graphics.DrawString("FECHA DE VENC. ", font1, Brushes.Black, new RectangleF(x + 700, a += 20, ancho, 20));// fecha de pago
            e.Graphics.DrawString("MONEDA   ", font1, Brushes.Black, new RectangleF(x + 700, a += 20, ancho, 20));// tipo de moneda

            e.Graphics.DrawString(": " + Convert.ToString(fechaEmision), font, Brushes.Black, new RectangleF(x + 850, b += 50, ancho, 20)); //fecha de eemision
            e.Graphics.DrawString(": " + Convert.ToString(dtpFechaPago.Value), font, Brushes.Black, new RectangleF(x + 850, b += 20, ancho, 20));// fecha de pago
            e.Graphics.DrawString(": " + money, font, Brushes.Black, new RectangleF(x + 850, b += 20, ancho, 20));// tipo de moneda

            //-----------------------------------------------------------------

            int d = y, f = y,g=y,h=y,k=y,p=y;
          
            e.Graphics.DrawString("CANT.", font1, Brushes.Black, new RectangleF(x, y += 80, ancho, 20));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value), font, Brushes.Black, new RectangleF(x+10, y += 20, ancho, 20));
            }
            e.Graphics.DrawString(" UM ", font1, Brushes.Black, new RectangleF(x+80, d += 80, ancho, 20));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value), font, Brushes.Black, new RectangleF(x+80, d += 20, ancho, 20));
            }
            e.Graphics.DrawString(" COD. ", font1, Brushes.Black, new RectangleF(x+140, f += 80, 200,20));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), font, Brushes.Black, new RectangleF(x+140, f += 20, ancho, 20));
            }
            e.Graphics.DrawString(" DESCRIPCION ", font1, Brushes.Black, new RectangleF(x+280, g += 80, ancho, 20));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[4].Value), font, Brushes.Black, new RectangleF(x+280, g += 20, ancho, 20));
            }
            e.Graphics.DrawString(" V/U  ", font1, Brushes.Black, new RectangleF(x+750, h += 80, ancho, 20));
            for (int i = 0; i < dataGridView1.Rows.Count -2; i++)
            {
                e.Graphics.DrawString(Convert.ToString(Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value)), font, Brushes.Black, new RectangleF(x + 750, h += 20, ancho, 20));              
            }
            e.Graphics.DrawString(" P/U  ", font1, Brushes.Black, new RectangleF(x+850, k += 80, ancho, 20));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[6].Value), font, Brushes.Black, new RectangleF(x+850, k += 20, ancho, 20));
            }
            e.Graphics.DrawString("IMPORTE", font1, Brushes.Black, new RectangleF(x+950, p += 80, ancho, 20));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[9].Value), font, Brushes.Black, new RectangleF(x+950, p += 20, ancho, 20));
            }

            e.Graphics.DrawString("GRAVADA               S/         " + txtSubTotalVentas.Text, font1, Brushes.Black, new RectangleF(x + 750, y += 50, ancho, 20));// sub total
            e.Graphics.DrawString("IGV 18.00%              S/         "+ txtIGV.Text, font1, Brushes.Black, new RectangleF(x+750, y += 20, ancho, 20));// igv
            e.Graphics.DrawString("TOTAL                      S/         "+txtImporteTotal.Text, font1, Brushes.Black, new RectangleF(x+750, y += 20, ancho, 20));// total



            e.Graphics.DrawString("-----GRACIAS POR SU PREFERENCIA------", font, Brushes.Black, new RectangleF(x+200, y += 100, ancho, 20));
            Limpiar1();

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
