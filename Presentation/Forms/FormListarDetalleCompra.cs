using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class FormListarDetalleCompra : Form
    {
        public FormListarDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void FormListarDetalleCompra_Load(object sender, EventArgs e)
        {
            Visibilidad();
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
    }
}
