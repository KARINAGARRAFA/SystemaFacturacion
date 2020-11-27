using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Business.login;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistrarCompanyUser : Form
    {
        BusinessCompanyUser C_USER = new BusinessCompanyUser();
        public FormRegistrarCompanyUser()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var CU = new CompanyUser();
            String msj = "";

            if (txtUsername.Text.Trim() != "")
            {
                if (txtPassword.Text.Trim() != "")
                {
                    if (Program.Evento == 0)
                    {
                        CU.Username = txtUsername.Text;
                        CU.Password = txtPassword.Text;
                        CU.State = txtState.Text;
                        CU.Ruc_company = Program.ruc_login ;
                        CU.created_at= DateTime.Today;
                        CU.updated_at = DateTime.Today;

                        msj = C_USER.RegistrarUserCompany(CU);
                        if (msj == "Este usuario ya a sido Registrado.")
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
                        CU.Username = txtUsername.Text;
                        CU.Password = txtPassword.Text;
                        CU.State = txtState.Text;
                        CU.Ruc_company = Program.ruc_login;
                        CU.updated_at = DateTime.Today;
                        MessageBox.Show(C_USER.ActualizarUserCompany(CU), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese Contraseña.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Usuario.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
        }
        private void Limpiar()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtState.Text = "";
        }

        private void FormRegistrarCompanyUser_Load(object sender, EventArgs e)
        {
            if (Program.Evento == 1)
            {
                txtUsername.ReadOnly = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
