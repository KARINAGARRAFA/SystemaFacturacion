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

        

        private void button4_Click(object sender, EventArgs e)
        {
            FormListarCompras Cp = new FormListarCompras();
            Cp.MdiParent = this;
            Cp.Show();
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

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void cOMPRASToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            FormListarCompras Cp = new FormListarCompras();
            Cp.MdiParent = this;
            Cp.Show();
        }

        private void cOMPRASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarCompras Cp = new FormListarCompras();
            Cp.MdiParent = this;
            Cp.Show();
        }

        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarVentas Vn = new FormListarVentas();
            Vn.MdiParent = this;
            Vn.Show();
        }

        private void pRODUCTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduct P = new FormProduct();
            P.MdiParent = this;
            P.Show();
        }

        private void mARCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarMarca M = new FormListarMarca();
            M.MdiParent = this;
            M.Show();
        }

        private void cATEGORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarCategoria C = new FormListarCategoria();
            C.MdiParent = this;
            C.Show();
        }

        private void mODELOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarModelo M = new FormListarModelo();
            M.MdiParent = this;
            M.Show();
        }

        private void uMEDIDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarUM UM = new FormListarUM();
            UM.MdiParent = this;
            UM.Show();
        }

        private void eMPRESAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarUser USER = new FormListarUser();
            USER.MdiParent = this;
            USER.Show();
        }

        private void uSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarPersonal Pr = new FormListarPersonal();
            Pr.MdiParent = this;
            Pr.Show();
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarClientes Ct = new FormListarClientes();
            Ct.MdiParent = this;
            Ct.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
