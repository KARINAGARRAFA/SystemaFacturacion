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
using Business.Business.Modelo;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistroModelo : Form
    {
        BisnessModelo MD = new BisnessModelo();
        public FormRegistroModelo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var md = new Modelo();
            String msj = "";

            if (txtNombreModelo.Text.Trim() != "")
            {
                if (txtDescriptionModelo.Text.Trim() != "")
                {
                    if (Program.Evento == 0)
                    {
                        md.Code_model = txtCodigoModelo.Text;
                        md.Model_name = txtNombreModelo.Text;
                        md.Description = txtDescriptionModelo.Text;
                        md.created_at = DateTime.Today;
                        md.updated_at = DateTime.Today;

                        msj = MD.RegistrarModelo(md); 
                        if (msj == "Esta marca ya ha sido Registrado.")
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
                        md.Code_model = txtCodigoModelo.Text;
                        md.Model_name = txtNombreModelo.Text;
                        md.Description = txtDescriptionModelo.Text;
                        md.updated_at = DateTime.Today;
                        MessageBox.Show(MD.ActualizarModelo(md), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        Close();
                    }

                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese decripcion de la marca.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescriptionModelo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre de la marca.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreModelo.Focus();
            }
            FormListarModelo modelo = new FormListarModelo();
            modelo.timer1.Start();
        }
        private void Limpiar()
        {
            txtCodigoModelo.Text = "";
            txtNombreModelo.Text = "";
            txtDescriptionModelo.Text = "";
        }
    }
}
