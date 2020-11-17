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
using Business.Business.UnidadMedida;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistroUnidadMedida : Form
    {
        BusinessUnidadMedida UM = new BusinessUnidadMedida();
        public FormRegistroUnidadMedida()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var um = new UnidadMedida();
            String msj = "";

            if (txtNombreUM.Text.Trim() != "")
            {
                if (txtDescriptionUM.Text.Trim() != "")
                {
                    if (Program.Evento == 0)
                    {
                        um.Code_unit = txtCodigoUM.Text;
                        um.Unit_name = txtNombreUM.Text;
                        um.Description = txtDescriptionUM.Text;
                        um.created_at = DateTime.Today;
                        um.updated_at = DateTime.Today;

                        msj = UM.RegistrarUnidadMedida(um);
                        if (msj == "Esta unidad de medida ya ha sido Registrado.")
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
                        um.Code_unit = txtCodigoUM.Text;
                        um.Unit_name = txtNombreUM.Text;
                        um.Description = txtDescriptionUM.Text;
                        um.updated_at = DateTime.Today;
                        MessageBox.Show(UM.ActualizarUnidadMedida(um), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        Close();
                    }

                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese decripcion de la marca.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescriptionUM.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre de la marca.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreUM.Focus();
            }
            FormListarUM U = new FormListarUM();
            U.timer1.Start();
        }
        private void Limpiar()
        {
            txtCodigoUM.Text = "";
            txtNombreUM.Text = "";
            txtDescriptionUM.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
