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
using Business.Business.Marca;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistroMarca : Form
    {
        BusinessMarca Mr = new BusinessMarca();
        public FormRegistroMarca()
        {
            InitializeComponent();
        }

        private void FormRegistroMarca_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var m = new Marca();
            String msj = "";
            
            if (txtNombreMarca.Text.Trim()  != "")
            {
                if (txtDescriptionMarca.Text.Trim() != "")
                {
                    if (Program.Evento == 0)
                    {
                        m.Code_trademark = txtCodigoMarca.Text;
                        m.Trademark_name = txtNombreMarca.Text;
                        m.Description = txtDescriptionMarca.Text;
                        m.created_at =  DateTime.Today;
                        m.updated_at = DateTime.Today;

                        msj = Mr.RegistrarMarca(m);
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
                        m.Code_trademark = txtCodigoMarca.Text;
                        m.Trademark_name = txtNombreMarca.Text;
                        m.Description = txtDescriptionMarca.Text;
                        m.updated_at = DateTime.Today;
                        MessageBox.Show( Mr.ActualizarMarca(m), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        Close();
                    }

                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese decripcion de la marca.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescriptionMarca.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre de la marca.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreMarca.Focus();
            }
            FormProduct LP = new FormProduct();
            LP.timer1.Start();
        }
        private void Limpiar()
        {
            txtCodigoMarca.Text = "";
            txtNombreMarca.Text = "";
            txtDescriptionMarca.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
