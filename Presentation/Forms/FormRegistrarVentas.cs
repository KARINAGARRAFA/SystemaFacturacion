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
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistrarVentas : Form
    {
        BusinessVenta VENTA = new BusinessVenta();
        BusinessCliente CL = new BusinessCliente();
        public FormRegistrarVentas()
        {
            InitializeComponent();

            LlenarCombox();
        }
        
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            FormListarClientes C = new FormListarClientes();
            C.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
        

        private void FormRegistrarVentas_Load(object sender, EventArgs e)
        {
            GenerarNumeroComprobante();
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

        private void tmHora_Tick(object sender, EventArgs e)
        {
            lblFechaEmision.Text = DateTime.Now.ToString("dd:MM:yy  HH:mm");
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
            if (rbnBoleta.Checked == true)
                lblNroCorrelativo.Text = VENTA.NumeroComprobante("BOLETA");
            else
                lblNroCorrelativo.Text = VENTA.NumeroComprobante("FACTURA");
        }

        private void txtRucCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ruc = "";
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                ruc = txtRucCliente.Text;
                //C.Dni = txtBuscarCliente.Text;
                dt = CL.BuscarCliente(ruc);
                //C.BuscarCliente(C.Dni);
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
            //else
            //{
            //    CargarListado();
            //    timer1.Start();
            //}
        }

        private void FormRegistrarVentas_Activated(object sender, EventArgs e)
        {
            txtRucCliente.Text = Program.Ruc_cliente;
            txtNombreCliente.Text = Program.Business_name;
            txtDireccionCliente.Text = Program.Address;
        }
    }
}
