using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Presentation.Forms;

namespace Presentation.Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pnlProducto.Visible == true)
            {
                pnlProducto.Visible = false;
            }
            else
            {
                pnlProducto.Visible = true;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormListarCompras Cp = new FormListarCompras();
            Cp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pnlUser.Visible == true)
            {
                pnlUser.Visible = false;
            }
            else
            {
                pnlUser.Visible = true;
            }

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProduct P = new FormProduct();
            P.Show();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            FormListarMarca M = new FormListarMarca();
            M.Show();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FormListarCategoria C = new FormListarCategoria();
            C.Show();
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            FormListarModelo M = new FormListarModelo();
            M.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FormListarUser USER = new FormListarUser();
            USER.Show();
        }

        private void btnUMedida_Click(object sender, EventArgs e)
        {
            FormListarUM UM = new FormListarUM();
            UM.Show();
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            FormListarPersonal Pr = new FormListarPersonal();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormListarVentas Vn = new FormListarVentas();
            Vn.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormListarClientes Ct = new FormListarClientes();
            Ct.Show();
        }
    }
}
