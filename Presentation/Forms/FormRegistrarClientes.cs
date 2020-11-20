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
using Business.Business.Cliente;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistrarClientes : Form
    {
        BusinessCliente CT = new BusinessCliente();
        public FormRegistrarClientes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var ct = new Cliente();
            String msj = "";

            if (txtRuc.Text.Trim() != "")
            {
                if (txtNombreEmpresa.Text.Trim ()!= "")
                {
                    if (txtDireccion.Text.Trim() != "")
                    {
                        if (Program.Evento == 0)
                        {
                            ct.Ruc_client = txtRuc.Text;
                            ct.Business_name = txtNombreEmpresa.Text;
                            ct.Brand = txtBrand.Text;
                            ct.Address = txtDireccion.Text;
                            ct.Email = txtEmail.Text;
                            ct.Telephone = txtTelefono.Text;
                            ct.Status = txtStatus.Text;
                            ct.Condition = txtCondicion.Text;
                            ct.created_at= DateTime.Today;
                            ct.updated_at = DateTime.Today;

                            msj = CT.RegistrarCliente(ct);
                            if (msj == "Este cliente ya ha sido Registrado.")
                            {
                                MessageBox.Show(msj, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show(msj, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpiar();
                            }
                        }
                        else
                        {
                            ct.Ruc_client = txtRuc.Text;
                            ct.Business_name = txtNombreEmpresa.Text;
                            ct.Brand = txtBrand.Text;
                            ct.Address = txtDireccion.Text;
                            ct.Email = txtEmail.Text;
                            ct.Telephone = txtTelefono.Text;
                            ct.Status = txtStatus.Text;
                            ct.Condition = txtCondicion.Text;
                            ct.updated_at = DateTime.Today;
                            MessageBox.Show(CT.ActualizarCliente(ct), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por Favor Ingrese direccion del cliente.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDireccion.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese nombre del cliente", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombreEmpresa.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Ruc del cliente", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRuc.Focus();
            }
            FormListarClientes Cliente = new FormListarClientes();
            Cliente.timer1.Start();
        }
        private void Limpiar()
        {
            txtRuc.Text = "";
            txtNombreEmpresa.Text = "";
            txtBrand.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtStatus.Text = "";
            txtCondicion.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
