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
        BusinessUserLogin UL = new BusinessUserLogin();
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
                    if (Mensaje == "Su Contraseña es Incorrecta.")
                    {
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtPasword.Clear();
                        txtPasword.Focus();
                    }
                    else
                        if (Mensaje == "El Nombre de Usuario no Existe.")
                    {
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtUser.Clear();
                        txtPasword.Clear();
                        txtUser.Focus();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        FormPrincipal fr = new FormPrincipal();
                        //RecuperarDatosSesion();
                        fr.Show();
                        this.Hide();
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
    }
}
