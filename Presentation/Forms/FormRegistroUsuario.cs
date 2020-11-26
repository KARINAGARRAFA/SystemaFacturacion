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
using Business.Business.User;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistroUsuario : Form
    {
        BusinessUser USER = new BusinessUser();
        public FormRegistroUsuario()
        {
            InitializeComponent();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Us = new User();
            String msj = "";

            if (txtRuc.Text.Trim() != "")
            {
                if (txtNombreEmpresa.Text.Trim() != "")
                {
                    if (txtDireccion.Text.Trim() != "")
                    {
                        if (Program.Evento == 0)
                        {
                            Us.Code_ruc = txtRuc.Text;
                            Us.Business_name = txtNombreEmpresa.Text;
                            Us.Brand = txtBrand.Text;
                            Us.Cod_sector = txtCodSector.Text;
                            Us.Address = txtDireccion.Text;
                            Us.Email = txtEmail.Text;
                            Us.Telephone = txtTelefono.Text;
                            Us.Status = txtStatus.Text;
                            Us.Condition = txtCondicion.Text;
                            Us.created_at = DateTime.Today;
                            Us.updated_at = DateTime.Today;

                            msj = USER.RegistrarUsuario(Us);
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
                            Us.Code_ruc = txtRuc.Text;
                            Us.Business_name = txtNombreEmpresa.Text;
                            Us.Brand = txtBrand.Text;
                            Us.Cod_sector = txtCodSector.Text;
                            Us.Address = txtDireccion.Text;
                            Us.Email = txtEmail.Text;
                            Us.Telephone = txtTelefono.Text;
                            Us.Status = txtStatus.Text;
                            Us.Condition = txtCondicion.Text;
                            Us.updated_at = DateTime.Today;
                            MessageBox.Show(USER.ActualizarUsuario(Us), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por Favor Ingrese direcion de la Empresa.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDireccion.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese nombre de la empresa.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombreEmpresa.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese RUC de la empresa.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRuc.Focus();
            }
            FormListarUser U = new FormListarUser();
            U.timer1.Start();
        }
        private void Limpiar()
        {
            txtRuc.Text = "";
            txtNombreEmpresa.Text = "";
            txtBrand.Text = "";
            txtCodSector.Text = "";
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
