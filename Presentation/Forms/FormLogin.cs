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
using Business.Business.Producto;
using Business.Entity;
using Business.Business.login;

namespace Presentation.Forms
{
    public partial class FormLogin : Form
    {
        BusinessCompanyUser UL = new BusinessCompanyUser();
           //BusinessProducto p = new BusinessProducto();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var  U = new User_Login();
            if (txtUser.Text.Trim() != "")
            {
                if (txtPasword.Text.Trim() != "")
                {
                    String Mensaje = "";
                    U.User = txtUser.Text;
                    U.Password = txtPasword.Text;
                    Mensaje = UL.IniciarSesion(U);
                    if (Mensaje == "Su ContraseñaADMIN es Incorrecta.")
                    {
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtPasword.Clear();
                        txtPasword.Focus();
                    }
                    else if (Mensaje == "Bienvenido ADMIN")
                    {
                        Program.Even_sesion = 1;
                        RecuperarDatosSesion();
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        FormPrincipal fr = new FormPrincipal();                        
                        fr.Show();
                        this.Hide();
                        return;
                    }
                    else if (Mensaje == "El Nombre de Usuario no Existe.")
                    {
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtUser.Clear();
                        txtPasword.Clear();
                        txtUser.Focus();
                    }
                    else
                        if (Mensaje == "Su Contraseña es Incorrecta.")
                    {
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtPasword.Clear();
                        txtPasword.Focus();
                    }
                    else if (Mensaje == "Bienvenido")
                    {
                        Program.Even_sesion = 0;
                        RecuperarDatosSesion();
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        FormPrincipal fr = new FormPrincipal();
                        fr.Show();
                        this.Hide();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese su Contraseña.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPasword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre de Usuario.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }
        }
        private void RecuperarDatosSesion()
        {
            DataRow row;
            DataTable dt = new DataTable();
            string pas = Encrypt.GetSHA1(Convert.ToString(txtPasword.Text));
            dt = UL.DevolverDatosSesion(txtUser.Text, pas);
            if (dt.Rows.Count == 1)
            {
                row = dt.Rows[0];
                Program.ruc_login = row[0].ToString();
                Program.state = row[1].ToString();
            }
        }
    }
}
