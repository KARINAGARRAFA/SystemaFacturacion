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
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormListarVentas : Form
    {
        public FormListarVentas()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistrarVentas V = new FormRegistrarVentas();
            V.Show();
        }
    }
}
